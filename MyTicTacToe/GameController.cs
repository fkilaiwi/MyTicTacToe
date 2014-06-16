using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public enum GameState { Placement, Moving, Ended }
    public enum GameEvent { PlayerGotTurn, Won}

    public class GameController
    {
        Player currentPlayer;

        Player firstPlayer;
        Player secondPlayer;

		private PuzzleView puzzleContent;

		public GameController(PuzzleView puzzleContent, Player player0, Player player1)
        {
            this.puzzleContent = puzzleContent;
            this.puzzleContent.LineClicked += puzzleContent_LineClicked;
            this.puzzleContent.SmallSquareClicked += puzzleContent_SmallSquareClicked;

            this.firstPlayer = player0;
            this.secondPlayer = player1;

            currentPlayer = firstPlayer;
            this.OnGameEventHappened(new GameEventArgs(GameEvent.PlayerGotTurn, firstPlayer));
        }

        void puzzleContent_SmallSquareClicked(object sender, SmallSquareEventArgs e)
        {
            if (currentPlayer.PlayerState == GameState.Placement)
            {
                var square = puzzleContent.AddPlayingSquare(currentPlayer.PlayerSymbol, e.Index);

                this.currentPlayer.PlayingSquares.Add(square);

                EndMove();
            }
        }

		async void puzzleContent_LineClicked(object sender, LineClickedEventArgs e)
        {
            if (currentPlayer.PlayerState == GameState.Moving)
            {
                var squareOnEdge = this.currentPlayer.PlayingSquares.Where(ps => ps.Index == e.Index0 || ps.Index == e.Index1);

                if (squareOnEdge.Count() > 0)
                {
                    IndexInfo otherIndex;

                    if (squareOnEdge.First().Index == e.Index0)
                    {
                        otherIndex = e.Index1;
                    }
                    else
                    {
                        otherIndex = e.Index0;
                    }

                    if (!isPositionFull(otherIndex))
                    {
						var squareToBeMoved = squareOnEdge.First ();
						await squareToBeMoved.MoveSquareTo (otherIndex);

                        EndMove();
                    }
                }
            }
        }

		private void EndMove()
        {
            puzzleContent.ChangeThings();

            if(currentPlayer.EndRoundAndCheckIfWon())
            {
                this.OnGameEventHappened(new GameEventArgs(GameEvent.Won, currentPlayer));


				currentPlayer.AnimateWin ();


                this.firstPlayer.PlayerState = GameState.Ended;
                this.secondPlayer.PlayerState = GameState.Ended;
            }
            else
            {
                changeTurn();
            }
        }

        public void changeTurn()
        {
            if (currentPlayer == firstPlayer)
            {
                currentPlayer = secondPlayer;
                this.OnGameEventHappened(new GameEventArgs(GameEvent.PlayerGotTurn, secondPlayer));
            }
            else
            {
                currentPlayer = firstPlayer;
                this.OnGameEventHappened(new GameEventArgs(GameEvent.PlayerGotTurn, firstPlayer));
            }
        }

        public bool isPositionFull(IndexInfo index)
        {
            return this.firstPlayer.IsPositionFullFromPlayer(index) || this.secondPlayer.IsPositionFullFromPlayer(index);
        }

        public event EventHandler<GameEventArgs> GameEventHappened;

        public virtual void OnGameEventHappened(GameEventArgs e)
        {
            var handler = GameEventHappened;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}