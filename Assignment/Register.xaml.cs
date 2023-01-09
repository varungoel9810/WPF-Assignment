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
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Bttn_Click(object sender , RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Server=GEM-DEV-MISDB\SQLEXPRESS;Database=training_db ,Table = VR1_LR;Integrated Security = True");
                con.Open();
                string add_data = "Insert into [dbo].[user] VALUES(@Email,Email.Text)";
                SqlCommand cmd = new SqlCommand(add_data, con);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Email.Text = "";
                Password.Text = "";
                MainWindow w1 = new MainWindow();
                this.Close();
                w1.Show();
            }
            catch
            {

            }
        }
    }
}
