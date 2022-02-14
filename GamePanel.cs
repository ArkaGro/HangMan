using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Hang_Man
{
    class GamePanel
    {
        List<BitmapImage> _images;
        List<Button> _buttons;
        GameManager _gameManager;
        List<TextBlock> _fieldChar;
        private string _word;
        private int _counterMiss = 0;
        WordBank _wordBank;
        private readonly MainPage _mainPage;

        public GamePanel(MainPage mainPage, List<BitmapImage> images, GameManager gameManager)
        {
            _mainPage = mainPage;
            _images = images;
            _gameManager = gameManager;
        }
        public void LoadImage(List<BitmapImage> _images) // "LoadImage" Function
        {
            for (int i = 0; i <= 10; i++) 
            {
                var image = new BitmapImage(new Uri(@"ms-appx:/Images/" + i.ToString() + ".png"));  // Loads Images
                _images.Add(image);  // Adds images to List<BitmapImage>
            }
        }
        public void DoWordArea(List<BitmapImage> _images, MainPage mainPage) // "DoWordArea" Function for EASY WORDS
        { 
            _wordBank = new WordBank();

            _counterMiss = 0;
            _word = _wordBank.EasyWords(); // Call to WordBank, "EasyWords()" Function

            CreateKeyBoard();  // Call to Function "CreateKeyBoard()"

            mainPage.imageMiss.Source = _images[0];
            _fieldChar = new List<TextBlock>();
            mainPage.WordArea.Children.Clear();
            for (int i = 0; i < this._word.Length; i++)
            {
                TextBlock textBlock = new TextBlock();
                {
                    textBlock.Text = " _";  //  Fills The Text Block With "Bottom Dash" 
                    _mainPage.Margin = new Thickness(10);
                    _mainPage.FontSize = 50;
                }
                _mainPage.WordArea.Children.Add(textBlock);
                _fieldChar.Add(textBlock);
            }
            _fieldChar[0].Text = this._word[0].ToString();  // First Letter in Word
            _fieldChar[this._word.Length - 1].Text = this._word[this._word.Length - 1].ToString();  // Last Letter in Word
        }
        public void DoWordArea2(List<BitmapImage> _images, MainPage mainPage) // "DoWordArea" Function for HARD WORDS
        {
            _wordBank = new WordBank();

            _counterMiss = 0;
            _word = _wordBank.HardWords();  // Call to WordBank, "HardWords()" Function

            CreateKeyBoard();  // Call to Function "CreateKeyBoard()"

            mainPage.imageMiss.Source = _images[0];
            _fieldChar = new List<TextBlock>();
            mainPage.WordArea.Children.Clear();
            for (int i = 0; i < this._word.Length; i++)
            {
                TextBlock textBlock = new TextBlock();
                {
                    textBlock.Text = " _";  //  Fills The Text Block With "Bottom Dash" 
                    _mainPage.Margin = new Thickness(10);
                    _mainPage.FontSize = 50;
                }
                _mainPage.WordArea.Children.Add(textBlock);
                _fieldChar.Add(textBlock);
            }
            _fieldChar[0].Text = this._word[0].ToString();  // First Letter in Word
            _fieldChar[this._word.Length - 1].Text = this._word[this._word.Length - 1].ToString();  // Last Letter in Word
        }
        private void CreateKeyBoard() // "CreateKeyBoard" Function
        { 
            _buttons = new List<Button>();
            _mainPage.firstRow.Children.Clear();  // Clear "firstRow"
            _mainPage.secondRow.Children.Clear();  // Clear "secondRow"
            _mainPage.thirdRow.Children.Clear();  // Clear "thirdRow"
            for (int i = 65; i < 91; i++)  // Creates KeyBoard  ASCII [A - Z]
            {
                Button button = new Button()
                {    //  Buttons Designing
                    Content = ((char)i).ToString(),  // Which letter it contains
                    FontSize = 55,  
                    Width = 120,  
                    Height = 120,
                    Margin = new Thickness(2)
                };
                button.Click += Button_Click;  // Adds Clicks to Button_Click() Function
                if (i % 65 < 8) _mainPage.firstRow.Children.Add(button);  // Adds Buttons to ""firsRow"
                else if (i % 65 >= 8 && i % 65 < 16) _mainPage.secondRow.Children.Add(button);  // Adds Buttons to ""secondRow"
                else _mainPage.thirdRow.Children.Add(button);  // Adds Buttons to ""thirdRow"
                _buttons.Add(button);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string character = button.Content.ToString();
            bool hit = false;
            for (int i = 1; i < this._word.Length - 1; i++) // Word Without First and Last Letter
            {
                if (this._word[i].ToString().ToLower() == character.ToLower())
                {
                    hit = true;
                    _fieldChar[i].Text = character.ToLower();
                }
            }
            if (hit == false)  // Checks if choose right letter
            {
                _counterMiss += 1;  // Counter Of Not Guessed letters
                _mainPage.imageMiss.Source = _images[_counterMiss]; // Making a Hanged Man picture
            }
            // Lose
            if (_counterMiss == 10)  // If "_countMiss" equals to 10 times not Guessed letters
            {
                _gameManager.CheckIfLost(this, _mainPage, _images); // Call to Game Manager, CheckIfLost() Function;
            }
            // Checks How Many Letters Guessed 
            int count = 0;
            for (int i = 0; i < this._word.Length; i++)
            {
                if (_fieldChar[i].Text != " _") count++; // "count" how many letters guessed
            }
            // Win
            if (count == this._word.Length) // If "count" equals to length of the WORD
            {
                _gameManager.CheckIfWon(this, _mainPage, _images);  // Call to Game Manager, CheckIfWin() Function;
            }
            button.IsEnabled = false;  // Disable KeyBoard 
        }
    }
}
