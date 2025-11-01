# ️ 3D Room Explorer (C# + OpenTK)

Room Explorer is a 3D first-person exploration demo built using C# and OpenTK for the Game Engine Foundations course midterm.
It demonstrates understanding of 3D rendering fundamentals, including OpenGL pipeline setup, camera systems, Phong lighting, textures, and basic interactions.

### Overview (Descriptiom)
This gmae renders a 10×10×5 enclosed 3D room with interactive lighting and collision boundries.
The player can freely move using a first-person camera, explore the space, and interact with glowing cubes using a flashlight.

## Gameplay instructions
### Controls
| Key   | Action                                 |
|-------|----------------------------------------|
| WASD  | Move Forward / Left / Backward / Right |
| Mouse | Look Around                            |
| Esc   | Toogle mouse capture (cursor)          |
| E     | Toggle flashlight                      |

### Gameplay
1. Start near the back wall facing the center of the room.
2. Use WASD to move around; move the mouse to look freely.
3. Press E to turn off/on your flashlight (ON BY DEFAULT)
4. Explore the room: you’ll notice one particular cube glow when approaching it.
5. Find the glowing cube. (Win condition to be added)
6. Use ESC to free your mouse and pause the experience if needed.

## Feature List

### 1. Rendering Pipeline

- Proper VAO/VBO/EBO setup
- Shader compilation and uniform management
- Modularized structure for easy extension

### 2. Camera System

- First-person camera (WASD + Mouse look)
- Y-axis locked to eye level (1.5 units)
- Smooth cursor grab/ungrab using ESC

### 3. Environment

- Fully enclosed 10×10×5 room (floor, 4 walls, ceiling)
- Floor and walls textured using Polyhaven assets
- **Collision boundaries** to prevent leaving the room

### 4. Objects

- 3+ cubes placed strategically within the room
- One “target” cube that glows when approached
- Cubes are Phong-lit
- 4 Walls + 1 Floor + 1 Ceiling

### 5. Lighting

- Phong lighting model: Ambient + Diffuse + Specular
- Flashlight spotlight attached to camera (E toggles light)
- Distance-based light attenuation for realism
- Room becomes dim with only ambient light when flashlight is off

### 6. Interactions

- Proximity detection for target cube (glows when close)
- Optional pulse effect based on time uniform
- Ready for win condition trigger (look + press F)

## How to run the project
### Requirements
- .NET 8.0 or later
- OpenTK 4.9 or later
- Windows 10/11 (for System.Drawing Library)

### Run
1. Clone from github.
2. Open in IDE of your choice
3. Build the project
4. Run the project.

## Credits
Textures used from Polyhaven:
1. https://polyhaven.com/a/herringbone_parquet
2. https://polyhaven.com/a/patterned_brick_wall_03


## Future improvements (according to me)
- Add game logic and instructions on screen
- Add multiple rooms or a maze layout so finding the cube is more challangeing
- Implement sound

## Author
Divyesh Bhanvadiya <br>
148647233