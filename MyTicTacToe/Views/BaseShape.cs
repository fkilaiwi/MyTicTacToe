using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public abstract class BaseShape : Label, IBaseItem 
    {
        public Size ItemSize
        {
            get
            {
                return new Size(this.Width, this.Height);
            }
        }

        public abstract void UpdateView(int edgeLength);
        public abstract Point Position { get; }
    }
}
