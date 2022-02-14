using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hang_Man
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class MainPage : Page
    {
        List<BitmapImage> _images;
        GameManager _gameManager;
        WordBank _wordBank;
        GamePanel _gamePanel;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
            _images = new List<BitmapImage>();
            _wordBank = new WordBank();
            _gameManager = new GameManager(_gamePanel, this, _images );
            _gamePanel = new GamePanel(this, _images, _gameManager);
            LoadImage();
        }
        private void LoadImage()  // "LoadImage" function
        {
            _gamePanel.LoadImage(_images);  // Call to GamePanel, LoadImage() Function
        }
        private void DoWordArea()  // "DoWordArea" fucnction 
        {
            _gamePanel.DoWordArea(_images, this);  // Call to GamePanel, DoWordArea() Function
        }
        private void BT_Click_NewGame(object sender, RoutedEventArgs e)  // "NewGame" Button Fuction
        {
            _gameManager.NewGame(_gamePanel, this, _images);  // Call to GameManager Class, NewGame() Function
        }
        private void BT_Click_Exit(object sender, RoutedEventArgs e)  // "Exit" Button Function
        {
            _gameManager.Exit();  // Call to GameManager Class, Exit() Function
        }
        private void BT_Click_Easy(object sender, RoutedEventArgs e)  // "BT_Click_Easy" Function, To Activate Easy Mode
        {
            _gameManager.Easy(_gamePanel, this, _images);  // Call to GameManager, Easy() Function
        }
        private void BT_Click_Hard(object sender, RoutedEventArgs e)  // "BT_Click_Hard" Function, To Activate Hard Mode
        {
            _gameManager.Hard(_gamePanel, this, _images);  // Call to GameManager, Hard() Function
        }
    }
}
