# 📜 Game Design Document — Last Witness

## 1. High-concept

1987. Helver City. You are *Niko Reyes*, a private investigator. The police gave up on the Reeve Hallam case three months ago; the family hired you. Three suspects, one disappearance, no body. Interrogate them in their own words — they will lie, deflect, slip up, and occasionally tell the truth. Build evidence. Make the accusation. Live with the consequences.

**Fantasy:** 'I am the only person who can talk this person into telling the truth.'

**Emotional journey:** Curiosity → suspicion → escalating tension → revelation → guilt or vindication.

**Pillars:**
1. **Suspects feel alive.** Every Claude response is in-character.
2. **Player input is free-form.** You type what you want to ask.
3. **Evidence drives the case.** Words spoken can be cited later as contradictions.

## 2. Core game loop

`Receive case briefing → Visit crime scene → Interrogate suspect → Note evidence → Cross-reference → Accuse → Verdict`

## 3. Player verbs

| Verb | Input | Notes |
|---|---|---|
| Walk | WASD | Walking-sim pace |
| Interact / examine | E | Pick up evidence, open files |
| Open Notebook | TAB | Evidence ledger + case timeline |
| Talk to suspect | E on NPC | Opens Interrogation UI |
| Type question | Keyboard | Free-form, sent to Claude |
| Show evidence | Click + drag from notebook to suspect | Claude-aware prompt enrichment |
| Press / Accuse | Bottom-bar button | Triggers Accusation flow |

## 4. Mission structure (6 cases)

| # | Case | Location | Suspects | Twist |
|---|---|---|---|---|
| **1** | *The Vanishing of Reeve Hallam* | Hallam Manor | 3 family | One is covering for another |
| 2 | *The Stagehand's Knife* | Helver Theatre | 4 cast/crew | Public-figure stakes |
| 3 | *Foundry Smoke* | Industrial dockside | 4 union members | Politics |
| 4 | *The Embassy Letter* | Diplomatic district | 5 staff | Classified twist |
| 5 | *The Missing Years* | Old asylum | 3 patients + 1 staff | Unreliable narrator |
| 6 | *Last Witness* | Your own office | 3 ghosts of past cases | Meta-finale |

## 5. Case 01 — *The Vanishing of Reeve Hallam*

**Duration:** 25–40 min.

**Setup:** Reeve Hallam, 34, disappeared from the family estate three months ago. The maid was the last person to see him. His sister Marin, brother Cyril, and uncle Hollis are all home tonight.

**Flow:**
1. Office — Captain (Claude, briefing in 2-3 sentences). 3 case files (clickable).
2. Drive to Hallam Manor (cut).
3. Foyer — meet the three suspects. Free movement through the manor.
4. Interrogate any suspect, in any order, as many times as you like.
5. Examine 6 evidence items in the manor (cellar door, study desk, broken vase, packed suitcase, latched conservatory window, dirt on shoe).
6. When confident: open the Accusation panel. Choose a suspect + select pieces of evidence + write a 1-2 sentence accusation.
7. Verdict cutscene plays based on Claude's evaluation of the accusation + evidence quality.

**Objectives:**
- `c1_meet_suspect_marin`
- `c1_meet_suspect_cyril`
- `c1_meet_suspect_hollis`
- `c1_examine_cellar` (3 examination spots)
- `c1_accusation_made` (1)
- `c1_optional_uncover_full_truth` (1, optional)

## 6. The three suspects (Case 01)

| Name | Surface | Hidden |
|---|---|---|
| **Marin Hallam** (sister) | Grieving, polite | Knows where the body is; protecting Cyril |
| **Cyril Hallam** (brother) | Belligerent, drunk | Argued with Reeve about an inheritance |
| **Hollis Hallam** (uncle) | Detached, intellectual | Witnessed something he hasn't told the police |

## 7. Claude-driven interrogation

Each suspect has a deep `AICopilotPersonaSO` (>400 token system prompt). Includes:
- Speaking voice + tells
- Backstory + secrets
- What they will admit, deflect, deny
- Their relationship to other suspects

The player's typed question + (optional) shown evidence + recent conversation memory = prompt context. Claude replies in 1–3 sentences. Streamed into the InterrogationUI as live text.

## 8. Evidence ledger + cross-examination

The Notebook stores every line each suspect said. The player can highlight a line and 'tag' it as a claim. Later, when interrogating another suspect, the player can show that claim. Claude is given the prior claim in the prompt: 'Marin previously said she was in the garden at 9pm. The player is showing this to Cyril.' Cyril's response is contextual.

## 9. Accusation system

Accusation = (Suspect, Evidence Bundle, Player's typed accusation text). System builds a structured prompt to Claude asking it to score the accusation against the case's hidden truth + evaluate the evidence bundle's strength. Returns a verdict:
- **TRUE + EVIDENCED:** Best ending.
- **TRUE + UNDEREVIDENCED:** Right person, fragile case — mixed ending.
- **FALSE:** Wrong suspect — bad ending. Game over for this case.

## 10. UI

- Heat UI base.
- Notebook: Bamao Pack frames.
- InterrogationUI: focused dialogue box with portrait, evidence drop-zone, free-form text input.
- Camera: cinematic over-the-shoulder during interrogation.

## 11. Accessibility

- Subtitle Claude output (always on).
- Text size XL.
- Dyslexic font toggle.
- Optional 'hint mode': Captain (Claude) gives nudges in the radio.
- Player input via dropdown of suggested questions (for typing-fatigue accessibility).

## 12. Cut-list

1. Voice synth for suspects.
2. Cases 5-6 deferred to post-launch.
3. Free-form 'show evidence by drag-drop' — fallback to button click.

**Never cut:** Free-form text questioning, Claude-driven suspects, evidence-cross-reference.

✅ **Approved.**
