using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public class Player
    {
        public Player(char symbol, string playerName)
        {
            this.PlayerSymbol = symbol;
            this.PlayingSquares = new HashSet<PlayingSquare>();
            this.PlayerState = GameState.Placement;
            this.PlayerName = playerName;
        }

        public ISet<PlayingSquare> PlayingSquares { get; private set; }

        public string PlayerName { get; private set; }

        public GameState PlayerState { get; set; } 

        public char PlayerSymbol { get; private set; }

        public bool IsPositionFullFromPlayer(IndexInfo index)
        {
            return this.PlayingSquares.Where(ps => ps.Index == index).Any();
        }

        public bool DidPlayerWin()
        {
            if (this.PlayingSquares.Count() < 3)
            {
                return false;
            }

			var distinctRowIndexCount = this.PlayingSquares.Select(ps => ps.Index.RowIndex).Distinct().Count();
			var distinctColumnIndexCount = this.PlayingSquares.Select(ps => ps.Index.ColumnIndex).Distinct().Count();

			if(distinctRowIndexCount == 1 || distinctColumnIndexCount ==1)
            {
                return true;
            }

			if (HasSquareOnIndex (0) && HasSquareOnIndex (4) && HasSquareOnIndex (8)) 
			{
				return true;
			}

			if (HasSquareOnIndex (2) && HasSquareOnIndex (4) && HasSquareOnIndex (6)) 
			{
				return true;
			}

            return false;
        }

		private IEnumerable<PlayingSquare> SquaresOnIndex (int index)
		{
			return this.PlayingSquares.Where (ps => ps.Index.Index == index);
		}

		public bool HasSquareOnIndex(int index)
		{
			return SquaresOnIndex (index).Any ();
		}
			
        public bool EndRoundAndCheckIfWon()
        {
            if(PlayerState == GameState.Placement)
            {
                if(this.PlayingSquares.Count>= 3)
                {
                    this.PlayerState = GameState.Moving;
                }
            }

            return DidPlayerWin();
        }

		async public void AnimateWin()
		{
			string winString = "WIN";

			var orderedSquares = this.PlayingSquares.OrderBy (ps => ps.Index.Index);

			for (int cycle = 0; cycle < 2; cycle++)
			{
				for (int i = 0; i < 3; i++) {
					var square = orderedSquares.ElementAt (i);
					square.WinngChar = winString [i];

					await square.AnimateWin (cycle == 1);
				}

				if (cycle == 0) {
					await Task.Delay (1500);
				}
			}
		}	
    }
}
