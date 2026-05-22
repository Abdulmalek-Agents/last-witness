# Changelog — Last Witness

## [v0.2-deprecated] — Project halted

### Changed
- **Critic & Review Board Cycle 4** issued a unanimous ❌ **Rejected** verdict after
  the studio clarified that AI is a development-workflow tool, not a runtime gameplay
  feature. Unlike the other five titles on the slate, Last Witness's *entire* gameplay
  loop is LLM-driven and cannot be refactored to ship without runtime AI.
- Added `DEPRECATED.md` with the full rationale and re-pitch criteria.
- Replaced `README.md` with a deprecation banner.

### Preserved
- All v0.1 design documents under `docs/` remain on `main` for historical reference.
- All v0.1 C# scripts and the Node copilot proxy remain in git history.

### Status
- This repository is **frozen**. PRs are not accepted on `main`.
- The Asset Store packs listed in v0.1 docs/03 are all reusable across the five active titles.

---

## [v0.1-mission1-skeleton] — Initial scaffolding

### Added
- Concept locked through 3 Critic Review Board cycles
- GDD v1.0 (Case 01: The Vanishing of Reeve Hallam)
- Asset Plan, Tech Architecture, AI integration doc, Unity setup guide
- Suspect persona ScriptableObjects, dialogue UI, deduction evaluator hook
- Claude AI integration as the entire game (suspects + Captain + verdict)
- Node proxy server with Anthropic key handling
