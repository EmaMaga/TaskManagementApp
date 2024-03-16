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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TaskManager {
    public partial class MainWindow : Window
    {
        String StringConnection = "TaskManager.Properties.Settings.Task_ManagerConnectionString";
        SqlConnection DataConnection;
        public MainWindow()
        {
            InitializeComponent();
            String ConnectionStrig = ConfigurationManager.ConnectionStrings[StringConnection].ConnectionString;
            DataConnection = new SqlConnection(ConnectionStrig);
        }

     private void Login_Click(object sender, RoutedEventArgs e)
     {
        String Name = this.UserName.Text;
        String Pass = this.Password.Password;
        if(CheckLogin(Name,Pass)==true)
        {
            MessageBox.Show("Hello");
                

        }
        else
        {
            MessageBox.Show("Error");

        }



     }
    private void Register_Click(object sender, RoutedEventArgs e)
    {
            Register_Frame SingUp = new Register_Frame();
            SingUp.Show();
        }



        private bool CheckLogin(String Name,String Pass)
        {
            String Consulta = $"select Nombre,Pass from Usuario where Nombre='"+Name+"' and Pass='"+Pass+"'";
            String ConnectionStrig = ConfigurationManager.ConnectionStrings[StringConnection].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(ConnectionStrig))
            {
                Connection.Open();
                using(SqlCommand cmd = new SqlCommand(Consulta,Connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    reader.Close();
                }
                Connection.Close();
            }
            
            
        }


    }
}
