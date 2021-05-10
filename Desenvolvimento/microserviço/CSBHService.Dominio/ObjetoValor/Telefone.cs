using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBHService.Dominio.ObjetoValor
{
    public class Telefone
    {
        public Telefone(int ddd, int numero)
        {
            Ddd = ddd;
            this.numero = numero;
        }

        public int Ddd { get; set; }
        public int numero { get; set; }
    }
}
