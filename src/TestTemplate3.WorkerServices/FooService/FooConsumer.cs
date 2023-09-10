using System.Threading.Tasks;
using MassTransit;
using TestTemplate3.Core.Events;

namespace TestTemplate3.WorkerServices.FooService
{
    public class FooConsumer : IConsumer<IFooEvent>
    {
        public Task Consume(ConsumeContext<IFooEvent> context) =>
            Task.CompletedTask;
    }
}
