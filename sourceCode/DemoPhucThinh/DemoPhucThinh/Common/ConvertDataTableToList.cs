using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoPhucThinh
{
    public class ConvertDataTableToList
    {
        #region Instance
        private static ConvertDataTableToList _instance;

        public static ConvertDataTableToList Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConvertDataTableToList();
                }
                return _instance;
            }
            private set => _instance = value;
        }
        public ConvertDataTableToList()
        {

        }
        #endregion
        /// <summary>
        /// Convert DataTable to List<Model>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }   
        public BindingList<T> SConvertDataTable<T>(DataTable dt)
        {
            BindingList<T> data = new BindingList<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    object value = dr[column.ColumnName];
                    if (pro.Name == column.ColumnName)
                        if (value == DBNull.Value)
                            value = 0;
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
