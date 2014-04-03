using System;
using TechTalk.SpecFlow;
using TicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe_Test.StepDefinitions
{
    [Binding]
    public class TicTacToeSteps
    {
        TicTacToeGame _game;
        int intSelectedSquare;
        Table tblSequenceTable;
        string strCurrentResponse;

        [Scope(Tag="StartedGame")]
        [BeforeScenario()]
        public void startedTicTacToeGame()
        {
            _game = new TicTacToeGame();
        }

        [Given(@"a new Tic Tac Toe Game")]
        public void GivenANewTicTacToeGame()
        {
            _game = new TicTacToeGame();
        }
        
        [Given(@"a started Tic Tac Toe Game")]
        public void GivenAStartedTicTacToeGame()
        {
            Assert.AreNotEqual(null, _game);
        }
        
        [Given(@"player X has taken the centre square")]
        public void GivenPlayerXHasTakenTheCentreSquare()
        {
            _game.Turn(5);

            intSelectedSquare = 5;
        }
        
        [When(@"the X player makes a choice")]
        public void WhenTheXPlayerMakesAChoice()
        {
            _game.Turn(2);

            intSelectedSquare = 2;
        }

        [When(@"the players selects the following squares")]
        public void WhenThePlayersSelectsTheFollowingSquares(Table table)
        {
            tblSequenceTable = table;

            foreach (var row in table.Rows)
            {
                int selectedSquare = Convert.ToInt32(row["SquareReference"].ToString());

                _game.Turn(selectedSquare);
            }
        }
        
        [When(@"the X player and the O player do a sequence to draw")]
        public void WhenTheXPlayerAndTheOPlayerDoASequenceToDraw()
        {
            _game.Turn(5);
            _game.Turn(2);
            _game.Turn(9);
            _game.Turn(1);
            _game.Turn(3);
            _game.Turn(6);
            _game.Turn(8);
            _game.Turn(7);
            _game.Turn(4);

        }
       
        
        [When(@"the O player defeats the X player")]
        public void WhenTheOPlayerDefeatsTheXPlayer()
        {
            _game.Turn(5);
            _game.Turn(3);
            _game.Turn(2);
            _game.Turn(6);
            _game.Turn(1);
            _game.Turn(9);
        }
        
        [When(@"the X player defeats the O player in 5 moves")]
        public void WhenTheXPlayerDefeatsTheOPlayerInMoves()
        {
            _game.Turn(5);
            _game.Turn(6);
            _game.Turn(2);
            _game.Turn(3);
            _game.Turn(8);
        }
        
        [When(@"player O attempts to take the centre square")]
        public void WhenPlayerOAttemptsToTakeTheCentreSquare()
        {
            strCurrentResponse = _game.Turn(5);
        }

        [When(@"the players use Sequences (.*) and (.*)")]
        public void WhenThePlayersUseSequencesAnd(string playerX, string playerO)
        {
            string[] arrayPlayerX = playerX.Split(',');
            string[] arrayPlayerO = playerO.Split(',');

            int Count = 1;
            int arrayLength = arrayPlayerO.Length;

            do
            {
                _game.Turn(Convert.ToInt32(arrayPlayerX[Count - 1]));
                _game.Turn(Convert.ToInt32(arrayPlayerO[Count - 1]));

                Count++;
            }
            while (Count <= arrayLength);
        }


        
        [Then(@"the X player's choice is placed in the correct square")]
        public void ThenTheXPlayerSChoiceIsPlacedInTheCorrectSquare()
        {
            string strSquare2 = _game.GetGrid(intSelectedSquare);

            Assert.AreEqual(true, strSquare2.EndsWith("X"),"Output: " + strSquare2.ToString());
        }

        [Then(@"The correct square is selected for the players")]
        public void ThenTheCorrectSquareIsSelectedForThePlayers()
        {
            foreach(var row in tblSequenceTable.Rows)
            {
                string strPlayer = row["Player"].ToString();
                int intSelectedSquare = Convert.ToInt32(row["SquareReference"].ToString());
                string strSquare = _game.GetSquare(intSelectedSquare);
                string strGrid = _game.GetGrid(intSelectedSquare);
                
                Assert.AreEqual(strPlayer, strSquare);
                Assert.AreEqual(true, strSquare.EndsWith(strPlayer), "Output: " + strSquare.ToString());
          
            }
        }
        
        [Then(@"the Result will be a (.*)")]
        public void ThenTheResultWillBeAVictoryToPlayerX(string winner)
        {
            Assert.AreEqual(true, _game.Result().Contains(winner), "Output: " + _game.Result());
        }
        
        
        [Then(@"any further moves will report game over")]
        public void ThenAnyFurtherMovesWillReportGameOver()
        {
            string strReport = _game.Turn(1);

            Assert.AreEqual(true, strReport.Contains("Game Over!"), "Output:" + strReport);

        }
        
        [Then(@"the move will be invalid")]
        public void ThenTheMoveWillBeInvalid()
        {
            Assert.AreEqual(true, strCurrentResponse.Contains(""), "Output: " + strCurrentResponse.ToString());
        }
        
        [Then(@"it is still (.*) player's Turn")]
        public void ThenItIsStillPlayerSTurn(string Player)
        {
            string currentPlayer = _game.CurrentPlayer();

            Assert.AreEqual("O", Player);
        }
    }
}
