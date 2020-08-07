using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tulpep.NotificationWindow; 

namespace ExampleMenu.View
{
    /// <summary>
    /// Interaction logic for FirstUC.xaml
    /// </summary>
    public partial class FirstUC : UserControl
    {
        public bool spaceButtonClicked = false; 
        private PopupNotifier popUp = null; 
        public FirstUC()
        {
            InitializeComponent();
        }

        //сравнить два текста, при изменени текста в поле ввода
        private void typingTextChanged(object sender, TextChangedEventArgs e)
        {
            string typingText = this.typingText.Text.Trim().Replace(" ","|");
            string sampleText = this.exampleText.Text.Trim().Replace(" ", "|");

            if (!getCurrentLetter(typingText.Length, typingText, sampleText))
            {
                popUp = new PopupNotifier();
                popUp.ContentText = "Неправильный ввод";
                popUp.Popup();
            }
            else
            {
                char nextLetterToShow = nextLetter(typingText, sampleText);

                if (nextLetterToShow.ToString() != "|")
                {
                    popUp = new PopupNotifier();
                    popUp.ContentText = nextLetterToShow.ToString();
                    popUp.Popup();
                }
                else if(nextLetterToShow.ToString() == "|") {
                    this.typingText.Text = this.typingText.Text + "|"; 
                    popUp = new PopupNotifier();
                    popUp.ContentText ="Нажмите пробел";
                    popUp.Popup();
                }
            }
        }


        //**сравнить строку с входящим текстом **/
        private bool getCurrentLetter(int typingTextLenght,string typingText, string text) {

            if (spaceButtonClicked == true) {
                typingText = typingText + "|"; 
            }
            typingTextLenght = typingTextLenght - 1; 

            char[] chartsOfTypingText = typingText.ToCharArray();

            char[] chartsOfExampleText = text.ToCharArray();

            char typingLastLetter = chartsOfTypingText[typingTextLenght];

            char exampleLastLetter = chartsOfExampleText[typingTextLenght];

            if (typingLastLetter == exampleLastLetter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //*определить следующюю букву по тексту
        private char nextLetter(string typedText,string stringText) {

            if (typedText.Substring(0, typedText.Length) == stringText.Substring(0, typedText.Length))
            {
                char[] letter = stringText.ToArray();
                char toTypingLetter = letter[typedText.Length];
                return toTypingLetter;
            }
            return '*'; 
        }

        private void keyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                spaceButtonClicked = true;
            }
            else {
                spaceButtonClicked = false; 
            }
        }
    }
}
