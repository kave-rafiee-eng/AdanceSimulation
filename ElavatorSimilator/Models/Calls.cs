using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElavatorSimilator.Models
{

    public class Call
    {
        public int advance { get; set; }
        public string From { get; set; }
        public int Floor { get; set; }
        public string door1 { get; set; }
        public string door2 { get; set; }
        public string door3 { get; set; }
        public string dir { get; set; }
        public int Timer { get; set; }
    }
}
