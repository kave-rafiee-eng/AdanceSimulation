using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElavatorSimilator.Models
{
    // 📁 ButtonInfo.cs
    public class ButtonInfo
    {
        public int Floor { get; set; }
        public int Direction { get; set; } // 0=UP, 1=UP-DOWN, 2=DOWN
        public int Door { get; set; }

        public string Display => Direction switch
        {
            0 => "\u2191", // ↑
            1 => "\u21C5", // ⇅
            2 => "\u2193", // ↓
            _ => "?"
        };
    }
}
