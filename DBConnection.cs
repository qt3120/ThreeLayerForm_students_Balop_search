using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace ThreeLayerForm.Core
{
    class DBConnection
    {
        private SqlConnection sqlConnection = null;
        string connectionString = "";
        
        public DBConnection(string server, string dbStudent){
            this.connectionString = "Data Source=" + server 
                + ";Initial Catalog=" + dbStudent + ";"
                + "Integrated Security=true;";
            this.sqlConnection = this.getConnection();
        }
        public SqlConnection getConnection() {
            try
            {
                sqlConnection = new SqlConnection(this.connectionString);
                return sqlConnection;
            }
            catch (Exception se) {
                MessageBox.Show(se.Message);
                return null;
            }
        }
        public SqlConnection openConnection() { 
            if (this.sqlConnection == null)
            {
                this.sqlConnection = this.getConnection();
                sqlConnection.Open();
                return sqlConnection;
            }
            else
            {
                this.sqlConnection.Open();
                return this.sqlConnection;
            }
        }
        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                if(sqlParameter.Length > 0)
                    myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds, "Students");
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return dataTable;
        }
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }
        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
            }
            return true;
        }
    }
}
