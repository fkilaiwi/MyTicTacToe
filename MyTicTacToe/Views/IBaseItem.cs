using System;
using  Xamarin.Forms;

namespace MyTicTacToe
{
    public interface IBaseItem
    {
        Size ItemSize { get; }
        Point Position { get; }
        void UpdateView(int edgeLength);
    }
}
