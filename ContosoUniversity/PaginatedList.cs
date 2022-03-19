using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginatedList(IQueryable<T> sourceOfItems, int pageIndex, int pageSize)
        {
            var count = sourceOfItems.Count();

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            var items = sourceOfItems.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            this.AddRange(items);
        }
    }
}
