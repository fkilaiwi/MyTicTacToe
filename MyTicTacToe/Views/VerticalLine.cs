using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public class VerticalLine : LineBase
    {
        private Point positionPoint;

        public override void UpdateView(int edgeLength)
        {                                      
            this.WidthRequest = ThicknessOfLine;
            this.HeightRequest = GeometryHelpers.GetLineLength(this.FirstIndex.GetPosition(edgeLength), this.SecondIndex.GetPosition(edgeLength));
            this.Rotation = 0;
            this.positionPoint = GeometryHelpers.GetSmallerPoint(this.FirstIndex.GetPosition(edgeLength), this.SecondIndex.GetPosition(edgeLength));        
        }

        public override Point Position
        {
            get
            {
                return this.positionPoint.ShiftXBy(ThicknessOfLine / 2);
            }
        }

        public VerticalLine(IndexInfo index0, IndexInfo index1) : base(index0,index1)
        {

        }        
    }
}