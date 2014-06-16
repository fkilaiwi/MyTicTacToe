using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public class LineClickedEventArgs : EventArgs
    {
        public readonly IndexInfo Index0;
        public readonly IndexInfo Index1;

        public LineClickedEventArgs(IndexInfo index0, IndexInfo index1)
        {
            this.Index0 = index0;
            this.Index1 = index1;
        }
    }
}
