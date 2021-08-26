using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TelDTO
{
    public class TelGetDTO
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public DateTime WarrantyStarting { get; set; }
    }
}
