using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NfcAdapters.Database.Entities
{
    [Table(name: "AdapterTypes")]
    public class AdapterType
    {
        [Key]
        public int AdapterTypeId {get; set;}
        public string Description { get; set; } = null!;

        public ICollection<Adapter> Adapters { get; set; } = new List<Adapter>();
    }
}
