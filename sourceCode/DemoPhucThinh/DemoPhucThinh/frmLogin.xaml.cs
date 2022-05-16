using System;
using System.Collections.Generic;
using System.Data;
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

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DataTable res = DataProvider.Instance.ExecuteQuery($"select * from useraccount where UserName = '{txtUserName.Text}' and Password ='{txtPassword.Password}';");
            if (res != null && res.Rows.Count > 0)
            {
                VariableGlobal.IsLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác. Mời nhập lại!");
            }
        }
    }
}
