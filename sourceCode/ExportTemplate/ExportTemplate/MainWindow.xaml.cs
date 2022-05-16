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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExportTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReadWriteExcel excelHelper = new ReadWriteExcel();
        ConvertDataTableToList convertToList = new ConvertDataTableToList();
        ExcelHelperCloseXml ex1 = new ExcelHelperCloseXml();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = excelHelper.ReadExcelSheet1("./Template.xlsx", true, "Config");
            var Src = convertToList.ConvertDataTable<ConfigModel>(dt);
            dataGrid1.ItemsSource = Src;
        }

        private void brnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C1", typeof(string));
            dt.Columns.Add("C2", typeof(string));
            dt.Columns.Add("C3", typeof(string));

            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["C1"] = i;
                dr["C2"] = i + 1;
                dr["C3"] = i + 2;
                dt.Rows.Add(dr);
            }

            excelHelper.ExportTemplate("./sample.xlsx", dt);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            ex1.ExportTemplate("./sample.xlsx", dt);
        }
    }

    public class DataModel
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class ConfigModel
    {
        public string Min { get; set; }
        public string Max { get; set; }
    }
}
