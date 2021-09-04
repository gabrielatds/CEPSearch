using CEPSearch.Dtos;
using Refit;
using System.Threading.Tasks;

namespace CEPSearch.Adapters.Interfaces
{
    public interface ICepConsultaRequestService
    {
        [Get("/{cep}/json/")]
        Task<CepResponse> ConsultarCep(string cep);
    }
}
