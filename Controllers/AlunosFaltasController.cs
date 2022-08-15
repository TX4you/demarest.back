using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dema.back.Controllers
{
    // [Route("[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlunosFaltasController : ControllerBase
    {
        private readonly IAlunosFaltasService _alunosFaltasService;

        public AlunosFaltasController(IAlunosFaltasService alunosFaltasService)
        {
            _alunosFaltasService = alunosFaltasService;
        }

        [HttpPost]
        public IActionResult Post(AlunosFaltasViewModel alunosFaltasViewModel)
        {
            try
            {
                _alunosFaltasService.Adicionar(alunosFaltasViewModel);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var _result = _alunosFaltasService.Listar();
            return Ok(_result);
        }

        [HttpGet("[action]/{alunoId}")]
        public IActionResult GetByAlunoId(string AlunosId)
        {
            try
            {
                var _result = _alunosFaltasService.ObterPorAlunoId(Convert.ToInt32(AlunosId));
                return Ok(_result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpGet("[action]/{CursosId}")]
        public IActionResult GetByCursoId(string CursosId)
        {
            try
            {
                var _result = _alunosFaltasService.ObterPorCursoId(Convert.ToInt32(CursosId));
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
                var _result = _alunosFaltasService.ObterPorAlunoIdCursoId(Convert.ToInt32(AlunosId), Convert.ToInt32(CursosId));
                return Ok(_result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}