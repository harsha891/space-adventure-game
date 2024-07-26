# space-adventure-game

## Overview

This project is a part of the 08101 Programming I course and focuses on creating a complete game called "Hyperspace Cheese Battle" using C#. The game involves moving players on a board, utilizing dice rolls, and incorporating special "Cheese Power" squares that offer unique gameplay mechanics.

## Game Description

The Hyperspace Cheese Battle is a turn-based game where players navigate a board using dice rolls. The game includes several key features:
- A 2D array representing the game board.
- A 1D array holding player information.
- Player movement determined by dice rolls.
- Special "Cheese Power" squares with unique effects.
- The game ends when a player reaches a specific square.

## Program Structure

The program consists of several methods, each responsible for different aspects of the game:

- **ResetGame()**: Initializes the game board and player information.
- **DiceThrow()**: Returns the value of the next dice throw.
- **PlayerTurn(int playerNo)**: Executes a move for the specified player.
- **ShowStatus()**: Displays the current status of all players.
- **MakeMoves()**: Moves each player on their turn.
- **CheesePowerSquare(int x, int y)**: Checks if a square has Cheese Power.

## Key Features

1. **Game Initialization**
   - The `ResetGame` method sets up the board and player information for a new game.

2. **Player Movement**
   - The `PlayerTurn` method handles the logic for a player's move, including dice rolls and special square effects.

3. **Displaying Game Status**
   - The `ShowStatus` method outputs the position of each player on the board.

4. **Dice Management**
   - Two types of dice are implemented: preset dice values for testing and a random dice using the `Random` class.

5. **Cheese Power Squares**
   - Players landing on a Cheese Power square can either attack another player or get an extra dice roll.

6. **Game End Detection**
   - The game ends when a player reaches the final square, with the `gameOver` variable indicating the end state.

## How to Run

1. Clone the repository.
2. Open the solution in your preferred C# IDE (e.g., Visual Studio).
3. Build and run the project.
4. Follow the prompts to play the game.

## Future Enhancements

- Improve the user interface for better gameplay experience.
- Add more Cheese Power square effects.
- Implement multiplayer functionality over a network.

## Contributing

If you would like to contribute to the project, please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

---

Developed as part of the 08101 Programming I course.