using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace ApiSolvex.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _clienteService.GetAll()
                );
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _clienteService.Get(id)
                );
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente model)
        {
            return Ok(
                _clienteService.Add(model)
                );
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cliente model)
        {
            return Ok(
                _clienteService.Update(model)
                );
        }
        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _clienteService.Delete(id)
                );
        }
    }
}
