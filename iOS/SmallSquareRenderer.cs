using System;
using Xamarin.Forms;
using MyTicTacToe;
using MyTicTacToe.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;

[assembly: ExportRendererAttribute(typeof(SmallSquare), typeof(SmallSquareRenderer))]
namespace MyTicTacToe.iOS
{
	public class SmallSquareRenderer : LabelRenderer
	{
		protected override void OnModelSet(VisualElement model)
		{
			base.OnModelSet(model);

			var label = this.NativeView;

			label.BackgroundColor = UIColor.Blue;

			label.Layer.CornerRadius = SmallSquare.SquareEdge / 2; 
		}
	}
}