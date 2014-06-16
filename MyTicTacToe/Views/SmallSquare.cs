using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyTicTacToe
{
    public class SmallSquare : BaseShape
    {
		public const int SquareEdge = 30;
        private Point positionPoint;

        public SmallSquare(IndexInfo index)
        {
            this.Index = index;
            this.BackgroundColor = Color.Black;
            this.WidthRequest = SquareEdge;
            this.HeightRequest = SquareEdge;
        }

        public IndexInfo Index { get; private set; }
        
        public override Point Position
        {
            get
            {
                return this.positionPoint;
            }
        }

        public override void UpdateView(int edgeLength)
        {
            this.positionPoint = this.Index.GetPosition(edgeLength).ShiftBy(SquareEdge / 2, SquareEdge / 2);
        }
    }
}
