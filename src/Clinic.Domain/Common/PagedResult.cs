using System.Collections.Generic;

namespace Clinic.Domain.Common
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Data { get; set; }

        public PagedResult()
        {
            Data = new List<T>();
        }
    }
}