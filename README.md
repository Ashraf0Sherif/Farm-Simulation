# VR Farm Simulator

## Project Overview
The VR Farm Simulator is an interactive virtual reality experience built using Unity. The goal of this project is to create an immersive environment where users can engage in farming activities such as planting, watering, and harvesting crops. The system utilizes the Unity XR Toolkit to provide VR-specific features, enabling users to interact naturally with farm tools and crops using VR controllers.

## Features

### 1. Core Gameplay Mechanics
- **Watering Seeds**: A virtual watering can is available, and users can pick it up and pour water onto seeds to stimulate growth.
- **Harvesting Crops**: Once the crops are fully grown, users can use tools like a harrow to harvest them.
- **Storing Harvested Crops**: After harvesting, users can pick up crops and place them in designated storage boxes.
- **Dynamic Sheep Growth**: Sheep graze on the farm's grass, and as they graze (with eating animations), the sheep themselves grow dynamically over time.

### 2. Tools and Interactions
- **XR Interactions**: The system uses the Unity XR Toolkit for player interaction, enabling grab, drag, and release functionality.
- **Dynamic Growth System**: Crops visibly grow over time in response to player actions like watering.
- **Interactive Tools**: Players can pick up, use, and return farming tools (like watering cans and harvesting tools) using intuitive VR hand controls.

### 3. Environmental Elements
- **Visual Effects**: Watering effects, particle systems, and crop growth animations are included to provide feedback to the player.
- **Spatial Audio**: (e.g., sheep sound).

## Technologies Used
- **Unity**: Primary development environment.
- **C#**: Scripting language used for game logic.
- **Unity XR Toolkit**: Used for VR support and interactive elements.

## Code Structure

### Scripts Overview
- **PlantingSystem.cs**: Handles planting mechanics, seed spawning, and position validation.
- **WateringSystem.cs**: Manages watering interactions and crop growth logic.
- **HarvestingSystem.cs**: Controls the harvesting logic, including object detection and removal of crops.
- **StorageSystem.cs**: Handles interactions related to picking up harvested crops and placing them in storage boxes.
- **SheepGrowthSystem.cs**: Manages sheep movement, grazing logic, eating animations, and dynamic growth of the sheep.
- **XRControllerManager.cs**: Manages the player’s interaction with XR inputs.
- **GrowthController.cs**: Determines crop growth rates and manages state changes.

## Key Methods
- **PlantSeed()**: Instantiates a seed at a specified plot position.
- **WaterCrop()**: Triggers the growth sequence for crops.
- **HarvestCrop()**: Handles logic for detecting and collecting crops.
- **StoreCrop()**: Manages the player's ability to collect harvested crops and place them into storage.
- **GrowSheep()**: Handles the grazing behavior of sheep and manages the dynamic growth of the sheep.

### Note: Detailed explanations of what the scripts do can be found in the folder named "The Scripts".
Media

## Media
A demonstration video showcasing the VR Farm Simulator’s gameplay and features can be found here [Gameplay Video](https://drive.google.com/file/d/1caGI3ELFHO_-nWcIQ-Tjaxu0ztO6VpWU/view?usp=drive_link).

## Team Members:
- [Kareem Dwidar](https://github.com/Kareem06Dwidar)
- [Mohammed Ahmed AbdelFattah](https://github.com/mohameddahmed)
- [Ashraf Sherif](https://github.com/Ashraf0Sherif)
- [Nour El-Deen Osama](https://github.com/Noureldeen75)
- [Eman Ashraf](https://github.com/eman1ashraf)

