# 🎨 Asset Plan — Last Witness

## 1. Inventory

| Asset | Used for | Critical |
|---|---|---|
| **Dialogue System for Unity OpenAI Addon** ($45) | Dialogue framework + AI extension we adapt to Claude | 🔴 Yes |
| **City Characters Modular Animated** ($259) | Player + 20+ suspects/civilians across 6 cases | 🔴 Yes |
| **Office Floors Low Poly** ($99) | Captain's precinct office + interrogation rooms | 🔴 Yes |
| **City Pack** ($144.99) | Hallam Manor exterior + city streets | 🔴 Yes |
| **Urban Abandoned District** | Case 3 docks, Case 5 asylum | 🟡 Helpful |
| **Medieval Village Megapack** | Hallam Manor interior re-skin (old-money estate) | 🟡 Helpful |
| **Eyes Animator** ($11.99) | Suspect eye behaviour — critical for tension | 🔴 Yes |
| **Animation Composer System** ($39.99) | Layered body language (nervous shifts, gestures) | 🔴 Yes |
| **Cutscene Engine** ($35) | Case intros, verdict cutscenes | 🔴 Yes |
| **Bamao Pack Fantasy GUI** ($25) | Notebook + frame decorations | 🔴 Yes |
| **Heat UI** ($69.99) | Main menu, settings, results | 🔴 Yes |
| **Lumen FX 2** ($35) | Dramatic interrogation key light, sun shafts | 🟡 Helpful |
| **VoluSmokeFX** ($25) | Cigarette smoke (period accurate) | 🟡 Helpful |
| **Game UI & Puzzle SFX Pack** | Page turn, typewriter, notebook clicks | 🔴 Yes |

**Inventory value applied: ~$830 across 14 assets.**

## 2. Must-buy

| Gap | Cost |
|---|---|
| Jazz-noir OST (4 tracks) | $250 |
| 1980s era props (rotary phone, typewriter) | $30 |
| Optional voice synth for suspects | API cost |

## 3. Folder org — standard.

## 4. Performance

- Cinematic walking-sim spec; bake high-quality lightmaps offline.
- Suspect facial animations driven by Eyes Animator + Animation Composer.
- Claude responses cached for 24h on identical prompts (cost saver during testing).

## 5. Licence ✅. No binaries.

## 6. Checklist

- [ ] Import all assets
- [ ] Adapt Dialogue System OpenAI Addon to point at our Claude proxy
- [ ] Build Player_Niko + 3 suspect prefabs
- [ ] Author Hallam Manor scene
- [ ] Write the 3 suspect persona system prompts (400-600 tokens each)
