# COMP2160 Game Development Task 1: The Wizard’s Apprentice
### Student name and ID: [Auston Chang 46291539]

## Topics covered:
* Event-based programming
* Input, Polling & C# Event Delegates
* Movement with Transform
* Prefab instantiation and destruction
* Finite State Machines
* Collision with Trigger Colliders
* Raycasting
* Game Architecture

Your task is to develop a simple 2D top-down action game in the Unity engine (version 2022.3.37f1), where the player must defend their enchanted mushrooms from roaming ghouls by shooting spellbolts. You are expected to implement this game using techniques and standards covered in the lesson materials and researched from reading the Unity Documentation. A completed version of this game is available to play here: 	

https://uncanny-machines.itch.io/the-wizards-apprentice

## Features

Your game should implement the following features, described in detail below. Each feature has an assigned weighting that contributes to your mark. Design decisions such as timings, movement speeds, etc. are all up to you unless specified, but should be implemented to allow change in a designer-friendly way.

| Feature|Weighting|
|--------|---------|
| Player movement|10%|
| Player Aiming|10%|
| Player Spellbolts|10%|
| Basic Ghoul|10%|
| Ghoul Spawning|5%|
| Mushroom States|10%|
| Timer & Level Restart|5%|
| Current Score & High Score|5%|
| User Interface & Camera|5%|
| Ranged Ghoul|5%|
| Ghoul Line-Of-Sight & Obstacles|5%|
| Tech Art|(BONUS)|
| Total|80%|

The ordering of features is also a suggested implementation order – consider beginning at Player movement, and working your way down to the Ranged Ghouls and beyond.

### Player movement
The player controls a mage who moves left, right and up and down at a consistent speed and cannot move outside the edges of the screen. The player’s movement is controlled using a keyboard via two or more of the following inputs:
* W/A/S/D keys
* Arrow Keys
* Numpad (8, 4, 6, 2)

The player is represented using a sprite from the selection in the assignment framework.

### Player aiming
The player’s wand rotates to point towards the mouse position. To help the player aim, a reticle sits at the mouse position. Both the reticle and the wand are represented using a sprite from the selection in the assignment framework. 

### Player Spellbolts
When the player clicks the left mouse button, a spellbolt object spawns at the wand’s position (with some affordances for offset to improve visuals). The spellbolt travels in a straight line at a consistent speed in the direction the player is aiming at the time of clicking.

The spellbolt is destroyed when it reaches the edges of the screen or obstacles (if present in the project). The spellbolt is represented using a sprite from the selection in the assignment framework.

### Basic Ghoul
Ghouls move across the screen at a consistent speed, following a pre-determined path. The path must be made up of two or more waypoints. When ghouls reach the end of the path, they are destroyed. At least two paths, with ghouls that follow them, must be present in the game. Ghouls are destroyed if they collide with a player’s spellbolt.

The ghouls are represented using a sprite from the selection in the assignment framework.

### Ghoul Spawners
Off screen, ghoul spawners create ghouls at a timed interval. At least two spawners must be present, and can have different timed intervals for spawning.

### Mushroom States
The scene features at least two mushrooms that the player must plant, protect and harvest for points. Each mushroom has the following states: Dead, Growing, Fully Grown and Poisoned. The mushrooms start the level in the “Dead” state.

**Dead**<br>
When dead, mushrooms are represented as an empty field. If the player is on the field and presses “Space bar”, a mushroom is planted and the mushroom enters the “Growing” state.

**Growing**<br>
In the “Growing” state, a mushroom sprite is drawn in the mushroom field. The mushroom continuously grows when in this state. If the mushroom reaches its maximum size, it enters the “Fully Grown” state. 

If the mushroom is touched by a ghoul or hit by a ghoul spellbolt, it enters the "Poisoned" state. If the mushroom is hit by the player's spell bolt, it decreases in size by a set amount. If the mushroom shrinks below its minimum size, it enters the "Dead" state.

**Fully Grown**<br>
When “Fully Grown”, the mushroom changes colour and stops growing. If the player touches the mushroom, they get points, and the mushroom enters the “Dead” state. 

