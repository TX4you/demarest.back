using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dema.back.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunosCursosController : ControllerBase
    {
        private readonly IAlunosCursosService _alunosCursosService;

        public AlunosCursosController(IAlunosCursosService alunosCursosService)
        {
            _alunosCursosService = alunosCursosService;
        }

        [HttpPost]
        public IActionResult Post(AlunosCursosViewModel alunosCursosViewModel)
        {
            try
            {
                _alunosCursosService.Adicionar(alunosCursosViewModel);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

     [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                 var _result =_alunosCursosService.ObterPorId(Convert.ToInt32(Id));
                 return Ok(_result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("[action]/{AlunosId}/{CursosId}")]
        public IActionResult GetByAlunoIdCursoId(string AlunosId, string CursosId)
        {
            try
            {
                var _result = _alunosCursosService.ObterPorAlunoIdCursoId(Convert.ToInt32(AlunosId), Convert.ToInt32(CursosId));
                return Ok(_result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}