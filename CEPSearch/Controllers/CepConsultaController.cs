using CEPSearch.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CEPSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepConsultaController : ControllerBase
    {
        private readonly ICepConsultaRequestService _cepConsultaRequestService;
        public CepConsultaController(ICepConsultaRequestService cepConsultaRequestService)
        {
            _cepConsultaRequestService = cepConsultaRequestService;
        }

        /// <summary>
        /// Consulta na API ViaCep os dados do CEP informado
        /// </summary>
        [HttpPost("{cep}")]
        public async Task<IActionResult> ConsultaCep(string cep)
        {
            var cepResponse = await _cepConsultaRequestService.ConsultarCep(cep);
            return Ok(cepResponse);
        }

    }
}