If the mushroom is touched or shot by a ghoul, it enters the “Poisoned” state. If the mushroom is hit by the player’s spellbolt, it decreases in size by a set amount and enters the “Growing” state.

**Poisoned**<br>
When “Poisoned”, the mushroom changes colour and continually decreases in size. A poison timer is initially set to X seconds. If the mushroom is touched by a ghoul or hit by a ghoul spellbolt, the poison timer resets to X. 

If the mushroom is hit by the player’s spellbolt, it decreases in size by a set amount. If the poison timer reaches zero, the mushroom enters the “Growing” state. If the mushroom shrinks below its minimum size, it enters the “Dead” state.

The mushroom is represented using a sprite from the selection in the assignment framework.

### Timer & Level Reset
A timer set to a specific time begins counting down at the start of the level. When the timer reaches zero, the level ends and then resets.

### Current Score & High Score
When the level starts, the current score is zero. When the player touches a fully grown mushroom, they gain points which contribute to the current score. The high score represents the highest amount of points the player has received since they began playing the game. The current score is reset when the level is reset. The high score is not reset.

### User interface & Camera
There is a simple UI showing the player’s current score. The UI also shows the highest score they have reached in any game played this session, and the timer. When the timer runs out, a Restart button appears which allows the player to restart the level.

The game should run on a screen with a 16:9 aspect ratio and should scale to any resolution with this ratio (e.g. 1920 x 1080 or 1280 x 720).

### Ranged Ghoul
A different type of ghoul, the ranged ghoul, will also spawn from the ghoul spawners. The ghoul spawners will randomly pick which ghoul to spawn each spawn time. 

The ranged ghoul follows the same behaviour as the basic ghoul. However, when a mushroom is within a specific range of the ranged ghoul, they will shoot a spellbolt towards it, with a set time interval between shots. The ghoul spellbolt travels in a straight line at a consistent speed from where it was spawned towards the mushroom. If the ghoul has multiple mushrooms within range, it will target the nearest one.

A ghoul spellbolt will be destroyed if it reaches the edges of the screen, or if it comes into contact with mushrooms or obstacles (if implemented). 

Both the ranged ghoul and the ghoul spellbolt are represented using a sprite from the selection in the assignment framework.

### Ghoul Line-Of-Sight & Obstacles
Ranged ghouls will only fire at the mushroom if they have a clear line of sight. Line of sight is blocked by obstacle objects that are situated throughout the level. Obstacles are represented using sprites from the selection in the assignment framework.

### Tech Art (Bonus – not marked)
The below tech art features will not be marked, but will help add juice to your game. We recommend giving these a try once you’ve completed the assignment to prepare the work for a portfolio piece. These are:

* Trail renderer components on the player and ghoul spellbolts that show trajectory. The trail renderers do not contribute to collision.
* Line renderer components on the ghoul’s movement paths that link waypoints together.
* Ghouls “bob” up and down slightly when walking to give a better appearance of movement.

## Development Documentation
Your submission should also include a PDF file containing a list of which features you have attempted. Not claiming a feature may result in it not being marked. A template for documentation is provided in this repo in the “Documentation” folder.

Your documentation must also contain an Entity Relationship Diagram (ERD), following the example provided in lectures.

Your documentation must also include any Finite State Machines (FSMs) you have implemented, clearly labelled with what entity they refer to, and the different states, actions and transitions they implement.

## Template project
This Github repo contains a template project for you to build your assignment in. The template project includes a pre-built Scene with some basic level-dressing, which you may alter as much or as little as you like. The project also contains sprites and fonts for you to use in your project. You may not use any additional sprites or fonts. Plugins/scripts provided under the “Resources” tab on iLearn may be used.

## Submission
We will mark the game, code and documentation within this repository. To submit your project, make a final push of this repository with the commit message “Final Submission”. This will indicate to us you are submitting your project and are ready to be marked. No sympathy will be shown if your first commit is minutes before the deadline and something goes wrong in the process. Good version control habits are an important part of game development.
 
Make sure your GitHub account is correctly associated with your student number in GitHub Classroom. Edit this README.md file to include your name and student number at the top, so we know it is your code. Place your completed documentation as a PDF file in the “Documentation” folder in this repository.

