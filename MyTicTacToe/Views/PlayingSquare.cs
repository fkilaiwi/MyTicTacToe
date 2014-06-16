using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    public class PlayingSquare : ContentView, IBaseItem
    {
        private Label label;
        private string normText;
        private Point positionPoint;
		private RatioProvider ratioProvider;
		private int edgeLength;

        public PlayingSquare(char symbol, IndexInfo index)
        {
            this.Index = index;
            this.normText = symbol.ToString();

            label = new Label 
            {
                Text = this.normText,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };					

			this.Padding = new Thickness(3);
            this.Content = new Frame
            {
                OutlineColor = Color.Accent,
                Padding = new Thickness(5),
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children = 
                        {
                            label,
                        }
                }
            };

            this.BackgroundColor = Color.Transparent;
        }

        public void UpdateView(int edgeLength)
        {            
			this.edgeLength = edgeLength;
			this.ratioProvider = new RatioProvider(this.edgeLength);
			this.HeightRequest = this.ratioProvider.GetSquareLength();
			this.WidthRequest = this.ratioProvider.GetSquareLength();
			this.positionPoint = GetPositionPointOnIndex(this.Index);
        }

		public Point GetPositionPointOnIndex(IndexInfo index)
		{
			return index.GetPosition(this.edgeLength).ShiftBy(this.ratioProvider.GetSquareLength() / 2, this.ratioProvider.GetSquareLength() / 2);
		}

        public Point Position
        {
            get
            {
                return positionPoint;
            }
        }

        public Size ItemSize
        {
            get
            {
                return new Size(this.Width, this.Height);
            }
        }

		public IndexInfo Index { private set;  get; }

		public char WinngChar { set;  get; }

        public Font Font
        {
            set { label.Font = value; }
        }

		async public Task MoveSquareTo(IndexInfo newPlace)
		{
			var newPositionPoint = GetPositionPointOnIndex (newPlace);

			Rectangle rect = new Rectangle (newPositionPoint, this.ItemSize);

			await this.LayoutTo(rect, 100);

			this.Index = newPlace;
		}

		async public Task AnimateWin(bool isReverse)
		{
			uint length = 200;
			await Task.WhenAll(this.ScaleTo(3, length), this.RotateTo(180, length));
			label.Text = isReverse ? normText : WinngChar.ToString();
			await Task.WhenAll(this.ScaleTo(1, length), this.RotateTo(360, length));
			this.Rotation = 0;
		}
    }
}
