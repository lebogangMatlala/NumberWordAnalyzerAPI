using Microsoft.AspNetCore.Mvc;
using NumberWordAnalyzer.Application.Interfaces;
using NumberWordAnalyzer.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class NumberWordAnalyzerController : ControllerBase
{
    private readonly INumberWordAnalyzerService _analyzer;
    private readonly ILogger<NumberWordAnalyzerController> _logger;

    public NumberWordAnalyzerController(INumberWordAnalyzerService analyzer, ILogger<NumberWordAnalyzerController> logger)
    {
        _analyzer = analyzer;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<NumberWordResult> Analyze([FromBody] AnalyzeRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.InputText))
            return BadRequest("InputText cannot be empty.");

        _logger.LogInformation("Received input of length {Length}", request.InputText.Length);

        var result = _analyzer.Analyze(request.InputText);
        return Ok(result);
    }
}
