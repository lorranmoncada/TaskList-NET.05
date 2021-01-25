using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist.Core.DataObjects
{
    public class Validacoes
    {
        public static void ValidarSeNullOuVazio(string valor, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor)) throw new DomainExeption(mensagem);
        }
    }
}
