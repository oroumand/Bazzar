using System.ComponentModel;

namespace Bazzar.Core.Domain.Advertisements.Entities
{
    public enum AdvertismentState
    {
        [Description("در انتظار تایید")]
        ReviewPending,
        [Description("فعال")]
        Active,
        [Description("غیرفعال")]
        Inactive,
        [Description("فروخته شده")]
        Sold
    }
}
