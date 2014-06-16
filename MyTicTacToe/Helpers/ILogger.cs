using System;

namespace MyTicTacToe
{
	public interface ILogger
	{
		void Log(string stringToPrint);
		void Log(string stringToPrint, params object[] parms);
	}
}

