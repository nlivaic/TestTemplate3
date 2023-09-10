using System.Collections.Generic;
using TestTemplate3.Core.Entities;
using TestTemplate3.Data;

namespace TestTemplate3.Api.Tests.Helpers
{
    public static class Seeder
    {
        public static void Seed(this TestTemplate3DbContext ctx)
        {
            ctx.Foos.AddRange(
                new List<Foo>
                {
                    new ("Text 1"),
                    new ("Text 2"),
                    new ("Text 3")
                });
            ctx.SaveChanges();
        }
    }
}
