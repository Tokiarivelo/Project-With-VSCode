using System;
using System.Collections.Generic;

namespace GetMaxSum.Controllers
{
    public class GetMaxModel
    {
        public int ObjectNumber { get; set; }
        public List<int> ObjectValues { get; set; }
        public bool IsResult { get; set; }
        public string ResultString { get; set; }
        public string BestChoice { get; set; }
    }
}
