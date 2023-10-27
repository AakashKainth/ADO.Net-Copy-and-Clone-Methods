using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Copy_Clone_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from employee_tbl";
                SqlDataAdapter sda = new SqlDataAdapter(query,con);
                DataTable employees = new DataTable();
                sda.Fill(employees);


                Console.WriteLine("Original Data Table");
                foreach (DataRow row in employees.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                }

                //DataTable.Copy() returns a DataTable with the structure and data of the DataTable
                DataTable CopyDataTable = employees.Copy();

                Console.WriteLine("Copy Data Table");
                foreach (DataRow row in CopyDataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                }

                //DataTable.Clone() only returns the structure of the DataTable, not the rows or data of the Datable
                DataTable CloneDataTable = employees.Clone();
                Console.WriteLine("Clone Data Table");
                if (CloneDataTable.Rows.Count > 0)
                {
                    
                    foreach (DataRow row in CloneDataTable.Rows)
                    {
                        Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                    }
                }

                else
                {
                    //Console.WriteLine("Rows Not Found");
                    CloneDataTable.Rows.Add(1,"Larifa","Female",25,13000,"Delhi");
                    CloneDataTable.Rows.Add(2, "Jayant", "Male", 26, 19000, "Allahabad");
                }
                foreach (DataRow row in CloneDataTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"] + " " + row["gender"] + " " + row["age"] + " " + row["salary"] + " " + row["city"]);
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}