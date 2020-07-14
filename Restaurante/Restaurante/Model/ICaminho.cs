using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Model
{
    public interface ICaminho
    {
        string ObterCaminho(string NomeArquivoBanco);
    }
}
