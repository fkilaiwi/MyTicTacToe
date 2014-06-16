using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public class GeometryHelpers
    {
        public static Point GetMidPoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2.0, (p1.Y + p2.Y) / 2.0);
        }

        public static double GetLineLength(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static int GetDirection(Point p1, Point p2)
        {
            var value = (int)((p1.X - p2.X) * (p1.Y - p2.Y));
            return value/Math.Abs(value);
        }

        public static Point ShifRight(Point point, double howMuch)
        {
            return new Point(point.X - howMuch, point.Y);
        }

        public static Point GetSmallerPoint(Point point1, Point point2)
        {
            if (point1.X == point2.X)
            {
                if (point1.Y == point2.Y)
                {
                    throw new Exception("points shoulndt be identical");
                }
                else if (point1.Y > point2.Y)
                {
                    return point2;
                }
                else
                {
                    return point1;
                }                            
            } 
            else if(point1.X > point2.X)
            {
                return point2;
            }
            else
            {
                return point1;
            }                              
        }
    }
}
