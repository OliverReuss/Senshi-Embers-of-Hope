# Senshi: Embers of Hope

 ![Unity 2022.3.11f1](https://img.shields.io/badge/unity-2022.3.11f1-blue)
 ![License: MIT](https://img.shields.io/badge/license-MIT-lightgrey)
 [![Play on itch.io](https://img.shields.io/badge/Play%20on-itch.io-red)](https://itch.io/)

Senshi: Embers of Hope is a low-poly action-adventure with melee combat, NPC dialogue, and short exploratory chapters. Navigate biomes, face enemies with combo attacks, and progress through story beats with simple crafting elements.

---

## Key Gameplay Concept

Unlike classic top-down adventures, Senshi mixes third-person camera-relative movement with physics-based jumping and mouse-driven melee combos that allow single/double/triple strike chains depending on click timing.

## Features

* Third-person movement oriented to camera with smooth turning
* Melee combo system (single/double/triple click) and hit detection via raycasts
* Rigidbody-based jumping and physics interactions
* Dialogue/Conversation system using Dialogue Editor
* Pause menu, scene management, and basic crafting hooks

## Play Online / Builds

* **Browser (WebGL):** Play on itch.io (placeholder link)
* **PC Standalone:** Use GitHub Releases for executable downloads

## Prerequisites (Editor Setup)

* **Unity:** 2022.3.11f1 (LTS)
* **Packages:** Universal RP, TextMeshPro, Input System, Cinemachine, Timeline

## Quickstart (Editor)

1. Install Unity Hub and add `2022.3.11f1`.
2. Clone the repo and open the folder in Unity Hub:

```bash
git clone https://github.com/<your-username>/<repo>.git
cd <repo>
```

1. (Optional) Install and pull Git LFS assets:

```bash
git lfs install
git lfs pull
```

1. Open the project in Unity Hub, let packages resolve, and open your main Scene (e.g., `Scenes/Main.unity`).

## Local Build (PC Standalone)

1. File → Build Settings → Add the main scenes to *Scenes in Build*.
2. Platform → *PC, Mac & Linux Standalone* → Build.

## Controls

| Action | Input |
| :--- | :--- |
| **Move** | `W`, `A`, `S`, `D` or Joystick Left Stick |
| **Aim / Cursor** | Mouse |
| **Attack** | Left Mouse Button (single/double/triple click combos) |
| **Jump** | `Space` (mapped to `Jump` input) |
| **Interact / Talk** | `F` |
| **Pause** | `Esc` |

## Architecture (Overview)

* `PlayerController` — movement, `OnMove` (Input System) and legacy fallbacks
* `Schlagen` — melee attack / combo logic and raycast hit detection
* `ConversationStarter` — triggers dialogue on player proximity and `F` input
* `PauseMenu` — pause/resume UI and scene control

## Screenshots

Place screenshots and GIFs under `docs/` and reference them here. Example:

<div align="center">
  <img src="docs/screenshot-1.png" width="600" alt="Gameplay">
</div>

## License

[MIT](LICENSE)

## Contact / Credits

* **Author:** Oliver Reuß
* **Academic Context:** SWE&GD 23/24 — Gruppe C

---

If you'd like, I can: commit these changes, consolidate the CI workflow, and remove the extra `deploy.yml` file so only `unity-build.yml` remains.
