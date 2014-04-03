using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly string[] _grid;
        private int _turn;
        private readonly Dictionary<int, string> _movesTaken = new Dictionary<int, string>();
        private string _winner;

        public TicTacToeGame()
        {
            _grid = new string[9] { "", "", "", "", "", "", "", "", "" };
            InitDictionary();
            _turn = 1;
            _winner = "";
        }

        public string Turn(int location)
        {
            string strReturnString = "";
            if (_turn <= 9)
            {
                    string strCurrentPlayer = CurrentPlayer();
                    if (GetSquare(location) == "")
                    {
                        _grid[location - 1] = strCurrentPlayer;
                        strReturnString = strCurrentPlayer + " in " + _movesTaken[location];
                        Console.WriteLine(strReturnString);
                        CheckWinners();
                        _turn++;
                    }
                    else
                    {
                        strReturnString = _movesTaken[location] + " is not avaliable. \n" + strCurrentPlayer + " to have another go";
                    }
            }
            return strReturnString + "\n\n" + _winner;

        }

        public string Result()
        {
            return _winner;
        }

        private void CheckWinners()
        {
            for (int i = 0; i < 8; i++)
            {
                int a = WinningCombinations[i, 0];
                int b = WinningCombinations[i, 1];
                int c = WinningCombinations[i, 2];

                if (GetSquare(a + 1) == "" || GetSquare(b + 1) == "" || GetSquare(c + 1) == "")
                {
                    _winner = "It's a Draw! Maybe it's best not to play!";
                    continue;
                }

                if (GetSquare(a + 1) == GetSquare(b + 1) && GetSquare(b + 1) == GetSquare(c + 1))
                {
                    _winner = "Game Over!: Victory to Player " + GetSquare(a + 1) + "\nSequence " + _movesTaken[a + 1] + " " + _movesTaken[b + 1] + " " + _movesTaken[c +1];
                    _turn = 100;
                    DrawGrid();
                    break;
                }
            }
        }

        public string DrawGrid()
        {
            return "|" + GetSquare(1) + "|" + GetSquare(2) + "|" + GetSquare(3) + "|\n" + GetSquare(4) + "|" + GetSquare(5) + "|" + GetSquare(6) + "|\n"
                + "|" + GetSquare(7) + "|" + GetSquare(8) + "|" + GetSquare(9) + "|";
        }

        public string GetGrid(int location)
        {
            return _movesTaken[location] + " " + _grid[location - 1].ToString();
        }

        static private readonly int[,] WinningCombinations = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };

        private void InitDictionary()
        {
            _movesTaken.Add(1, "Top Left");
            _movesTaken.Add(2, "Top Middle");
            _movesTaken.Add(3, "Top Right");
            _movesTaken.Add(4, "Middle Left");
            _movesTaken.Add(5, "Center Square");
            _movesTaken.Add(6, "Middle Right");
            _movesTaken.Add(7, "Bottom Left");
            _movesTaken.Add(8, "Bottom Middle");
            _movesTaken.Add(9, "Bottom Right");
        }

        public string CurrentPlayer()
        {
            if (_turn % 2 == 0)
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }

        public string GetSquare(int location)
        {
            return _grid[location - 1].ToString();
        }
    }
}