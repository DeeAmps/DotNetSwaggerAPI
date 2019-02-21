using OracleHR.Helpers.queries;
using OracleHR.Models.dbModels;
using OracleHR.Repository.conn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleHR.Repository.repo
{
    public class JobRepository
    {
        public static JobRepository Instance = new JobRepository();

        public async Task<List<Job>> GetJobs()
        {
            try
            {
                var results = new List<Job>();
                var getAllJobs = DBQueries.GET_JOBS;
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getAllJobs);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Job
                    {
                        JobId = reader.GetValue(0).ToString(),
                        JobTitle = reader.GetValue(1).ToString(),
                        MinSalary = Convert.ToInt32(reader.GetValue(2)),
                        MaxSalary = Convert.ToInt32(reader.GetValue(3))
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

        public async Task<Job> GetJob(string id)
        {
            try
            {
                var results = new List<Job>();
                var getJobQuery = String.Format(DBQueries.GET_SINGLE_JOB, id);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getJobQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Job
                    {
                        JobId = reader.GetValue(0).ToString(),
                        JobTitle = reader.GetValue(1).ToString(),
                        MinSalary = Convert.ToInt32(reader.GetValue(2)),
                        MaxSalary = Convert.ToInt32(reader.GetValue(3))
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
    }
}
