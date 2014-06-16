using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public class DiagonalLine : LineBase
    {
        private Point positionPoint;

        public override void UpdateView(int edgeLength)
        {
            this.WidthRequest = GeometryHelpers.GetLineLength(this.FirstIndex.GetPosition(edgeLength), this.SecondIndex.GetPosition(edgeLength));
            this.HeightRequest = ThicknessOfLine;
            this.Rotation = GeometryHelpers.GetDirection(this.FirstIndex.GetPosition(edgeLength), this.SecondIndex.GetPosition(edgeLength)) * 45;
            this.positionPoint = GeometryHelpers.ShifRight(GeometryHelpers.GetMidPoint(this.FirstIndex.GetPosition(edgeLength), this.SecondIndex.GetPosition(edgeLength)), this.WidthRequest/2);                        
        }

        public override Point Position
        {
            get
            {
                return this.positionPoint.ShiftYBy(ThicknessOfLine / 2);
            }
        }

        public DiagonalLine(IndexInfo index0, IndexInfo index1) : base(index0, index1)
        {

        }        
    }
}
