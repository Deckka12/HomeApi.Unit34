using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries {
    public class UpdateRoomQuery {
        public string NewName { get; }
        public int Area { get; }

        public UpdateRoomQuery (string newName = null, int area = 0) {
            NewName = newName;
            Area = area;
        }
    }
}
