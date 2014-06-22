using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTicTacToe
{
    class TicTacToePage : ContentPage
    {
        StackLayout stackLayout;
		PuzzleView puzzleContent;
        Button randomizeButton;
		Label gameEventLabel;
        
        public TicTacToePage()
        {
			puzzleContent = new PuzzleView();

			var player0 = new Player('X', "Player1");
			var player1 = new Player('O', "Player2");

            var gameController = new GameController(puzzleContent, player0, player1);

			gameController.GameEventHappened += (o, e) =>{
			
				string stringToShow = string.Empty;

				switch (e.GameEvent)
				{
					case GameEvent.PlayerGotTurn:
						if(e.Player.PlayerState == GameState.Placement)
						{
						stringToShow = e.Player.PlayerName + " : Your Turn, Place your playing Square.";
						}
						else if (e.Player.PlayerState == GameState.Moving)
						{
						stringToShow = e.Player.PlayerName + " : Your Turn, Move a square to form a line.";
						}
						break;

					case GameEvent.Won: 
					stringToShow  = e.Player.PlayerName + ", You Win !!";
						break;
				}

				this.gameEventLabel.Text = stringToShow;
            };

            randomizeButton = new Button 
            {
				Text = "Reset Game",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            randomizeButton.Clicked += (o, e) =>
            {
                throw new NotImplementedException("Game Reset is not implemented.");
            };

			var gameDescriptionLabel = new Label {
				Text = "Place your playing square by pressing on one of the black squares. After you place your 3 squares, you can move squares by tapping on the Line between black squares. You win when you have a line.",
				Font = Font.BoldSystemFontOfSize(NamedSize.Small),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			gameEventLabel = new Label
            {
                Text = "YES",
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            stackLayout = new StackLayout
            {
                Children = 
                {
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = 
                        {
                            randomizeButton,
							gameEventLabel,
							gameDescriptionLabel
                        }
                    },
                    puzzleContent
                }
            };
            
            stackLayout.SizeChanged += OnStackSizeChanged;

            this.Padding = 
                new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
            this.Content = stackLayout;
        }

        void OnStackSizeChanged(object sender, EventArgs args)
        {
            stackLayout.Orientation = puzzleContent.Orientation = (stackLayout.Width < stackLayout.Height) ? StackOrientation.Vertical : StackOrientation.Horizontal;

            puzzleContent.EdgeSize = (int)Math.Min(stackLayout.Width, stackLayout.Height);
        }
    }
}