using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dema.back.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly IResultadoService _resultadoService;

        public ResultadoController(IResultadoService resultadoService)
        {
            _resultadoService = resultadoService;
        }

        [HttpGet("[action]/{AlunosId}")]
        public IActionResult GetByAlunoId(string AlunosId)
        {
            try
            {
                var _result = _resultadoService.ObterPorAlunoId(Convert.ToInt32(AlunosId));
                return Ok(_result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}