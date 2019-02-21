using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleHR.Models.dbModels;
using OracleHR.Repository.conn;
using OracleHR.Helpers.queries;

namespace OracleHR.Repository.repo
{
    public class DepartmentRepository
    {
        public static DepartmentRepository Instance = new DepartmentRepository();

        public async Task<Department> GetDepartment(string id)
        {
            try
            {
                var results = new List<Department>();
                var getDepartmentQuery = String.Format(DBQueries.GET_SINGLE_DEPARTMENT, id);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getDepartmentQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Department
                    {
                        DepartmentId = Convert.ToInt32(reader.GetValue(0)),
                        DepartmentName = reader.GetValue(1).ToString(),
                        ManagerId = Convert.ToInt32(reader.GetValue(2)),
                        LocationId = Convert.ToInt32(reader.GetValue(3))
                    });
                }
                con.Close();
                con.Dispose();

                return results.Count > 0 ? results.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Department>> GetDepartments()
        {
            try
            {
                var results = new List<Department>();
                var getAllDepartmentsQuery = DBQueries.GET_DEPARTMENTS;
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getAllDepartmentsQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Department
                    {
                        DepartmentId = Convert.ToInt32(reader.GetValue(0)),
                        DepartmentName = reader.GetValue(1).ToString(),
                        ManagerId = Convert.ToInt32(reader.GetValue(2)),
                        LocationId = Convert.ToInt32(reader.GetValue(3))
                    });
                }
                con.Close();
                con.Dispose();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
