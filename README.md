Description
A Flappy Bird-style runner with added shooter mechanics. Instead of static obstacles, enemies appear on the right side of the screen and shoot horizontally at the player.

Core Mechanics:
- Controls are identical to Flappy Bird
- Enemies spawn on the right and shoot horizontally
- The player can also shoot, but any hit results in game over
- The bird’s bullet flies in the direction it's facing at the moment of the shot
- Game over occurs if:
  The bird touches the ground
  Gets hit by an enemy bullet
  Shoots and hits an enemy
- Enemy bullets remain on screen, even if the enemy is destroyed

Technical Features:
- Object pooling for bullets and enemies using Generics
- Dynamic menu control via keyboard and interactive buttons
