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

namespace ExampleMenu.View
{
    /// <summary>
    /// Interaction logic for FirstUC.xaml
    /// </summary>
    public partial class FirstUC : UserControl
    {
        public FirstUC()
        {
            InitializeComponent();
        }

        private void typingTextChanged(object sender, TextChangedEventArgs e)
        {
            bool comparedLetters = getCurrentLetter(typingText.Text.Trim().Length, typingText.Text.Trim(), exampleText.Text.Trim());

            if (!comparedLetters)
            {
                int s1 = typingText.Text.Trim().Length - 1;
                int s2= typingText.Text.Trim().Length;

                if (typingText.Text.Length == 0)
                {
                    typingText.Text.Substring(0, typingText.Text.Trim().Length - 1);
                }
                else {

                    string text = typingText.Text.Substring(0, typingText.Text.Trim().Length - 2);

                    typingText.Text = text; 
                }
            }
        }

        private bool getCurrentLetter(int countOf,string typingText, string text) {

            countOf = countOf - 1; 

            char[] chartsofTypingText = typingText.ToCharArray();

            char[] chartsofExampleText= text.ToCharArray();

            char typingLastLetter = chartsofTypingText[countOf];

            char exampleLastLetter = chartsofExampleText[countOf];

            if (typingLastLetter == exampleLastLetter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
