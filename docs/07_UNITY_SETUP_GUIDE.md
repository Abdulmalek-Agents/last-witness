# 🛠️ Unity Setup Guide — Last Witness

## Prerequisites
- Unity 2022.3.30f1 LTS
- Inventix Asset Store account holding the assets in `03_ASSET_PLAN.md`
- Node.js 18+
- Anthropic API key (essential; this game does not function offline beyond fallback lines)

## Step 1 — New Unity project
3D (URP) Core → `LastWitness`.

## Step 2 — Drop repo
```bash
git clone https://github.com/Abdulmalek-Agents/last-witness.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Pipeline
URP. Linear color. High Quality. Bake high-quality lightmaps for cinematic look.

## Step 4 — Import order
1. Heat UI
2. Bamao Pack Fantasy GUI
3. **Dialogue System for Unity OpenAI Addon** (also requires Dialogue System for Unity — free Asset Store legacy preferred; otherwise commercial purchase)
4. City Characters Modular Animated
5. Office Floors
6. City Pack
7. Urban Abandoned District
8. Medieval Village Megapack
9. Eyes Animator
10. Animation Composer System
11. Cutscene Engine
12. Lumen FX 2
13. VoluSmokeFX
14. Game UI & Puzzle SFX Pack

Move asset folders to `Assets/_Project/Art/`.

## Step 5 — Adapt Dialogue System addon to Claude

The addon ships pointed at OpenAI. In `ClaudeDialogueAdapter.cs` we override its HTTP target to our Node proxy (`http://localhost:8787/v1/messages`) and re-map the Anthropic message envelope. See script comments inside.

## Step 6 — Bootstrap scene
`Scenes/Bootstrap.unity` → `[Game]` with `GameBootstrap`. Build idx 0.

## Step 7 — MainMenu
Heat UI main menu. Build idx 1.

## Step 8 — Niko's Office
Build `Scenes/NikoOffice.unity` with Office Floors props. CaptainBriefing GameObject with `Persona_Captain.asset`.

## Step 9 — Case 01 — Hallam Manor
1. New scene `Case01_HallamManor.unity`.
2. Drop Medieval Village + City Pack interior to make a Victorian-style manor.
3. Place 3 SuspectNpc prefabs (Marin, Cyril, Hollis) using City Characters bodies + Eyes Animator + Animation Composer.
4. Place 6 EvidenceItem prefabs at examination spots.
5. NotebookUI canvas (Bamao Pack frames).
6. InterrogationUI canvas (custom; see `Assets/_Project/Scripts/UI/`).
7. `[Case01Director]` GameObject with Case01Director.cs.
8. Create `Case01_VanishingOfReeveHallam.asset` (CaseSO) with 6 objectives + 3 SuspectPersonaSO + 6 EvidenceItemSO + hiddenTruth string.

Build idx 3.

## Step 10 — AI proxy
```bash
cd server/copilot-proxy && cp .env.example .env
npm install && npm run dev
```

## Step 11 — Write the 3 suspect personas

Create each persona ScriptableObject (Persona_Marin, Persona_Cyril, Persona_Hollis). Paste the 400-600 token system prompts. See `05_AI_COPILOT_INTEGRATION.md §4` for Marin's full example. Use that as a template for Cyril and Hollis.

## Step 12 — Playtest
Bootstrap → New Case → NikoOffice → Captain briefing (Claude) → Hallam Manor → Talk to Marin: type any question → Claude responds in-character. Show her some evidence → she reacts. Build a case. Open Accusation → select suspect + evidence + type accusation → Verdict.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Suspect breaks character | Persona system prompt too short; reinforce 'never reference being an AI' |
| Suspect gives away truth on first question | privateKnowledge leaking into systemPrompt; restructure persona |
| Accusation always returns FALSE | DeductionEvaluator hiddenTruth in CaseSO is empty |
| Suspect feels too generic | Add tells + lieStrategy fields to persona |
| Proxy timeout | Bump UnityWebRequest.timeout to 45 |

## After Case 01
Tag `v0.1-case1-playable`. Case 2 = new scene + new CaseSO + new SuspectPersonaSOs.
