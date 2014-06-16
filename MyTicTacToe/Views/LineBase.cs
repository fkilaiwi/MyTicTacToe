using System;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public abstract class LineBase : BaseShape
    {
		protected const int ThicknessOfLine = 10;

        public LineBase(IndexInfo index0, IndexInfo index1)
        {
            this.FirstIndex = index0;
            this.SecondIndex = index1;

            this.BackgroundColor = Color.Black;
        }

        public IndexInfo FirstIndex { get; private set; }
        public IndexInfo SecondIndex { get; private set; }
    }
}
