using System.Collections.Generic;

namespace BrekkenScan.Domain
{
    public class Paginated<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Result { get; set; }
    }
}
