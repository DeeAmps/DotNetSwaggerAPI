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
    public class LocationRepository
    {
        public static LocationRepository Instance = new LocationRepository();

        public async Task<List<Location>> GetLocations()
        {
            try
            {
                var results = new List<Location>();
                var getAllJobs = DBQueries.GET_LOCATIONS;
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getAllJobs);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Location
                    {
                        LocationId = Convert.ToInt32(reader.GetValue(0)),
                        StreetAddress = reader.GetValue(1).ToString(),
                        PostalCode = reader.GetValue(2).ToString(),
                        City = reader.GetValue(3).ToString(),
                        State = reader.GetValue(1).ToString(),
                        CountryId = reader.GetValue(2).ToString(),
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

        public async Task<Location> GetLocation(int id)
        {
            try
            {
                var results = new List<Location>();
                var getJobQuery = String.Format(DBQueries.GET_SINGLE_LOCATION, id);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getJobQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Location
                    {
                        LocationId = Convert.ToInt32(reader.GetValue(0)),
                        StreetAddress = reader.GetValue(1).ToString(),
                        PostalCode = reader.GetValue(2).ToString(),
                        City = reader.GetValue(3).ToString(),
                        State = reader.GetValue(1).ToString(),
                        CountryId = reader.GetValue(2).ToString(),
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
