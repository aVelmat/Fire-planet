# Fire planet

This repository is a strategy game project designed for both game play and AI creation developed on the Unity engine. This project was inspired by the game “the battle of polytopia”

# Description

Here we will look at the main concepts of the game (the game may become more complex in the future):
- <b>Units:</b> In total, the game currently plans to have the following types of units: 
  - <b>Rifleman:</b> Walks one square, sits on the ground, and is able to move on the ground.
  - <b>Modernized Rifleman:</b> Similar to a regular Rifleman, but the attack/defense damage is increased. 
  - <b>Armored Infantry Car:</b> Has more health and damage than a Modernized Rifleman.
  - <b>Jeep:</b> Movement is by 2 squares. Health and damage are the same as the unit “Modernized Rifleman”.
- <b>Cities/Villages:</b> In the game you can capture settlements. To do this, you need to move a unit to an enemy settlement and wait for a turn. Each city has <b>population points</b> and <b>population growth points.</b> Each turn, the number of <b>population growth points</b>increases, and as soon as it <b>reaches a threshold</b>, the city's <b>population point</b> is added and the city's growing. The more <b>population points</b> a city has, the more city profits <b>game currency per turn</b>. Also the more <b>population</b> a city has, the more <b>units</b> it can produce.
- <b>Buildings:</b> The game has a total of 2 types of buildings (in the code a settlement will also have a building type). In order to build a building, you need to pay with in-game currency:
  - <b>Farm:</b> Boosts population growth points.
  - <b>Factory:</b> Gives additional profit every turn.

# Installation

1. Clone the repository into an empty folder: ```https://github.com/New-Storyline/Fire-planet.git```
2. Open the project in unity (recommended version 6000.0.37f1).
3. Check the status of changes: ```git status``` If you have added or changed any files after cloning that should be ignored. If not, check the ```.gitignore``` file and add the correct folders/files to it.
