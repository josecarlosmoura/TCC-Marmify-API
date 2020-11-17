using Marmify.Application.App.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmify.Application.Interfaces.Commons
{
    public interface ICepService
    {
        CepDTO GetAddressByCep(string cep);
    }
}
