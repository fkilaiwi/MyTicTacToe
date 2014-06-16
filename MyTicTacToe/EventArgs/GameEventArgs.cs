using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicTacToe
{
    public class GameEventArgs : EventArgs
    {
        public readonly GameEvent GameEvent;
        public readonly Player Player;

        public GameEventArgs(GameEvent gameEvent, Player palyer)
        {
            this.GameEvent = gameEvent;
            this.Player = palyer;
        }
    }
}
