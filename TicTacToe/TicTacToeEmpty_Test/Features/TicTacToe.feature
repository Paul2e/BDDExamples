Feature: TicTacToe_Empty
	In order to prevent Global Thermo Nuclear War
	As a Living Person
	I want to play a game of Tic-Tac-Toe

Scenario: New Game
	Given a new Tic Tac Toe Game
	When the X player makes a choice
	Then the X player's choice is placed in the correct square

@StartedGame
Scenario: Square Selection
	Given a started Tic Tac Toe Game
	When the players selects the following squares
	| Player | SquareReference |
	| X      | 2               |
	| O      | 1               |
	| X      | 4               |
	| O      | 3               |
	| X      | 5               |
	| O      | 6               |
	| X      | 7               |
	| O      | 8               |
	| X      | 9               |
	Then The correct square is selected for the players
	
Scenario: Full Game with a Draw
	Given a new Tic Tac Toe Game
	When the X player and the O player do a sequence to draw
	Then the result will be a Draw

Scenario: O Player Wins
	Given a new Tic Tac Toe Game
	When the O player defeats the X player
	Then the result will be a Victory to Player O

Scenario: X Player Wins in 5 moves
	Given a new Tic Tac Toe Game
	When the X player defeats the O player in 5 moves
	Then the result will be a Victory to Player X
	And any further moves will report game over

@StartedGame
Scenario: Attempt to use a used square
	Given a started Tic Tac Toe Game
	And player X has taken the centre square
	When player O attempts to take the centre square
	Then the move will be invalid
	And it is still O player's turn
	
Scenario Outline: Winning Sequences
	Given a new Tic Tac Toe Game
	When the players use Sequences <XSequence> and <OSequence>
	Then the result will be a <Result>

Examples:
| XSequence | OSequence | Result              |
| 1,2,3     | 4,7,8     | Victory to Player X |
| 4,5,6     | 1,2,9     | Victory to Player X |
| 7,8,9     | 4,5,3     | Victory to Player X |
| 1,4,7     | 3,5,9     | Victory to Player X |
| 3,6,9     | 2,4,1     | Victory to Player X |
| 1,5,9     | 2,6,8     | Victory to Player X |
| 3,5,7     | 2,6,8     | Victory to Player X |
| 4,7,8     | 1,2,3     | Victory to Player O |
| 1,2,9     | 4,5,6     | Victory to Player O |
| 4,5,3     | 7,8,9     | Victory to Player O |
| 3,5,9     | 1,4,7     | Victory to Player O |
| 2,4,1     | 3,6,9     | Victory to Player O |
| 2,6,8     | 1,5,9     | Victory to Player O |
| 2,6,8     | 3,5,7     | Victory to Player O |