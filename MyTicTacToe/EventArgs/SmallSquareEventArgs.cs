using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public class SmallSquareEventArgs : EventArgs
    {
        public readonly IndexInfo Index;

        public SmallSquareEventArgs(IndexInfo index)
        {
            this.Index = index;
        }
    }
}