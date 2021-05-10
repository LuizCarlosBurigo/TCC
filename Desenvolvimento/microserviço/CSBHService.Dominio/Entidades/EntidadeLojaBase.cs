using System;

namespace CSBHService.Dominio.Entidades
{
    public abstract class EntidadeLojaBase : Entidade
    {
        protected EntidadeLojaBase(int codigoEmpresa, int codigoFilial)
        {
            CodigoEmpresa = codigoEmpresa;
            CodigoFilial = codigoFilial;
        }

        public int CodigoEmpresa { get; private set; }
        public int CodigoFilial { get; private set; }
    }
}
