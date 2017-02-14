using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ADO.NET
{
    public class AdoConnector
    {
        private MySqlConnection _connection = null;
        private string _connectionstring = string.Empty;

        public AdoConnector()
        {
            _connectionstring = ConfigurationManager.AppSettings["mysqlConnection"].ToString();
            _connection = new MySqlConnection(_connectionstring);
        }

        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                return false;
            }         
        }

        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public List<employee> GetAll()
        {
            List<employee> _employeeList = new List<employee>();
            if (this.OpenConnection())
            {
                string query = "Select * from employee";
                MySqlCommand command = new MySqlCommand(query, _connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employee employee = new employee();
                    employee.EmpId = (long)reader["EmpId"];
                    employee.EmpName = reader["EmpName"].ToString();
                    employee.EmpAddress = reader["EmpAddress"].ToString();
                    _employeeList.Add(employee);
                }
                reader.Close();
                this.CloseConnection();
            }
            return _employeeList;
        }
    }

    public class employee
    {
        public long EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
    }
}
