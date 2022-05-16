using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauge
{
    public class ModelChartSettiings
    {
        private string tagName = "";
        private int pointNums = 200;//số điểm hiển thị trên trend

        public string TagName {
            get => tagName;
            set
            {
                tagName = value;
            }
        }

        public int PointNums
        {
            get => pointNums;
            set
            {
                pointNums = value;
            }
        }
    }
}
