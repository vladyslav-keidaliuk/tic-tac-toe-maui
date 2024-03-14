namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private string currentPlayer = "X";
        private string[,] gameBoard = new string[3, 3];

        public MainPage()
        {
            InitializeComponent();
            ResetGame();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button);

            if (gameBoard[row, column] == null)
            {
                button.Text = currentPlayer;
                gameBoard[row, column] = currentPlayer;

                if (CheckForWin(row, column))
                {
                    DisplayAlert("Відомо результати гри! ", $"{currentPlayer} виграв !", "OK");
                    ResetGame();
                }
                else if (isDraw())
                {
                    DisplayAlert("ЙОЙ, а що в нас тут ?", "Нічия!", "OK");
                    ResetGame();
                }
                else
                {
                    currentPlayer = (currentPlayer == "X") ? "O" : "X";
                }
            }
        }

        private bool CheckForWin(int row, int column)
        {
            
            if (gameBoard[row, 0] == currentPlayer &&
                gameBoard[row, 1] == currentPlayer &&
                gameBoard[row, 2] == currentPlayer)
            {
                return true;
            }

            if (gameBoard[0, column] == currentPlayer &&
                gameBoard[1, column] == currentPlayer &&
                gameBoard[2, column] == currentPlayer)
            {
                return true;
            }

            if (row == column &&
                gameBoard[0, 0] == currentPlayer &&
                gameBoard[1, 1] == currentPlayer &&
                gameBoard[2, 2] == currentPlayer)
            {
                return true;
            }
            if (row + column == 2 &&
                gameBoard[0, 2] == currentPlayer &&
                gameBoard[1, 1] == currentPlayer &&
                gameBoard[2, 0] == currentPlayer)
            {
                return true;
            }

            return false;

        }

        private bool isDraw()
        {
            bool isDraw = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == null)
                    {
                        isDraw = false;
                        break;
                    }
                }
            }

            return isDraw;
        }

        private void ResetGame()
        {
            currentPlayer = "X";
            gameBoard = new string[3, 3];
            foreach (var button in GameBoard.Children.OfType<Button>())
            {
                button.Text = "";
            }
        }

        private void ResetGameClicked(object sender, EventArgs e)
        {
            ResetGame();
        }
    }

}
