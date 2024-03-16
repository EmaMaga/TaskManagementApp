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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace TaskManager
{
    /// <summary>
    /// Lógica de interacción para Register_Frame.xaml
    /// </summary>
    public partial class Register_Frame : Window
    {
        WindowStyle style = WindowStyle.ToolWindow;
        public Register_Frame()
        {
            this.WindowStyle = style;
            InitializeComponent();
            String ConnectionString = ConfigurationManager.ConnectionStrings[StringConnection].ConnectionString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Register(this.UserName.Text, this.Password.Password, this.Email.Text);
            }
            catch{
                MessageBox.Show("Error inesperado");
            }

            this.Close();

        }

        private void Register(String Name,String Pass,String Mail)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings[StringConnection].ConnectionString;
            String Consulta = $"insert into Usuario(Nombre,Pass,Correo) values('{Name}','{Pass}','{Mail}');";
            using (DataConnection = new SqlConnection(ConnectionString))
            {
                DataConnection.Open();
                if (this.Password.Password== this.ConPassword.Password){
                    Pass=this.ConPassword.Password;
                    using (SqlCommand cmd = new SqlCommand(Consulta, DataConnection))
                    using (SqlDataReader RD = cmd.ExecuteReader())

                    this.UserName.Clear();
                    this.Email.Clear();
                    this.Password.Clear();
                    this.ConPassword.Clear();
                }
                else
                {
                    MessageBox.Show("The pass must be the same in both Tex Boxes");
                }
                DataConnection.Close();
            }

        }


        String StringConnection = "TaskManager.Properties.Settings.Task_ManagerConnectionString";
        SqlConnection DataConnection;


    }
}
