using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public class RatioProvider
    {
        //I can pass device to this as a constructor
        public RatioProvider(int edgeLength)
        {            
            this.EdgeLength = edgeLength;

            this.SquareLengthRatio = 0.15;
            this.PaddingRatio = this.SquareLengthRatio * 0.4;

            var totalSquareLengthRatio = this.SquareLengthRatio * Constants.Dimention;
            var totalPaddingRatio = this.PaddingRatio * (Constants.Dimention - 1);

            this.SquareSpacingRatio = ( 1.0 - (totalPaddingRatio + totalSquareLengthRatio) ) / (Constants.Dimention - 1.0); 
        }

        public int EdgeLength { get; private set; }

        public double PaddingRatio { get; private set; }
        
        public double SquareLengthRatio { get; private set; }

        public double SquareSpacingRatio { get; private set; }

        public int GetPadding()
        {
            return (int)(this.EdgeLength * this.PaddingRatio);
        }

        public int GetSquareLength()
        {
            return (int)(this.EdgeLength * this.SquareLengthRatio);
        }

        public int GetSquareSpacing()
        {
            return (int)(this.EdgeLength * this.SquareSpacingRatio);
        }
    }
}
