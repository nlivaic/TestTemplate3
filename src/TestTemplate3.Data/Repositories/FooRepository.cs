using TestTemplate3.Core.Entities;
using TestTemplate3.Core.Interfaces;

namespace TestTemplate3.Data.Repositories
{
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public FooRepository(TestTemplate3DbContext context)
            : base(context)
        {
        }
    }
}
