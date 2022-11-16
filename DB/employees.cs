using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using developedCRUD.DB;
using System.Data.SqlClient;
using System.Data;
using developedCRUD.Referance;
using System.Windows.Forms;

namespace developedCRUD.DB
{
    public class employees
    {
        SqlConnection con = new SqlConnection(connStr.GetConnStr);
        SqlCommand cmd;
        bool result;
        int res;


        // CONNECTION OPEN METHOD
        public void conOpener()
        {
            if (con.State != ConnectionState.Open) con.Open();
        }

        //CONNECTION CLOSE METHOD
        public void conCloser()
        {
            if (con.State != ConnectionState.Closed) con.Close();
        }



        // INSERT METHOD
        public bool Insert(string firstName, string lastName, string address)
        {
            cmd = new SqlCommand("INSERT INTO Customers2 VALUES ('" + firstName + "', '" + lastName + "', '" + address + "')", con);

            try
            {
                conOpener();
                res = cmd.ExecuteNonQuery();
                if (res > 0) result = true;
            }
            catch { throw; }

            finally { conCloser(); }

            return result;
        }

        // UPDATE METHOD
        public bool Update(int id, string firstName, string lastName, string address)
        {
            cmd = new SqlCommand("UPDATE Customers2 SET firstName = '" + firstName + "', lastName = '" + lastName + "', address = '" + address + "' WHERE ID = '" + id + "'", con);

            try
            {
                conOpener();
                res = cmd.ExecuteNonQuery();
                if (res > 0) result = true;
            }
            catch { throw; }

            finally { conCloser(); }

            return result;
        }

        // DELETE METHOD
        public bool Delete(int id)
        {
            cmd = new SqlCommand("DELETE FROM Customers2 WHERE ID = '" + id + "'", con);

            try
            {
                conOpener();
                res = cmd.ExecuteNonQuery();
                if (res > 0) result = true;
            }
            catch { throw; }

            finally { conCloser(); }

            return result;
        }

        // SELECT METHOD
        public List<Employee> GetEmployees()
        {
            cmd = new SqlCommand("SELECT * FROM Customers2", con);
            List<Employee> employees = new List<Employee>();

            try
            {
                conOpener();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employees.Add(new Employee((int)dr[0], dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
                }
            }
            catch { throw; }

            finally { conCloser(); }

            return employees;
        }
    }
}
