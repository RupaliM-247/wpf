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
using System.Windows.Shapes;



using System.Data;

using System.Data.SqlClient;

using System.Text.RegularExpressions;

namespace GUI2

{

    /// <summary> 

    /// Interaction logic for Registration.xaml 

    /// </summary> 

    public partial class Window1: Window

    {

        public Window1()

        {

            InitializeComponent();

        }



        private void Login_Click(object sender, RoutedEventArgs e)

        {

            Login login = new Login();

            login.Show();

            Close();

        }



        private void reset_Click(object sender, RoutedEventArgs e)

        {

            Reset();

        }



        public void Reset()

        {

            textBoxFirstName.Text = "";

            textBoxLastName.Text = "";

            textBoxEmail.Text = "";

            textBoxPhone.Text = "";

            textBoxUsername.Text = "";

            textBoxOccupation.Text = "";

            passwordBox.Password = "";

           

        }

        private void close_Click(object sender, RoutedEventArgs e)

        {

            Close();

        }



        private void Submit_Click(object sender, RoutedEventArgs e)

        {

            if (textBoxEmail.Text.Length == 0)

            {

                errormessage.Text = "Enter an email.";

                textBoxEmail.Focus();

            }

            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

            {

                errormessage.Text = "Enter a valid email.";

                textBoxEmail.Select(0, textBoxEmail.Text.Length);

                textBoxEmail.Focus();

            }

            else

            {

                string firstname = textBoxFirstName.Text;

                string lastname = textBoxLastName.Text;

                string email = textBoxEmail.Text;

                string phone = textBoxPhone.Text;

                string username = textBoxUsername.Text;

                string occupation = textBoxOccupation.Text;

                string password = passwordBox.Password;

                string securityAnswer = textBoxSecurity.Text;

                if (passwordBox.Password.Length == 0)

                {

                    errormessage.Text = "Enter password.";

                    passwordBox.Focus();

                }



                else

                {

                    errormessage.Text = "";

                    //string address = textBoxAddress.Text;

                    SqlConnection con = new SqlConnection("Data Source=Grad79-HP;Initial Catalog=Asset_Allocation;User ID=sa;Password=sa123;Trusted_Connection=Yes");

                    con.Open();

                    SqlCommand cmd = new SqlCommand("Insert into PERSONAL_INFO (FIRSTNAME,LASTNAME,GENDER,DOB,EMAIL,PHONE_NO,USERNAME,OCCUPATION) values('" + firstname + "','" + lastname + "','" + gender + "','" + dob + "''" + email + "','" + phone + "','" + username + "','" + occupation + "')", con);

                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("Insert into AUTH_TABLE (USERNAME,PASSWORD,SECURITY_QNO,ANS) values('" + username + "','" + password + "','" + securityQues + "','" + securityAnswer + "')", con);

                    cmd1.CommandType = CommandType.Text;

                    cmd1.ExecuteNonQuery();

                    con.Close();

                    errormessage.Text = "You have Registered successfully.";

                    Reset();

                }

            }

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var comboBox = sender as ComboBox;
            int securityQues= comboBox.SelectedIndex;
            //string selectedcmb = comboBox.Items[comboBox.SelectedIndex].ToString();
            //string securityQues = comboBox.SelectedValue.ToString();

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
          
            var calendar = sender as Calendar;

            if (calendar.SelectedDate.HasValue)
            {
                
                DateTime date = calendar.SelectedDate.Value;
                string dob = date.ToShortDateString();
            }
        }
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            string gender = radioButton.Content.ToString();

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

