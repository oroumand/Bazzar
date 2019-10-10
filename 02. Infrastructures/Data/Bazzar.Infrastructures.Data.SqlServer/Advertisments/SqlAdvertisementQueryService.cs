using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Dtoes;
using Bazzar.Core.Domain.Advertisements.Queries;
using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Bazzar.Infrastructures.Data.SqlServer.Advertisments
{
    public class SqlAdvertisementQueryService : IAdvertisementQueryService
    {
        private readonly SqlConnection sqlConnection;

        public SqlAdvertisementQueryService(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        public AdvertisementDetail Query(GetActiveAdvertisement query)
        {
            string sqlQuery = "Select Top 1 a.Id as 'AdvertisementId'," +
                " a.Title,a.Text,p.Location as 'photoUrls', up.DisplayName as 'SellersDisplayName' " +
                " FROM Advertisments a " +
                " Inner Join Picture p on a.Id = p.AdvertismentId " +
                " Inner Join UserProfiles up on a.OwnerId = up.Id" +
                " Where State = 2 and " +
                " a.Id = @AdvertisementId " +
                " Order By p.[Order]";
            return sqlConnection.QuerySingleOrDefault<AdvertisementDetail>(sqlQuery, new { query.AdvertisementId });
        }

        public AdvertisementSummary Query(GetActiveAdvertisementList query)
        {
            throw new NotImplementedException();
        }

        public AdvertisementSummary Query(GetAdvertisementForSpecificSeller query)
        {
            throw new NotImplementedException();
        }
    }
}
