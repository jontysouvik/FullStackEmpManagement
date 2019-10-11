using System.Collections.Generic;
using Npgsql;
using emp_mgmt_api.Models;
using System;
namespace emp_mgmt_api.DataAccess
{
    public class EmployeesDataAccess
    {
         // private string connectionString = "Server=192.168.99.100;User Id=postgres;Password=example;Database=postgres;";
        private string connectionString = "Server=localhost;User Id=postgres;Password=password;Database=empdb;";
        public List<Employee> GetAllEmployees()
        {
            List<Employee> empList = new List<Employee>();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM EMPLOYEE";
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Employee emp = new Employee();
                emp.id = Int32.Parse(dataReader[0].ToString());
                emp.name = dataReader[1].ToString();
                emp.sex = dataReader[2].ToString();
                emp.comments = dataReader[3].ToString();
                empList.Add(emp);
            }
            connection.Close();
            return empList;
        }
        public int SaveEmployee(Employee emp)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO employee (NAME,SEX,COMMENTS)
                                    VALUES ('" + emp.name + "', '" + emp.sex + "','" + emp.comments + "' );";
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }

        public Employee GetEmployeeById(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM EMPLOYEE WHERE ID = " + id.ToString();
            NpgsqlDataReader dataReader = command.ExecuteReader();
            Employee emp = new Employee();
            while (dataReader.Read())
            {
                emp.id = Int32.Parse(dataReader[0].ToString());
                emp.name = dataReader[1].ToString();
                emp.sex = dataReader[2].ToString();
                emp.comments = dataReader[3].ToString();
                break;
            }
            return emp;
        }
        public int UpdateEmployee(int id, Employee emp)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            // UPDATE EMPLOYEE set comments = 'I am Evil' where id = 1;
            command.CommandText = @"UPDATE EMPLOYEE set 
                                    NAME ='" + emp.name + "' ,SEX = '" + emp.sex + "',COMMENTS = '" + emp.comments + "' WHERE id = " + id.ToString();
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }

        public int DeleteEmployee(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM EMPLOYEE WHERE ID = " + id.ToString();
            int i = command.ExecuteNonQuery();
            connection.Close();
            return i;
        }
    }
}
