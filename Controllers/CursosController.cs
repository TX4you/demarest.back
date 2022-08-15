using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace dema.back.Controllers
{
    [Route("api/v1/[controller]")]
       [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursosService _cursosService;

        public CursosController(ICursosService cursosService)
        {
            _cursosService = cursosService;
        }

        [HttpPost]
        public  IActionResult Post(CursosViewModel cursosViewModel)
        {
            try
            {
                 _cursosService.Adicionar(cursosViewModel);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _result = _cursosService.Listar();
            return Ok(_result);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var _result = _cursosService.ObterPorId(Id);

            if (_result == null)
                return NotFound(new { message = "Cursos não encontrado." });

            return Ok(_result);
        }

        [HttpGet("[action]/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            var _result = _cursosService.ObterPorAlunoId(alunoId);

            if (_result == null)
                return NotFound(new { message = "Cursos não encontrado." });

            return Ok(_result);
        }

        // [HttpGet("{alunoId}")]
        // public IActionResult Get(int alunoId)
        // {
        //     var _result = _cursosService.ObterPorAlunoId(alunoId);

        //     if (_result == null)
        //         return NotFound(new { message = "Cursos não encontrado." });

        //     return Ok(_result);
        // }
    }
}