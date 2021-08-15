using Newtonsoft.Json;
using System;

namespace InSell.Models
{
    public interface IConcern
    {
    }

    public interface IPersistable<T> : IConcern
    {
        T Id { get; set; }
    }

    public interface IBasePersistable : IPersistable<string>
    {
        string Type { get; }
    }

    public abstract class Persistable : IBasePersistable
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public abstract string Type { get; }
    }
}
