using Bazzar.Core.Domain.Advertisements.Events;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.Entieis;
using Framework.Domain.Events;
using Framework.Domain.Exceptions;
using Framework.Tools.Enums;
using System;

namespace Bazzar.Core.Domain.Advertisements.Entities
{
    public class Advertisment : BaseEntity<AdvertismentId>
    {
        #region Fields
        public AdvertismentId Id { get; protected set; }
        public UserId OwnerId { get; protected set; }
        public UserId ApprovedBy { get; protected set; }
        public AdvertismentTitle Title { get; protected set; }
        public AdvertismentText Text { get; protected set; }
        public Price Price { get; protected set; }
        public AdvertismentState State { get; protected set; }
        #endregion

        #region Constructors
        public Advertisment(AdvertismentId id, UserId ownerId)
        {
            HandleEvent(new AdvertismentCreated
            {
                Id = id,
                OwnerId = ownerId
            });
        }
        #endregion

        #region Methods
        public void SetTitle(AdvertismentTitle title)
        {
            Title = title;
            ValidateInvariants();
            Raise(new AdvertismentTitleChanged
            {
                Id = Id,
                Title = title
            });
        }
        public void UpdateText(AdvertismentText text)
        {
            HandleEvent(new AdvertismentTextUpdated
            {
                Id = Id,
                AdvertismentText = text
            });
        }
        public void UpdatePrice(Price price)
        {
            HandleEvent(new AdvertismentPriceUpdated
            {
                Id = Id,
                Price = price
            });
        }
        public void RequestToPublish()
        {
            HandleEvent(new AdvertismentSentForReview
            {
                Id = Id,
            });
        }

        protected override void ValidateInvariants()
        {
            var isValid =
                Id != null &&
                OwnerId != null &&
                (State switch
                {
                    AdvertismentState.ReviewPending =>
                        Title != null
                        && Text != null
                        && Price != null,
                    AdvertismentState.Active =>
                        Title != null
                        && Text != null
                        && Price != null
                        && ApprovedBy != null,
                    _ => true
                });
            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"مقدار تنظیم شده برای آگهی در وضیعت {State.GetDescription()} غیر قابل قبول است");
            }
        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case AdvertismentCreated e:
                    Id = new AdvertismentId(e.Id);
                    OwnerId = new UserId(e.OwnerId);
                    State = AdvertismentState.Inactive;
                    break;
                case AdvertismentPriceUpdated e:
                    Price = new Price(Rial.FromLong( e.Price));
                    break;
                case AdvertismentSentForReview e:
                    State = AdvertismentState.ReviewPending;
                    break;
                case AdvertismentTextUpdated e:
                    Text = new AdvertismentText(e.AdvertismentText);
                    break;
                case AdvertismentTitleChanged e:
                    Title = new AdvertismentTitle(e.Title);
                    break;
                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }
        #endregion

    }
}
