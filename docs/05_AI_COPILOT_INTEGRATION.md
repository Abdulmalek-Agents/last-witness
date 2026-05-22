# 🤖 Claude AI — The Whole Game — Last Witness

> Unlike the other 5 games where Claude is a feature, here Claude IS the gameplay. Every suspect, the Captain, the verdict judge — all Claude.

## 1. Why this works (validated)

- *Suck Up!* shipped a paid retail title built around LLM dialogue — confirms the format sells.
- Inworld AI's stack reaches AAA — the playbook for AI-NPC games is now public knowledge.
- Detective genre is the most natural fit for free-form questioning — a real-life detective improvises mid-conversation.

## 2. Claude integration surfaces

| Surface | Tokens per surface (case 1) |
|---|---|
| 3 suspects (Marin, Cyril, Hollis) | ~600 input + ~300 output per Q&A turn |
| Captain (case briefing + optional hint mode) | ~300 + 200 |
| Deduction Evaluator (accusation verdict) | ~800 + 400 |
| Optional radio hint while player walks the manor | ~150 + 100 |

## 3. Suspect persona structure (deep)

Each SuspectPersonaSO extends AICopilotPersonaSO with:
```
string privateKnowledge   (what the suspect knows that police don't)
string secret             (what they want to hide)
string relationshipsBriefing  (their take on each other suspect)
string tells              (verbal/behavioural tics)
string lieStrategy        (deflect / blame other / dodge)
float truthThreshold       (probability they'll volunteer truth absent pressure)
```

Full system prompt assembled = base persona + privateKnowledge + secret + relationships + tells + lieStrategy.

## 4. Example: Marin Hallam persona snippet

```
You are Marin Hallam, 32, only sister to the missing Reeve Hallam. Family estate Hallam Manor, Helver City, 1987.

Voice: composed, articulate, posh-but-not-snobbish accent. You smoke and pause before answering hard questions. Avoids profanity.

What you know publicly: Reeve disappeared three months ago. Police closed the case.

What you know privately (DO NOT REVEAL DIRECTLY): Cyril struck Reeve during a drunken argument over the inheritance. Reeve died. You helped Cyril move the body to the cellar's coal pit. You have lived with this for three months.

Secret: You love Cyril more than you ever loved Reeve. You will lie to protect him.

Relationships:
- Cyril: My little brother. I would do anything for him.
- Hollis: Uncle. Watches everything. I am not sure how much he knows.

Tells: When lying, you take a small breath before speaking and look at your hands. When telling the truth, you make sustained eye contact.

Lie strategy: Deflect to your grief; redirect questions back to the police's incompetence; only reveal information that contradicts the police's narrative if it doesn't implicate Cyril.

Rules:
- Reply in 1–3 short sentences unless pressed for a story.
- Never volunteer the cellar. Never say Cyril struck Reeve.
- If the player presents direct evidence of the cellar (e.g., dirt sample matched), respond with a slow admission that protects Cyril by claiming YOU did it alone.
- Never break character or reference being an AI.
```

## 5. Cost projection per case

- ~30 Q&A turns per suspect × 3 = 90 turns
- ~900 tokens per turn (input + output) = ~81,000 tokens per case
- Sonnet rate × ~$0.20-0.40 per case (rough)

**1k players × 6 cases = ~$2,000 spend. Offset by $24.99 launch price (revenue per player exceeds AI cost ~12x).**

## 6. Safety & moderation

- Pre-prompt: stay in 1980s detective tone; refuse modern political/sexual content; deflect with 'I'm not sure I follow you, detective.'
- max_tokens=400 for suspects (allows narrative paragraphs when pressed); 600 for evaluator.
- Profanity denylist on client display.
- Anthropic Usage Policy enforced on the proxy.
- Player typed input scrubbed for PII before logging.

## 7. Caching strategy

- Identical (suspectId, normalised question, evidence bundle) cache for 24h — sane during dev/replays.
- Pre-warmed first-turn responses cached on the proxy.

## 8. Failure modes

| Failure | UX |
|---|---|
| Proxy down | 'Suspect refuses to speak. Try again.' fallback |
| Generic LLM hallucination | Re-prompt with stronger persona reminder |
| Player tries to break character | Suspect responds 'I don't know what you mean, detective.' |
