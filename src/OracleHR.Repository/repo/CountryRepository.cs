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
    public class CountryRepository
    {
        public static CountryRepository Instance = new CountryRepository();

        public async Task<List<Country>> GetCountries()
        {
            try
            {
                var results = new List<Country>();
                var getAllCountriesQuery = DBQueries.GET_COUNTRIES;
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getAllCountriesQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Country
                    {
                        CountryId = reader.GetValue(0).ToString(),
                        CountryName = reader.GetValue(1).ToString(),
                        RegionId = Convert.ToInt32(reader.GetValue(2))
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

        public async Task<Country> GetCountry(string id)
        {
            try
            {
                var results = new List<Country>();
                var getCountryQuery = String.Format(DBQueries.GET_SINGLE_COUNTRY, id);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getCountryQuery);
                var reader = connect.reader;
                var con = connect.connection;
                while (await reader.ReadAsync())
                {
                    results.Add(new Country
                    {
                        CountryId = reader.GetValue(0).ToString(),
                        CountryName = reader.GetValue(1).ToString(),
                        RegionId = Convert.ToInt32(reader.GetValue(2))
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
