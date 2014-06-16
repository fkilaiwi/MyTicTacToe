using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyTicTacToe
{
    public static class MyExtensionMethods
    {
        public static Point ShiftBy(this Point point, Point pointToBeShiftedBy)
        {
            var newPoint = new Point(point.X - pointToBeShiftedBy.X, point.Y - pointToBeShiftedBy.Y);
            return newPoint;
        }

        public static Point ShiftBy(this Point point, int xShift, int yShift)
        {
            return ShiftBy(point, new Point(xShift, yShift));
        }

        public static Point ShiftXBy(this Point point, int xShift)
        {
            return ShiftBy(point, xShift, 0);
        }

        public static Point ShiftYBy(this Point point, int yShift)
        {
            return ShiftBy(point, 0, yShift);
        }
    }
}
