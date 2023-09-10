using System.Collections.Generic;
using TestTemplate3.Application.Sorting.Models;

namespace TestTemplate3.Application.Sorting
{
    public interface IPropertyMappingService
    {
        IEnumerable<SortCriteria> Resolve(BaseSortable sortableSource, BaseSortable sortableTarget);
    }
}
