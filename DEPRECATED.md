# ⚠️ Last Witness — DEPRECATED

> **Status:** Project halted at v0.1 by the Critic & Review Board (Cycle 4).
> **Reason:** The game's core loop is fundamentally an LLM-runtime experience.
> Under the studio's clarified policy that **AI is a development workflow tool,
> not a runtime gameplay feature**, this title has no shipping form.

## Why Last Witness is different from the other 5 titles in the slate

All six v0.1 projects used Claude at runtime, but in **five of them** Claude was a
flavour layer on top of a self-contained game loop:

| Game | Core loop without LLM | LLM was … |
|---|---|---|
| 🌻 Hearth & Hex | Farming + brewing + festivals | Villager flavour text |
| ⚔️ Ashen Veil | Souls-like combat + bosses + bonfires | Echo lore-master |
| 👻 Hollow Quota | Co-op horror extraction | Radio Director banter |
| 🏎️ Neon Drift Syndicate | Cyber racer + drift + weapons | Race commentator |
| 🧗 Skybound Trials | Parkour platformer | Coach (motivator/heckler) |
| 🔍 **Last Witness** | **— no core loop —** | **The entire game** |

In Last Witness:
- Every suspect was a Claude persona. Player questions were free-form. The suspect's lies, deflections, and partial admissions emerged from the LLM.
- The Captain (case-giver) was Claude.
- The Deduction Evaluator (which judged your accusation) was Claude with a long evidence-bundle prompt.

Strip the LLM and you do not have a different detective game. You have:
- ~3 static text-tree NPCs (no chance against Disco Elysium, Obra Dinn, Golden Idol, Pentiment)
- No way to evaluate free-form accusations
- ~5 minutes of authored dialogue per case
- Zero discoverability angle on Steam

## Critic & Review Board verdict (Cycle 4)

| Reviewer | Verdict | Notes |
|---|---|---|
| Lead Game Director | ❌ Rejected | Strip LLM → collapses to a sub-standard adventure |
| Technical Director | ❌ Rejected | Without LLM there is no Deduction Evaluator |
| Narrative Director | ❌ Rejected | Hand-authoring 3 suspects × 6 cases × ~80 turns each ≈ 1,440 dialogue branches per case = 8,640 total. Out of scope. |
| Trend Analyst | ❌ Rejected | Without Suck-Up!-style differentiation, no marketing hook |
| Asset Director | ⚠️ Approved | Assets remain in your inventory for any future use |
| AI/Cost Lead | ❌ Rejected | The core loop is the cost — no way to fix |

**Final:** ❌ **REJECTED — project halted.**

Signed: Lead Game Director, Technical Director, Narrative Director, Trend Analyst, AI/Cost Lead.

## What is preserved

The `main` branch retains the complete v0.1 design:
- `docs/01_IDEATION_AND_TRENDS.md` — the original market case
- `docs/02_GAME_DESIGN_DOCUMENT.md` — Case 01 full design
- `docs/03_ASSET_PLAN.md` — asset coverage
- `docs/04_TECHNICAL_ARCHITECTURE.md` — the architecture as it stood
- `docs/05_AI_COPILOT_INTEGRATION.md` — the full LLM integration plan
- `docs/06_CRITIC_REVIEW_CYCLES.md` — Cycles 1–3 (pre-clarification)
- `docs/07_UNITY_SETUP_GUIDE.md` — the v0.1 setup steps
- `Assets/_Project/Scripts/` — all v0.1 code
- `server/copilot-proxy/` — the v0.1 Node proxy

## When this could be revisited

- If Anthropic (or another vendor) ships a Steam-policy-compliant, fully on-device, cost-acceptable inference path for retail games.
- If the studio decides to pivot Last Witness into a non-LLM detective format (e.g., a hand-crafted Obra Dinn-style passage of fate) — in which case a new GDD is required.
- If a publisher / partner pre-funds the LLM token spend for a launch.

Until then, this repository is **frozen**. PRs are not accepted on `main`.

## Suggested re-allocation

The Inventix Asset Store packs listed in `docs/03_ASSET_PLAN.md` (Dialogue System OpenAI Addon, City Characters Modular Animated, Office Floors, City Pack, Eyes Animator, Cutscene Engine, Bamao Pack GUI, Heat UI, Animation Composer System, Urban Abandoned District) are all reusable on the active slate — particularly the Urban Abandoned District in `hollow-quota`, and Bamao Pack / Heat UI everywhere.
