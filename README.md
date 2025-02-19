![image](https://github.com/user-attachments/assets/e75c5b06-a6dc-4630-9f8f-8a3e24ebfccd)

🌍 Available languages:
- 🇬🇧 [English](#fire-planet-eng)
- 🇷🇺 [Русский](#fire-planet-ru)

# Fire planet (ENG)

This repository is a strategy game project designed for both game play and AI creation developed on the Unity engine. This project was inspired by the game “the battle of polytopia”.
The game is currently in development.

## Description

Here we will look at the main concepts of the game (the game may become more complex in the future):
- <b>Units:</b> In total, the game currently plans to have the following types of units: 
  - <b>Rifleman:</b> Walks one square, sits on the ground, and is able to move on the ground.
  - <b>Modernized Rifleman:</b> Similar to a regular Rifleman, but the attack/defense damage is increased. 
  - <b>Armored Infantry Car:</b> Has more health and damage than a Modernized Rifleman.
  - <b>Jeep:</b> Movement is by 2 squares. Health and damage are the same as the unit “Modernized Rifleman”.
- <b>Cities/Villages:</b> In the game you can capture settlements. To do this, you need to move a unit to an enemy settlement and wait for a turn. Each city has a certain amount of (meaning, combat-ready) population and a population growth rate.  Each turn, the city receives population points according to its current population growth rate. The more population a city has, the more units it can produce/heal. Also, each city brings a fixed amount of money per turn.

- <b>Buildings:</b> The game has a total of 2 types of buildings (in the code a settlement will also have a building type). In order to build a building, you need to pay with in-game currency:
  - <b>Farm:</b> Boosts population growth points.
  - <b>Factory:</b> Gives additional profit every turn.

## Installation

1. Clone the repository into an empty folder: ```https://github.com/New-Storyline/Fire-planet.git```
2. Open the project in unity (recommended version 6000.0.37f1).
3. Check the status of changes: ```git status``` If you have added or changed any files after cloning that should be ignored. If not, check the ```.gitignore``` file and add the correct folders/files to it.

# Fire planet (RU)

Этот репозиторий — проект стратегической игры, разработанный на движке Unity, предназначенный как для игрового процесса, так и для создания ИИ. Этот проект был вдохновлен игрой "The Battle of Polytopia".
В данный момент игра находится в разработке.

## Описание

Здесь мы рассмотрим основные концепции игры (в будущем игра может стать сложнее):
- <b>Юниты:</b> В настоящее время в игре планируются следующие типы юнитов:
  - <b>Стрелок:</b> Передвигается на одну клетку, находится на земле и может перемещаться по суше.
  - <b>Модернизированный стрелок:</b> Аналогичен обычному стрелку, но имеет увеличенный урон атаки/защиты.
  - <b>Бронированная машина пехоты:</b> Имеет больше здоровья и урона, чем модернизированный стрелок.
  - <b>Джип:</b> Движется на 2 клетки. Здоровье и урон такие же, как у юнита "Модернизированный стрелок".
- <b>Города/Деревни:</b> В игре можно захватывать поселения. Для этого необходимо переместить юнита в вражеское поселение и подождать ход. У каждого города есть определенное количество (то есть боеспособного) населения и скорость прироста населения. Каждый ход город получает очки населения в соответствии со своей текущей скоростью прироста. Чем больше населения в городе, тем больше юнитов он может производить/лечить. Также каждый город приносит фиксированное количество денег за ход.

- <b>Здания:</b> В игре всего 2 типа зданий (в коде поселение также будет иметь тип здания). Для строительства здания необходимо заплатить внутриигровой валютой:
  - <b>Ферма:</b> Увеличивает прирост населения.
  - <b>Фабрика:</b> Дает дополнительную прибыль каждый ход.

## Установка

1. Клонируйте репозиторий в пустую папку: ```https://github.com/New-Storyline/Fire-planet.git```
2. Откройте проект в Unity (рекомендуемая версия 6000.0.37f1).
3. Проверьте статус изменений: ```git status``` Если после клонирования вы добавили или изменили файлы, которые должны быть проигнорированы, проверьте файл ```.gitignore``` и добавьте в него нужные папки/файлы.
