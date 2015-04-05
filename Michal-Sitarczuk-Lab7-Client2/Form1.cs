using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Michal_Sitarczuk_Lab7_Client2.lab7_serviceRef_MSD;

namespace Michal_Sitarczuk_Lab7_Client2
{
    public partial class Form1 : Form
    {
        public static string studentID; //To store student ID
        net.azurewebsites.lab7mds.WebServicesMultiplatform webs;
        public Form1()
        {
            InitializeComponent();
             webs= new net.azurewebsites.lab7mds.WebServicesMultiplatform();
             string[] comboBoxContent = webs.GetLanguagesList().Where(x => x != null).Select(x => x.ToString()).ToArray();
             addContentToComboBox(comboBox1,comboBoxContent);
             addContentToComboBox(comboBox2, comboBoxContent);
             string[] users = webs.GetAllUsers().Where(x => x != null).Select(x => x.ToString()).ToArray();
             for (int i = 0; i < users.Length;i++ )
             {
                 System.Diagnostics.Debug.Write("\n users["+i+"] == "+users[i]+" \n");
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 7)
            {
                setErrorOperationViewerLabel("Wrong Student ID");
            }
            else
            {
                if (authentication(textBox1.Text) == true)
                {
                    //SIGN IN
                    studentID = "Dino"; //THIS SHOULD BE SET AS PER USER INPUT IF USER EXISTS IN DB
                    string name = "Vahidin Ljaic"; //THIS SHOULD BE FETCHED FROM DB
                    string[] users = webs.GetAllUsers().Where(x => x != null).Select(x => x.ToString()).ToArray();
                    string user = getOneUser(users, textBox1.Text);
                    string[] usersValues = getUsersValues(user);
                    System.Diagnostics.Debug.Write("\n\ntextBox1.Text == " + textBox1.Text + "\n\n");
                    Form2 f2 = new Form2(textBox1.Text, textBox1.Text, this);
                    this.Visible = false;
                    
                    f2.ShowDialog(); // Shows Form2
                }
                else {
                    setErrorOperationViewerLabel("It is the wrong fucking username");
                }

                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (stringValueIsEmpty(textBox2.Text) == true || stringValueIsEmpty(textBox2.Text) == true)
            {
                setErrorOperationViewerLabel("All fields are mandatory - please fill blank spaces");
            }
            else
            {
                webs.RegisterStudent(textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
                //REGISTER (create studentID by adding 3 first letter of name, index from userDB, 3 first letters of surname
            }

        }







        private void setErrorOperationViewerLabel(string errorMessage)
        {
            infoLabel.Text = "Operation Error: " + errorMessage;
            infoLabel.ForeColor = System.Drawing.Color.Red;
        }

        private void setOperationSuccessViewerLabel(string operationMessage)
        {
            infoLabel.Text = "Operation Successfull " + operationMessage;
            infoLabel.ForeColor = System.Drawing.Color.Green;
        }

     

        private Boolean authentication(string username) {
            //localhost.WebServicesMultiplatformSoapClient te = new localhost.WebServicesMultiplatformSoapClient();
            //localhost.webService te = new localhost.webService();
            
            Boolean login =webs.LogIn(textBox1.Text);
            System.Diagnostics.Debug.Write("\n\n\n\n\n\nsBoolen login == " + login + "\n\n\n\n\n\n");
            //
            //WebBrowserSiteBase te = new WebServicesMultiplatformSoapClient;
            if (textBox1.Text!=null &&  login== true)
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void addContentToComboBox(ComboBox box,String[] content) {
            for (int i = 0; i < content.Length; i++)
            {
                box.Items.Add(content[i]);
            }
        }

        private Boolean stringValueIsEmpty(string value) {
            for (int i = 0; i < value.Length; i++)
            {
                System.Diagnostics.Debug.Write("\n\nvalue[" + i + "] == " + value[i] + "\n\n");
            }
            int counter = 0;
            for (int i = 0; i < value.Length;i++ )
            {
                if (value[i].Equals(" ") || value[i].Equals(""))
                {
                    counter++;
                }
            }
            if (counter == value.Length)
            {
                return true;
            }
            else {
                return false;
            }
            
        }

        private string[] getUsersValues(string users) {
            System.Diagnostics.Debug.Write("\n\n\n\n users == " + users + "\n\n\n\n");
            int index=0;
            int separator = 0;
            string[] values = new string[3];
            for (int i = 0; i < users.Length && index < 1 ;i++ )
            {
                if (users[i] == '#' || users[i] == ',')
                {
                    System.Diagnostics.Debug.Write("\n\nvalues["+index+"] = users.Substring("+separator+","+i+"-1);\n\n");
                    values[index] = users.Substring(separator,i);
                    separator = i + 1;
                    index++;
                }
            }
            for (int i = 0; i < values.Length;i++ )
            {
                System.Diagnostics.Debug.Write("\n\nvalues["+i+"] == "+values[i]+"\n\n");
            }
            return values;
        }

        private string getOneUser(string[] users,string username) {
            for (int i = 0; i < users.Length;i++ )
            {
                if(users[i].Contains(username)){
                    return users[i];
                }
            }
            return null;
        }
    }
}
