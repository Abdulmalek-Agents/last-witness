# 🧱 Technical Architecture — Last Witness

## 1. Stack

Unity 2022.3 LTS + URP. Dialogue System (adapted to Claude). Addressables. Claude proxy.

## 2. Scripts

```
Core/         (shared)
AI/           ClaudeCopilotService, AICopilotPersonaSO, ClaudeDialogueAdapter
UI/           MainMenuController, NotebookUI, InterrogationUI
Gameplay/
  Player/     DetectivePlayer, PlayerInteractor
  Suspects/   SuspectNpc, SuspectPersonaSO (extends AICopilotPersonaSO with secrets)
  Evidence/   EvidenceItem, EvidenceLedger, EvidenceItemSO
  Case/       CaseSO, CaseManager
  Deduction/  AccusationFlow, DeductionEvaluator (Claude-driven)
  Captain/    CaptainBriefing  (Claude AI boss)
  Case01/     Case01Director
```

## 3. Scenes

| Scene | Idx |
|---|---|
| Bootstrap | 0 |
| MainMenu | 1 |
| Niko's Office (hub) | 2 |
| Case01_HallamManor | 3 |
| Case02_HelverTheatre .. Case06_LastWitness | 4-8 |

## 4. Suspect AI flow

```
Player types question → SuspectNpc.AskQuestion(q)
  → Build context = system prompt + recent N exchanges + (optional evidence shown)
  → ClaudeCopilotService.Ask(context, q, OnReply)
  → Stream response to InterrogationUI typewriter
  → Add Q+A to EvidenceLedger as 'Marin said: ...'
```

## 5. CaseSO data model

```
CaseSO
  caseId, displayName, briefingText
  List<SuspectPersonaSO> suspects
  string hiddenTruth  (e.g. 'Cyril killed Reeve in a drunken argument; Marin moved the body to the cellar to protect him.')
  List<EvidenceItemSO> evidenceItems
  List<string> requiredEvidenceForFullCase
```

The hiddenTruth is provided to DeductionEvaluator during accusation but NEVER sent to suspects — only their persona-specific knowledge is.

## 6. Accusation flow

```
Player opens Accusation panel
  → Picks 1 suspect, drags evidence items into bundle, types accusation text
  → DeductionEvaluator.Evaluate(suspectId, evidenceBundle, accusationText, hiddenTruth)
     - Builds a structured prompt:
         You are a fair detective game judge. Hidden truth: <X>.
         Player accusation: <suspect>: <text>.
         Evidence cited: <list>.
         Score: TRUE_EVIDENCED / TRUE_UNDEREVIDENCED / FALSE.
     - Claude returns one of three verdicts + a 1-paragraph rationale.
  → Plays corresponding verdict Cutscene
```

## 7. Cost guard

- Per-suspect token budget per case (e.g., 4,000 input + 2,000 output max).
- Hard cap on session; afterwards Dialogue System falls back to canned lines.
- Identical-context cache (5-min window) to avoid re-asking the same Q.

## 8. Scalability

- New case = new CaseSO + scene + 3–5 SuspectPersonaSO + 6 EvidenceItemSO.
- No code changes.

## 9. Performance

- Cinematic walking-sim — 60 fps easy.
- Memory < 1 GB.
- Network: < 50 KB per suspect turn (~300 input tokens, JSON).
