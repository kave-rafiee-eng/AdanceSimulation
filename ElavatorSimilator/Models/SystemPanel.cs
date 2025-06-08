using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElavatorSimilator.Models
{
    public class SystemItem
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }

    public class SystemPanelData
    {
        public string Title { get; set; }
        public List<SystemItem> Items { get; set; } = new List<SystemItem>();
    }
}
