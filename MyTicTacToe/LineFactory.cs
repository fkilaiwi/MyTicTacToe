using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public static class LineFactory
    {
        public static LineBase Create(IndexInfo index0, IndexInfo index1)
        {
            var sameRow = index0.RowIndex == index1.RowIndex;
            var sameColoumn = index0.ColumnIndex == index1.ColumnIndex;

            if (sameColoumn && sameRow)
            {
                throw new Exception("Lines shouldn't be created between identical points.");
            }
            if (sameColoumn)
            {
                return new VerticalLine(index0, index1);
            }
            else if (sameRow)
            {
                return new HorizantalLine(index0, index1);
            }
            else
            {
                return new DiagonalLine(index0, index1);
            }
        }
    }
}
