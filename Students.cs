using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLayerForm.Core
{
    class Students
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String PhoneNo { get; set; }
        public String FacultyID { get; set; }
        public Students() { }
        public Students(String ID, String Name, 
            String Address, String PhoneNo, String FacultyID) {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.PhoneNo = PhoneNo;
            this.FacultyID = FacultyID;
        }
    }
}
