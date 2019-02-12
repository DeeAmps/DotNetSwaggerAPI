using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleHR.Models.dbModels;
using Oracle.ManagedDataAccess.Client;
using OracleHR.Repository.conn;
using OracleHR.Helpers.queries;

namespace OracleHR.Repository.repo
{
    
    public class RegionRepository
    {
        public static RegionRepository Instance = new RegionRepository();

        public async Task<List<Region>> GetRegions()
        {
            try
            {
                var results = new List<Region>();
                var getAllRegionsQuery = DBQueries.GET_REGIONS; 
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getAllRegionsQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Region
                    {
                        RegionId = Convert.ToInt32(reader.GetValue(0)),
                        RegionName = reader.GetValue(1).ToString()
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
