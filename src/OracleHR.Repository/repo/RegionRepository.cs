using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OracleHR.Models.dbModels;
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

        public async Task<Region> GetRegion(int id)
        {
            try
            {
                var results = new List<Region>();
                var getRegionQuery = String.Format(DBQueries.GET_SINGLE_REGION, id);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(getRegionQuery);
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
                
                return results.Count > 0 ? results.FirstOrDefault() : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Region> UpdateRegion(Region region, int regionId)
        {
            var RegionUpdateQuery = String.Format(DBQueries.UPDATE_REGION, regionId, region.RegionName);
            var connect = await DBConnect.Instance.ConnectAndReturnReader(RegionUpdateQuery);
            var con = connect.connection;
            con.Close();
            con.Dispose();
            var confirmInsert = await GetRegion(regionId);
            if (confirmInsert.RegionName == region.RegionName)
            {
                return confirmInsert;
            }
            return new Region { RegionId = 0, RegionName = "" };
        }

        public async Task<Region> AddNewRegion(Region region)
        {
            try
            {
                int regionLastId = await GetRegionLastId();
                int insertId = regionLastId + 1;
                var RegionInsertQuery = String.Format(DBQueries.INSERT_NEW_REGION, insertId, region.RegionName);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(RegionInsertQuery);
                var con = connect.connection;
                con.Close();
                con.Dispose();
                var confirmInsert = await GetRegion(insertId);
                if (confirmInsert.RegionId == insertId)
                {
                    return new Region { RegionId = insertId , RegionName = region.RegionName};
                    
                }
                return new Region { RegionId = 0, RegionName = "" };
                
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<int> DeleteRegion(int regionId)
        {
            try
            {
                var confirmRegionExists = GetRegion(regionId);
                if (confirmRegionExists == null)
                {
                    return 0;
                }
                var RegionDeleteQuery = String.Format(DBQueries.REMOVE_REGION, regionId);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(RegionDeleteQuery);
                var con = connect.connection;
                con.Close();
                con.Dispose();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private async Task<int> GetRegionLastId()
        {
            try
            {
                var RegionLastInsertQuery = String.Format(DBQueries.GET_LAST_REGION_ID);
                var connect = await DBConnect.Instance.ConnectAndReturnReader(RegionLastInsertQuery);
                var reader = connect.reader;
                var con = connect.connection;
                int lastId = await reader.GetFieldValueAsync<int>(0);
                con.Close();
                con.Dispose();
                return lastId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
