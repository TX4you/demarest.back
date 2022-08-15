using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace dema.back.Controllers
{
    [Route("api/v1/[controller]")]
       [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosService _alunosService;

        public AlunosController(IAlunosService alunosService)
        {
            _alunosService = alunosService;
        }

        [HttpPost]
        public  IActionResult Post(AlunosViewModel alunosViewModel)
        {
            try
            {
                 _alunosService.Adicionar(alunosViewModel);
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
            var _result = _alunosService.Listar();
            return Ok(_result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _result = _alunosService.ObterPorId(id);

            if (_result == null)
                return NotFound(new { message = "Aluno não encontrado." });

            return Ok(_result);
        }
    }
}