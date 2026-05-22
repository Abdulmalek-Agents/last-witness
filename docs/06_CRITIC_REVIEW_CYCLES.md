# 🔍 Critic & Review Board — 3 Cycles for Last Witness

## Cycle 1 — Concept

| Reviewer | Verdict | Notes |
|---|---|---|
| Lead | ⚠️ Approved w/ Notes | LLM-NPC games are ambitious for indie; needs strong cost guard |
| Technical | ⚠️ Approved w/ Notes | Need explicit accusation evaluator design — can't just be vibes |
| Trend | ✅ Approved | Suck Up! + Inworld AI validation |
| Asset | ✅ Approved | Dialogue System OpenAI Addon is the foundation; ~80% coverage |

**Required for C2:**
1. Token + cost cap design → **resolved** in 05 §6.
2. Accusation evaluator structured-prompt spec → **resolved** in 04 §6.

## Cycle 2 — GDD

| Reviewer | Verdict | Notes |
|---|---|---|
| Lead | ⚠️ Approved w/ Notes | 6 cases is ambitious; ensure M1 is shippable alone |
| Narrative | ⚠️ Approved w/ Notes | Each suspect needs a 400+ token persona doc with secrets + tells |
| Accessibility | ⚠️ Approved w/ Notes | Free-form typing alienates non-typists; add dropdown alternative |
| QA | ✅ Approved | M1 testable in 25 min |

**Required for C3:**
1. M1 is fully shippable as a standalone vertical slice → **resolved**.
2. Suspect persona format → **defined** in 05 §3.
3. Suggested-questions dropdown accessibility → **added**.

## Cycle 3 — Architecture + Asset + AI

All ✅ Approved. Final notes from Legal: ensure Anthropic Usage Policy is reproduced in the About panel + privacy disclosure.

## ✅ Final — APPROVED.

Case 01 ships as vertical slice.

## Watch-list

- Token cost real-world variance — monitor carefully in beta.
- Suspect 'jailbreak' attempts — add re-prompt guard.
- Voice synth lobbying — community will ask; ship in v0.3.
- Replayability — each case must be re-playable with different questioning paths.
