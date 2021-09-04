using CEPSearch.Adapters.Interfaces;
using CEPSearch.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CEPSearch.Services
{
    public class CepConsultaRequestService : ICepConsultaRequestService
    {
        private readonly ICepConsultaRequestService _cepConsultaRequestService;
        private readonly string _apiUrl;

        public CepConsultaRequestService()
        {
            _apiUrl = "https://viacep.com.br/ws/";
            _cepConsultaRequestService = RestService.For<ICepConsultaRequestService>(_apiUrl);
        }

        public async Task<CepResponse> ConsultarCep(string cep)
        {
            if (CepValido(cep))
                return await _cepConsultaRequestService.ConsultarCep(cep);
            else
                throw new ArgumentException("CEP INVÁLIDO");
        }

        public static bool CepValido(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}-\d{3}$");

            if (!Rgx.IsMatch(cep))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
