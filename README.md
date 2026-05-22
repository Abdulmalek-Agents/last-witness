# 🔍 Last Witness

> An AI-powered detective game. You are a private investigator in 1980s Helver City. Suspects are conversational — you ask anything, they answer in character, in real time, powered by Claude. Catch the truth before time runs out.

| | |
|---|---|
| **Genre** | AI-Driven Narrative Mystery / Detective Sim |
| **Platforms** | PC (Steam) primary |
| **Engine** | Unity 2022.3 LTS + URP |
| **Target frame-rate** | 60 fps integrated GPU (cinematic walking-sim spec) |
| **Mission 1 scope** | Case 01: *The Vanishing of Reeve Hallam* — 3 suspects, 1 location, 25-40 min |
| **Designed for** | 6 cases (different locations, escalating complexity) |
| **AI co-pilot** | **The whole game is the AI co-pilot.** Suspects, Captain (your boss), case files — all Claude-driven. |

## Why this game

| Signal | Source |
|---|---|
| Suck Up! proved LLM-NPC games ship and sell | Going viral on Reddit for unpredictable AI conversation |
| Inworld AI demos hit AAA scale (Ubisoft, Disney, Xbox) | Big-studio validation |
| Detective games (Disco Elysium, Obra Dinn) have strong indie precedent | Narrative-first niche is open |
| Indie narrative games peaked Oct-Dec 2025 in search demand | Timing window |

Details in `docs/01_IDEATION_AND_TRENDS.md`.

## Quick start

1. Read `docs/07_UNITY_SETUP_GUIDE.md`.
2. Unity 2022.3 LTS URP; copy `Assets/_Project/`.
3. Import: **Dialogue System OpenAI Addon** (adapted to Claude), City Characters Modular Animated, Office Floors, City Pack, Eyes Animator, Cutscene Engine, Bamao Pack GUI, Heat UI, Animation Composer System, Urban Abandoned District — all in your inventory.
4. `cd server/copilot-proxy && npm install && npm run dev`.
5. Open `Scenes/Bootstrap.unity`.

## Status

| Stage | Status |
|---|---|
| Concept locked (3 critic cycles) | ✅ |
| GDD v1.0 approved | ✅ |
| Architecture & scripts | ✅ |
| Case 01 authored | ⏳ needs asset import |
