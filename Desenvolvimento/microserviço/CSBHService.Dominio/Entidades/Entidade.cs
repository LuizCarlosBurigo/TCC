using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace CSBHService.Dominio.Entidades
{
    public abstract class Entidade 
    {
        protected Entidade()
        {
            this.gravacao = DateTime.Now;
        }
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public virtual string ID { get; private set; }
        [BsonElement("time_stamp")]
        public DateTime TimeStamp { get; set; }
        [BsonElement("Data_gravacao")]
        public DateTime gravacao { get; private set; }
    }
}
