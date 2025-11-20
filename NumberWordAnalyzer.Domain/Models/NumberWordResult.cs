using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberWordAnalyzer.Domain.Models
{
    public class NumberWordResult
    {
        public Dictionary<string, int> Counts { get; set; } = new();
    }
}

