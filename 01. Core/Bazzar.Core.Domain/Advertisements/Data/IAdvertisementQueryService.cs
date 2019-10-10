using Bazzar.Core.Domain.Advertisements.Dtoes;
using Bazzar.Core.Domain.Advertisements.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Data
{
    public interface IAdvertisementQueryService
    {
        AdvertisementDetail Query(GetActiveAdvertisement query);
        AdvertisementSummary Query(GetActiveAdvertisementList query);
        AdvertisementSummary Query(GetAdvertisementForSpecificSeller query);
    }
}
