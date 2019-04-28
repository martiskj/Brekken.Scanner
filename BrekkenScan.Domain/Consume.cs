using System;

namespace BrekkenScan.Domain
{
    public class Consume
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Barcode { get; set; }
    }
}
