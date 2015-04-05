using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Michal_Sitarczuk_Lab7_Client2
{

    class QuizPanel
    {
        private int questionNbr;
        private string nativeWord="English";
        private string nativeLanguage;
        private string learningLanguage;
        private Label nativeLanguageLabel;
        private Label learningLanguageLabel;
        private TextBox visualNativeWordTextBox;
        private TextBox inputLearningWordTextBox;
        private Panel panel;
        public QuizPanel(int questionNbr, string nativeLanguage, string learningLanguage, string nativeWord)
        {
            this.questionNbr = questionNbr;
            this.nativeLanguage = nativeLanguage;
            this.learningLanguage = learningLanguage;
            this.nativeWord = nativeWord;
            this.panel = new Panel();
            createVisualNativeWordTextBox();
            createInputLearningWordTextBox();
            createNativeLanguageLabel();
            createLearningLanguageLabel();
            createPanelLayoutWithTextBoxes();
        }


        private void createNativeLanguageLabel(){
            this.nativeLanguageLabel = new Label();
            this.nativeLanguageLabel.Text = "Word in "+nativeLanguage;
        }

        private void createLearningLanguageLabel()
        {
            this.learningLanguageLabel = new Label();
            this.learningLanguageLabel.Text = "Enter word in "+learningLanguage;
        }

    
        private void createVisualNativeWordTextBox(){
            visualNativeWordTextBox = new TextBox();
            visualNativeWordTextBox.Name = "wordTextBox" + questionNbr;
            visualNativeWordTextBox.Text = nativeWord + ": ";
            visualNativeWordTextBox.Enabled = false;
        }

        private void createInputLearningWordTextBox() {
            inputLearningWordTextBox = new TextBox();
            inputLearningWordTextBox.Name = "inputWordTextBox" + questionNbr;
        }

        private void createPanelLayoutWithTextBoxes() {
            this.panel.Controls.Add(nativeLanguageLabel);
            this.nativeLanguageLabel.Location = new Point(10, 10);
            this.nativeLanguageLabel.Size = new Size(80, 30);
            
            this.panel.Controls.Add(visualNativeWordTextBox);
            this.visualNativeWordTextBox.Location = new Point(100, 10);
            this.visualNativeWordTextBox.Size = new Size(100, 30);

            this.panel.Controls.Add(learningLanguageLabel);
            this.learningLanguageLabel.Location = new Point(220, 10);
            this.learningLanguageLabel.Size = new Size(80, 30);

            this.panel.Controls.Add(inputLearningWordTextBox);
            this.inputLearningWordTextBox.Location = new Point(310, 10);
            this.inputLearningWordTextBox.Size = new Size(100, 30);

            this.panel.BorderStyle =  BorderStyle.FixedSingle;
        }

        public Panel getPanel() {
            return this.panel;
        }

        public string getNativeWord() {
            return this.nativeWord;
        }

        public int getQuiestionNbr() {
            return this.questionNbr;
        }

        public string getInputLearningWordTextBoxText()
        {
            return this.inputLearningWordTextBox.Text;
        }

    }
}
