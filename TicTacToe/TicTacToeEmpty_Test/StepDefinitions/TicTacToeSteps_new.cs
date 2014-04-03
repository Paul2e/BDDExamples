using System;
using TechTalk.SpecFlow;
using TicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe_Test.StepDefinitions
{
    [Binding]
    public class TicTacToeSteps
    {
        TicTacToeGame game;
        string currentPlayerinSquare;

        [Given(@"a new Tic Tac Toe Game")]
        public void GivenANewTicTacToeGame()
        {
            game = new TicTacToeGame();
        }
        
        [Given(@"a started Tic Tac Toe Game")]
        public void GivenAStartedTicTacToeGame()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"player X has taken the centre square")]
        public void GivenPlayerXHasTakenTheCentreSquare()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the X player makes a choice")]
        public void WhenTheXPlayerMakesAChoice()
        {
            currentPlayerinSquare = "X";
            game.Turn(5);
        }
        
        [When(@"the players selects the following squares")]
        public void WhenThePlayersSelectsTheFollowingSquares(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the X player and the O player do a sequence to draw")]
        public void WhenTheXPlayerAndTheOPlayerDoASequenceToDraw()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the O player defeats the X player")]
        public void WhenTheOPlayerDefeatsTheXPlayer()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the X player defeats the O player in (.*) moves")]
        public void WhenTheXPlayerDefeatsTheOPlayerInMoves(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"player O attempts to take the centre square")]
        public void WhenPlayerOAttemptsToTakeTheCentreSquare()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the players use Sequences (.*),(.*) and (.*),(.*)")]
        public void WhenThePlayersUseSequencesAnd(Decimal p0, int p1, Decimal p2, int p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the X player's choice is placed in the correct square")]
        public void ThenTheXPlayerSChoiceIsPlacedInTheCorrectSquare()
        {
            string middlesquare = game.GetSquare(5);

            Assert.AreEqual(true,middlesquare.Contains(currentPlayerinSquare),"Output: " + middlesquare);
        }
        
        [Then(@"The correct square is selected for the players")]
        public void ThenTheCorrectSquareIsSelectedForThePlayers()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Result will be a Draw")]
        public void ThenTheResultWillBeADraw()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Result will be a Victory to Player O")]
        public void ThenTheResultWillBeAVictoryToPlayerO()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Result will be a Victory to Player X")]
        public void ThenTheResultWillBeAVictoryToPlayerX()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"any further moves will report game over")]
        public void ThenAnyFurtherMovesWillReportGameOver()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the move will be invalid")]
        public void ThenTheMoveWillBeInvalid()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it is still O player's Turn")]
        public void ThenItIsStillOPlayerSTurn()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
