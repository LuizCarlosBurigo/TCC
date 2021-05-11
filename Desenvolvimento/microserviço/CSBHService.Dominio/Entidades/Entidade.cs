using System;

namespace CSBHService.Dominio.Entidades
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            this.gravacao = DateTime.Now;
        }

        public Guid ID { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public DateTime gravacao { get; private set; }
    }
}
