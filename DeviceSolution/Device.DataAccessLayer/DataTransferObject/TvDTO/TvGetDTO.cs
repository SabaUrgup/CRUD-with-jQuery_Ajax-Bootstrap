using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TvDTO
{
    public class TvGetDTO
    {
        public string Brand { get; set; }
        public double Size { get; set; }
        public DateTime WarrantyStarting { get; set; }
    }
}
