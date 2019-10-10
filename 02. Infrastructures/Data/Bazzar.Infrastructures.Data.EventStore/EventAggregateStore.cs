using EventStore.ClientAPI;
using Framework.Domain.Data;
using Framework.Domain.Entieis;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Infrastructures.Data.EventStore
{
    public class EventAggregateStore : IAggregateStore
    {
        private readonly IEventStoreConnection _connection;

        public EventAggregateStore(IEventStoreConnection connection)
        {
            _connection = connection;
        }
        public async Task Save<T, TId>(T aggregate) where T : BaseAggregateRoot<TId>
        {
            if (aggregate == null)
                throw new ArgumentNullException(nameof(aggregate));

            var changes = aggregate.GetEvents()
                .Select(@event =>
                    new EventData(
                        eventId: Guid.NewGuid(),
                        type: @event.GetType().Name,
                        isJson: true,
                        data: Serialize(@event),
                        metadata: Serialize(new EventMetadata
                        { ClrType = @event.GetType().AssemblyQualifiedName })
                    ))
                .ToArray();

            if (!changes.Any()) return;

            var streamName = GetStreamName<T, TId>(aggregate);

            await _connection.AppendToStreamAsync(
                streamName,
                aggregate.Version,
                changes);

            aggregate.ClearEvents();
        }

        public async Task<T> Load<T, TId>(TId aggregateId)
            where T : BaseAggregateRoot<TId>
        {
            if (aggregateId == null)
                throw new ArgumentNullException(nameof(aggregateId));

            var stream = GetStreamName<T, TId>(aggregateId);
            var aggregate = (T)Activator.CreateInstance(typeof(T), true);

            var page = await _connection.ReadStreamEventsForwardAsync(
                stream, 0, 1024, false);

            var events = page.Events.Select(resolvedEvent =>
            {
                var meta = JsonConvert.DeserializeObject<EventMetadata>(
                    Encoding.UTF8.GetString(resolvedEvent.Event.Metadata));
                var dataType = Type.GetType(meta.ClrType);
                var jsonData = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
                var data = JsonConvert.DeserializeObject(jsonData, dataType);
                return data;
            }).ToArray();
            //TODo Load Agg By Events
            return aggregate;
        }

        public async Task<bool> Exists<T, TId>(TId aggregateId)
        {
            var stream = GetStreamName<T, TId>(aggregateId);
            var result = await _connection.ReadEventAsync(stream, 1, false);
            return result.Status != EventReadStatus.NoStream;
        }

        private static byte[] Serialize(object data)
            => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

        private static string GetStreamName<T, TId>(TId aggregateId)
            => $"{typeof(T).Name}-{aggregateId.ToString()}";

        private static string GetStreamName<T, TId>(T aggregate)
            where T : BaseAggregateRoot<TId>
            => $"{typeof(T).Name}-{aggregate.Id.ToString()}";


    }
    internal class EventMetadata
    {
        public string ClrType { get; set; }
    }
}
