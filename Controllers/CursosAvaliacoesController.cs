using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dema.back.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CursosAvaliacoesController : ControllerBase
    {
        private readonly ICursosAvaliacoesService _cursosAvaliacoesService;

        public CursosAvaliacoesController(ICursosAvaliacoesService cursosAvaliacoesService)
        {
            _cursosAvaliacoesService = cursosAvaliacoesService;
        }

        [HttpPost]
        public IActionResult Post(CursosAvaliacoesViewModel cursosAvaliacoesViewModel)
        {
            try
            {
                _cursosAvaliacoesService.Adicionar(cursosAvaliacoesViewModel);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet("[action]/{alunoId}")]
        public IActionResult GetByAlunoId(string AlunosId)
        {
            try
            {
                var _result = _cursosAvaliacoesService.ObterPorAlunoId(Convert.ToInt32(AlunosId));
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
                var _result = _cursosAvaliacoesService.ObterPorCursoId(Convert.ToInt32(CursosId));
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
                var _result = _cursosAvaliacoesService.ObterPorAlunoIdCursoId(Convert.ToInt32(AlunosId), Convert.ToInt32(CursosId));
                return Ok(_result);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}