using System;
using Xamarin.Forms;

namespace MyTicTacToe
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new TicTacToePage ();
		}
	}
}