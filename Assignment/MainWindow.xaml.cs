using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Login_Btt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=GEM-DEV-MISDB\SQLEXPRESS;Database=training_db ,Table = VR1_LR;Integrated Security = True");
                con.Open();
                string add_data = "SELECT * FROM [dbo].[user] where Email = @Email and Password = @PASSWORD";
                SqlCommand cmd = new SqlCommand(add_data, con);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.ExecuteNonQuery();
                int Count = Convert.ToInt32(cmd.ExecuteScalar()); 
                con.Close();
                Email.Text = "";
                Password.Text = "";
                if(Count> 0)
                {
                    dosomething d1 = new dosomething();
                    this.Close();
                    d1.Show();
                }
                else
                {
                    MessageBox.Show("Password or username is not correct");
                }
                
            }
            catch
            {

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register r1 = new Register();
            this.Close();
            r1.Show();
        }
    }
}