Note: We will under no circumstances be marking code submitted to a different repository, via Google Drive, USB stick or any other method. Ensure you are working in this repository and pushing regularly.

## Marking
Implementation of the features above makes up 80% of your grade. The rubric used to mark each feature will be:

|Category|Grade|Criteria|
|--------|--|-------| 
|**Correctness (50%)**|HD (100)|Code is free from any apparent errors, and problems are solved using suitable programming patterns. All appropriate parameters are available in the inspector and are designer-friendly. Feature represents precisely what was asked for in specifications.|
||D (80)|Code has minor errors which do not significantly affect performance. Contains no irrelevant code. Where appropriate, parameters are available in the inspector and are designer-friendly. Feature does not deviate from what was asked for in specifications in any meaningful way.|
||CR (70)|Minor errors that affect performance. Problems are solved in convoluted ways. Contains some irrelevant copied code. Feature may competently resemble what was asked for in specifications, but with some deviations.|
||P (60)|Code is functional but has major flaws. Contains large passages of copied code irrelevant to the problem. Feature resembles what was asked for in specifications, but with prevalent deviations.|
||F (0-40)|Feature is unrecognisable to what is asked for in the specifications or features a game breaking bug.|
||||
|**Clarity (50%)**|HD (100)|Code relevant to this feature has full compliance with the C# Style Guide. Code is easily readable. Well-designed code architecture. All relevant classes appropriately encapsulated.|
||D (80)|Code relevant to this feature demonstrates full compliance with the C# Style Guide with only minor typos. Code is readable with no significant code-smell. Code architecture is adequate.|
||CR (70)|Code relevant to this feature has general compliance with the C# Style Guide, with some minor issues. Code is readable but has some code-smell that needs to be addressed. Code architecture is adequate but could be improved.|
||P (60)|Code relevant to this feature has inconsistent application of C# Style Guide. Significant issues with readability or code-smell. Architecture is difficult to follow.|
||F (0-40)|Significant issues. Inconsistent style. Poor readability with code-smell issues. Messy code architecture with significant encapsulation violations.|

The final 20% of your grade will be determined by your Documentation, marked against the following rubric:


|Category|Grade|Criteria|
|--------|--|-------| 
|Entity Relationship Diagram (50%)|HD (100)|Thorough, detailed and clear ERD, accurately describing all the relevant objects in the game and their relationships.|
||D (80)|A detailed and clear ERD that accurately represents all relevant objects in the game.|
||CR (70)|A clear ERD correctly showing the main objects in your game. Some incompleteness in terms of structure and detail.|
||P (60)|Shows understanding of the ERD format, but significant gaps in the documentation, or discrepancies between document and code.|\
||F (0-40)|ERD is missing or shows little understanding of the format or purpose of ERDs in documentation.|
|||
|Finite State Machines (50%)|HD (100)|FSMs are detailed, clear and accurate and include all implemented FSMs.|
||D (80)|Some incompleteness in terms of detail. FSMs are detailed and accurate, including all implemented FSMs.|
||CR (70)|FSMs correctly communicate the states of objects but may be incomplete or lacking in detail.|
||P (60)|Shows understanding of the FSM format, but significant gaps in the diagrams, or discrepancies between document and code.|
||F(0-40) |FSMs are missing or show little understanding of the format or purpose of documentation.|

## Use of Generative AI
Much like copying code from websites such as Stack Overflow or tutorials, use of code created by someone (or something) else requires a high level of understanding as to what should and shouldn’t be included. As such, we do not generally advise you to use Generative AI when writing code.

With that said, Generative AI can be a useful tool for thinking through problems, debugging written code, or finding alternative explanations to problems. We recognize Generative AI is integrated into many of the tools we use in this unit, including Visual Studio Code. You will not need to declare use of Intellisense or similar in Visual Studio Code. 

However, if you use any other Generative AI tools in your workflow you must declare it by filling out the “Generative AI acknowledgement” table at the end of the documentation template. Failure to fill this out may result in Academic Integrity charges should evidence of Generative AI use be found in your project.
