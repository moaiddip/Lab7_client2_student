using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Michal_Sitarczuk_Lab7_Client2
{
    public partial class Form2 : Form
    {
        private int posY=10;
        private int sizeY=40;
        private string userID;
        private string name;
        private int NoQuizes;
        private TextBox nativeLanguage = new TextBox();
        private TextBox learningLanguage = new TextBox();
        
        private Form form;
        private ArrayList quizList = new ArrayList();
        private ArrayList panels = new ArrayList();
          net.azurewebsites.lab7mds.WebServicesMultiplatform webs;
          
        public Form2(string userID, string name, Form form)
        {
            this.form = form;
            this.userID = userID;
            this.name = name;
            webs = new net.azurewebsites.lab7mds.WebServicesMultiplatform();
            System.Diagnostics.Debug.Write("\n\n(webs.getNativeLanguage(" + userID + ") == " + webs.getNativeLanguage(userID) + "\n\n");

            this.nativeLanguage.Text = webs.getNativeLanguage(userID);
            this.learningLanguage.Text = webs.getLearningLanguage(userID);
            this.learningLanguage.Enabled = false;
            this.nativeLanguage.Enabled = false;
            this.Controls.Add(nativeLanguage);
            this.nativeLanguage.Location = new Point(110, 33);
            this.Controls.Add(learningLanguage);
            this.learningLanguage.Location = new Point(360, 33);
            InitializeComponent();
            AddingNewEventArgsWordsToArrayList_TEMPORARY_METHOD();
            addScrollBarToQuizViewPanel();
            addQuizListPanelToForm();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            NoQuizes = webs.getStudentQuizes(userID).Where(x => x != null).Select(x => x.ToString()).ToArray().Length; ;
            if (NoQuizes > 1)
            {
                label1.Text = "Welcome " + name + ". You have " + NoQuizes + " questions awaiting your answer.";
            }
            else if (NoQuizes == 0)
            {
                label1.Text = "Welcome " + name + ". You have no questions awaiting your answer.";
            }
            else
            {
                label1.Text = "Welcome " + name + ". You have " + NoQuizes + " question awaiting your answer.";
            }            
        }

        private void addScrollBarToQuizViewPanel(){
            this.panel1.AutoScroll = true;
            //this.panel1.VerticalScroll.Enabled = true;
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Visible = true;
        }

        private void AddingNewEventArgsWordsToArrayList_TEMPORARY_METHOD(){
            quizList.Add("run"); quizList.Add("hunt"); quizList.Add("watch"); quizList.Add("fight"); quizList.Add("hide");
            quizList.Add("run"); quizList.Add("war"); quizList.Add("mouse"); quizList.Add("screen"); quizList.Add("army");
            quizList.Add("navy"); quizList.Add("air"); quizList.Add("sea"); quizList.Add("land"); quizList.Add("city");
            quizList.Add("country"); quizList.Add("continet"); quizList.Add("village"); quizList.Add("house"); quizList.Add("skyskrape");
            //quizList 
            string[] quizArr = webs.getStudentQuizes(userID).Where(x => x != null).Select(x => x.ToString()).ToArray();
            for (int i = 0; i < quizArr.Length;i++)
            {
                //System.Diagnostics.Debug.Write("\n\nquizArr["+i+"] == "+quizArr[i]" \n\n");
            }

            for (int i = 0; i < quizArr.Length; i++)
            {
                QuizPanel panel = new QuizPanel(i, webs.getNativeLanguage(userID), webs.getLearningLanguage(userID), quizArr[i]);
                panels.Add(panel);
            }
        }

        private void addQuizListPanelToForm() {
            for (int i = 0; i < panels.Count;i++ )
            {
                Panel panel=((QuizPanel)panels[i]).getPanel();
                panel.SetBounds(10, posY, 425, sizeY);
                posY = (posY + sizeY)+10;
                this.panel1.Controls.Add(panel);
            }
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
