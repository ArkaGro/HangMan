using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Hang_Man
{
    class GameManager
    {
        List<BitmapImage> _images;
        GamePanel _gamePanel;
        readonly MainPage _mainPage;
        public GameManager(GamePanel gamePanel, MainPage mainPage, List<BitmapImage> images)
        {
            _gamePanel = gamePanel;
            _mainPage = mainPage;
            _images = images;
        }
        public void NewGame(GamePanel _gamePanel, MainPage mainPage, List<BitmapImage> _images)  // "NewGame" Function 
        {
            _gamePanel.DoWordArea(_images, _mainPage);  // Call to GamePanel, DoWordArea() Default == Easy Words
        }
        public void CheckIfLost(GamePanel _gamePanel, MainPage mainPage, List<BitmapImage> _images)  //  "CheckIfLost" Function
        {
            MessageToUserAsync("You Lose");  // Shows message when player loses the game
        }
        public void CheckIfWon(GamePanel _gamePanel, MainPage mainPage, List<BitmapImage> _images)  //  "CheckIfWon" Function
        {
            MessageToUserAsync("You Win");  // Shows message when player wins the game
        }
        private async void MessageToUserAsync(string statement)  
        {
            _gamePanel = new GamePanel(_mainPage, _images, this);

            MessageDialog messageDialog = new MessageDialog("Play Again" , statement);
            await messageDialog.ShowAsync();
            _gamePanel.DoWordArea(_images, _mainPage);  // Calls to GamePanel, DoWordArea() Function == New Game
        }
        public void Easy(GamePanel _gamePanel, MainPage mainPage, List<BitmapImage> _images)  // "Easy" Difficulty Mode
        {
            _gamePanel.DoWordArea(_images, _mainPage);  // Call to GamePanel, DoWordArea() Function == Easy Words
        }
        public void Hard(GamePanel _gamePanel, MainPage mainPage, List<BitmapImage> _images)  // "Hard" Difficulty Mode
        {
            _gamePanel.DoWordArea2(_images, _mainPage); // Call to GamePanel, DoWordArea2() Function == Hard Words
        }
        public void Exit() // "Exit" Application Function
        {
            Environment.Exit(0);
        }
    }
}
