# Tower Stack

[![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=for-the-badge&logo=unity)](https://unity.com)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

![Gameplay Demo](./demo.gif)

A simple yet addictive hyper-casual game prototype built in Unity. The goal is to build the tallest tower possible by tapping the screen at the right moment. This project was created as a hands-on learning exercise.

## Table of contents

- [About The Project](#about-the-project)
- [Gameplay](#gameplay)
- [Key Features](#key-features)
- [Built With](#️built-with)
- [Getting Started](#getting-started)
- [Future Ideas](#future-ideas)

## About The Project

**Tower Stack** is an implementation of a classic game mechanic where player precision and timing are key. Each new block placed can be smaller than the last if not aligned perfectly. The overhanging part is "sliced" off and falls away, making the game progressively harder with each move.

This project was developed as a tutorial to learn and demonstrate fundamental Unity concepts.

## Gameplay

1.  **Watch:** A block moves side-to-side above the tower.
2.  **Tap:** Tap the screen (or click the mouse) to stop the block.
3.  **Stack:** Try to align the block perfectly with the one below it.
4.  **Survive:** The smaller your platform gets, the harder it is to land the next block. Build the highest tower you can!

## Key Features

-   **Procedural Slicing:** Blocks dynamically resize and reposition based on the player's accuracy. The cut-off piece is generated as a separate object with physics.
-   **Singleton `GameManager`:** Centralized management of the game loop, score, object spawning, and the "Game Over" state.
-   **Event-Driven Input:** A clean and scalable input system using a `static event Action` to communicate between the input manager and game objects.
-   **Smooth Camera:** The camera softly follows the tower's height, keeping the action centered on the screen.
-   **Dynamic UI:** A TextMeshPro-based interface displays the current score, as well as a game-over screen with the final score and a restart button.

## Built With

-   **[Unity](https://unity.com/)** (Version 6000.0.53f1)
-   **[C#](https://docs.microsoft.com/en-us/dotnet/csharp/)**
-   **[TextMeshPro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.0/manual/index.html)** for text rendering

## Getting Started

To get a local copy up and running, follow these simple steps:

1.  Clone the repository:
    ```sh
    git clone https://github.com/YourUsername/Tower-Stacker-Unity.git
    ```
2.  Open the project in **Unity Hub** (ensure you have a compatible Unity version installed).
3.  Once the project is loaded, open the main scene located in the `Assets/Scenes/` folder.
4.  Press the **Play** button in the editor.

## Future Ideas

While the core prototype is complete, here are a few ideas for future enhancements:

-  **Color Transitions:** Implement a gradient or random color scheme for the blocks.
-  **Increasing Difficulty:** Gradually increase the movement speed of the blocks.
-  **Combo System:** Award bonus points for consecutive perfect placements.
-  **Sound Effects:** Add audio for clicks, successful stacks, and block falls.
-  **High Score Persistence:** Use `PlayerPrefs` to save the best score between sessions.

