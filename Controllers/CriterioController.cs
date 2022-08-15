using System;
using System.Net;
using dema.back.Services.Interface;
using dema.back.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dema.back.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CriterioController : ControllerBase
    {
        private readonly ICriteriosService _criteriosService;

        public CriterioController(ICriteriosService criteriosService)
        {
            _criteriosService = criteriosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var _result = _criteriosService.Listar();
            return Ok(_result);
        }
    }
}