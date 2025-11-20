using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NumberWordAnalyzer.Domain.Models;

namespace NumberWordAnalyzer.Application.Interfaces
{
    public interface INumberWordAnalyzerService
    {
        NumberWordResult Analyze(string input);
    }
}

