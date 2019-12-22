using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NfcAdapters.Database.Entities
{
    [Table(name: "Adapters")]
    public class Adapter
    {
        [Key]
        public int AdapterId { get; set; }

        public AdapterType AdapterType { get; set; } = null!;

    }
}