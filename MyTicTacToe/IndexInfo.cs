using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public class IndexInfo
    {
        public int Index { get; private set; }

        public int RowIndex {get; private set;}

        public int ColumnIndex {get; private set;}

        public IndexInfo(int index)
        {           
            this.Index = index;
            this.RowIndex = this.Index / Constants.Dimention;
            this.ColumnIndex = this.Index % Constants.Dimention;
        }

        public Point GetPosition(int edgeLength)
        {
            provider = new RatioProvider(edgeLength);

            return new Point(this.GetPositionInAxis(this.ColumnIndex), this.GetPositionInAxis(this.RowIndex));
        }

        private int GetPositionInAxis(int rowOrColumnIndex)
        {
            var positionInAxis = provider.GetPadding();

            positionInAxis += provider.GetSquareLength() / 2;

            positionInAxis += (provider.GetSquareLength() + provider.GetSquareSpacing()) * rowOrColumnIndex;

            return positionInAxis;
        }

        private RatioProvider provider;
    }
}
