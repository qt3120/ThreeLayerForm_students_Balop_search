using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeLayerForm.Core
{
    class StudentDAO
    {
        private DBConnection dbConnection = null;
        public StudentDAO()
        {
            dbConnection = new DBConnection("localhost", "students");
        }
        public DataTable searchByName(string name)
        {
            string query = string.Format("select * from Students where Name like @_name");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@_name", SqlDbType.VarChar);
            sqlParameters[0].Value = "%" + name + "%";
            return dbConnection.executeSelectQuery(query, sqlParameters);
        }
        public DataTable searchById(string id)
        {
            string query = "select * from Students where ID = @_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@_id", SqlDbType.VarChar);
            sqlParameters[0].Value = id;
            return dbConnection.executeSelectQuery(query, sqlParameters);
        }
        public List<Students> getStudents() {
            List<Students> list = new List<Students>();

            return list;
        }
    }
}
