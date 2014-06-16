using System;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace MyTicTacToe
{
	public class PuzzleView : AbsoluteLayout
    {
		const int NumberOfSquares = 4;

        public IndexInfo[] allIndexes;

		public PuzzleView()
        {
			this.HorizontalOptions = LayoutOptions.Center;
			this.VerticalOptions = LayoutOptions.Center;

            allIndexes = new IndexInfo[Constants.Dimention * Constants.Dimention];

            for (int i = 0; i < allIndexes.Length; i++)
            {
                allIndexes[i] = new IndexInfo(i);
            }

            this.Children.Add(LineFactory.Create(allIndexes[0], allIndexes[1]));
            this.Children.Add(LineFactory.Create(allIndexes[1], allIndexes[2]));
            this.Children.Add(LineFactory.Create(allIndexes[3], allIndexes[4]));
            this.Children.Add(LineFactory.Create(allIndexes[4], allIndexes[5]));
            this.Children.Add(LineFactory.Create(allIndexes[6], allIndexes[7]));
            this.Children.Add(LineFactory.Create(allIndexes[7], allIndexes[8]));

            this.Children.Add(LineFactory.Create(allIndexes[0], allIndexes[3]));
            this.Children.Add(LineFactory.Create(allIndexes[3], allIndexes[6]));
            this.Children.Add(LineFactory.Create(allIndexes[1], allIndexes[4]));
            this.Children.Add(LineFactory.Create(allIndexes[4], allIndexes[7]));
            this.Children.Add(LineFactory.Create(allIndexes[2], allIndexes[5]));
            this.Children.Add(LineFactory.Create(allIndexes[5], allIndexes[8]));

            this.Children.Add(LineFactory.Create(allIndexes[0], allIndexes[4]));
            this.Children.Add(LineFactory.Create(allIndexes[4], allIndexes[8]));

            this.Children.Add(LineFactory.Create(allIndexes[4], allIndexes[2]));
            this.Children.Add(LineFactory.Create(allIndexes[6], allIndexes[4]));

            for (int i = 0; i < allIndexes.Length; i++)
            {
                this.Children.Add(new SmallSquare(allIndexes[i]));
            }

            foreach (var view in this.Children.OfType<LineBase>())
            {
                var tapGestureRecognizer = new TapGestureRecognizer()
                {
                    TappedCallback = (a, b) =>
                    {
                        this.OnLineClicked(new LineClickedEventArgs(view.FirstIndex, view.SecondIndex));
                    }
                };

                view.GestureRecognizers.Add(tapGestureRecognizer);
            }

            foreach (var view in this.Children.OfType<SmallSquare>())
            {
                var tapGestureRecognizer = new TapGestureRecognizer()
                {
                    TappedCallback = (a, b) =>
                    {
                        this.OnSmallSquareClicked(new SmallSquareEventArgs(view.Index));
                    }
                };

                view.GestureRecognizers.Add(tapGestureRecognizer);
            }

            this.PropertyChanged += OnPropertyChanged;
        }

        public void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.ChangeThings();
        }

		public void ChangeThings()
		{
			this.HeightRequest = this.EdgeSize;
			this.WidthRequest = this.EdgeSize;

			if (this.EdgeSize <= 0)
				return;

			var squareSize = this.EdgeSize / NumberOfSquares;


            foreach (var view in this.Children.OfType<BaseShape>())
            {
                var square = view;

                square.UpdateView(this.EdgeSize);

                AbsoluteLayout.SetLayoutBounds(square,
                    new Rectangle(square.Position, square.ItemSize));
            }

            foreach (View view in this.Children.OfType <PlayingSquare>())
            {
                Font font = Font.BoldSystemFontOfSize(0.4 * squareSize);

                PlayingSquare square = (PlayingSquare)view;
                square.Font = font;

                square.UpdateView(this.EdgeSize);

                AbsoluteLayout.SetLayoutBounds(square,
                    new Rectangle(square.Position,
                                  square.ItemSize));
            }
		}

		public static readonly BindableProperty EdgeSizeProperty = BindableProperty.Create<PuzzleView,int>( xc => xc.EdgeSize, default(int));

		public static readonly BindableProperty StackOrientationProperty = BindableProperty.Create<PuzzleView,StackOrientation>( xc => xc.Orientation, StackOrientation.Vertical);

		public int EdgeSize 
		{
			get{ return (int)GetValue (EdgeSizeProperty); }
			set{ SetValue (EdgeSizeProperty, value); }
		}

		public StackOrientation Orientation 
		{
			get{ return (StackOrientation)GetValue (StackOrientationProperty); }
			set{ SetValue (StackOrientationProperty, value); }
		}

        public event EventHandler<LineClickedEventArgs> LineClicked;

        public event EventHandler<SmallSquareEventArgs> SmallSquareClicked;

        public virtual void OnLineClicked(LineClickedEventArgs e)
        {
            var handler = LineClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public virtual void OnSmallSquareClicked(SmallSquareEventArgs e)
        {
            var handler = SmallSquareClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }			

        public PlayingSquare AddPlayingSquare(char ch, IndexInfo index)
        {
            var playingSquare = new PlayingSquare(ch, index);
            this.Children.Add(playingSquare);
            this.ChangeThings();
            return playingSquare;
        }

        public PlayingSquare AddPlayingSquare(char ch, int index)
        {
            return this.AddPlayingSquare(ch, allIndexes[index]);
        }
    }
}
