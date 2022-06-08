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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for ucReport.xaml
    /// </summary>
    public partial class ucReport : System.Windows.Controls.UserControl
    {
        public ucReport()
        {
            InitializeComponent();
        }

        private void btnTruyVan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ModelParametters> _data = new List<ModelParametters>();


                if (!string.IsNullOrEmpty(datePickerFormDate.Text) && !string.IsNullOrEmpty(datePickerToDate.Text))
                {
                    DataTable result = DataProvider.Instance.ExecuteQuery($"select * from data where DateTime >= '{Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")}' " +
                        $"and DateTime <= '{Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59")}'");// DbData.Instance.GetAll();

                    if (result != null && result.Rows.Count > 0)
                    {
                        foreach (DataRow item in result.Rows)
                        {
                            _data.Add(new ModelParametters(item));
                        }
                    }

                    //hien thi gridView
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dataGrid1.ItemsSource = _data;
                    }));


                }
                else
                {
                    System.Windows.MessageBox.Show("Chưa chọn khoảng thời gian xuất. Mời chọn lại !", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // A path to export a report.
                string reportPath = "";

                DataTable _data = new DataTable();
                if (!string.IsNullOrEmpty(datePickerFormDate.Text) && !string.IsNullOrEmpty(datePickerToDate.Text))
                {

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel|*.xlsx";
                    saveFileDialog1.Title = "Save an Excel File";
                    saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_Data";
                    saveFileDialog1.ShowDialog();

                    reportPath = saveFileDialog1.FileName;

                    _data = DataProvider.Instance.ExecuteQuery($"select * from data where DateTime >= '{Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")}' " +
                        $"and DateTime <= '{Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59")}'");

                    ReadWriteExcel exportExcel = new ReadWriteExcel();

                    exportExcel.CreateExcelFile(_data, reportPath);
                }
                else
                {
                    System.Windows.MessageBox.Show("Chưa chọn khoảng thời gian xuất. Mời chọn lại !", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
