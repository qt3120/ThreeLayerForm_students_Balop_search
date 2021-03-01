using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLayerForm.Core
{
    class StudentBUS
    {
        private StudentDAO studentDAO;
        public StudentBUS()
        {
            studentDAO = new StudentDAO();
        }
        public Students getStudentByID(string id) {
            Students s = new Students();
            DataTable table = studentDAO.searchById(id);
            if (table.Rows.Count < 1)
                return null;
            foreach (DataRow dr in table.Rows)
            {
                s.ID = dr["ID"].ToString();
                s.Name = dr["Name"].ToString();
                s.Address = dr["Address"].ToString();
                s.FacultyID = dr["FacultyID"].ToString();
            }
            return s;
        }
        public DataTable getStudentByName(string name) {
            DataTable table = studentDAO.searchByName(name);
            return table;
        }
    }
}
