using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Models.Home {
    public class EditRoomRequest {
        public string NewName { get; set; }
        public int Area { get; set; }
    }
}
