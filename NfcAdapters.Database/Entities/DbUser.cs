using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NfcAdapters.Database.Entities
{
    [Table(name: "DbUsers")]
    public class DbUser
    {
        [Key]
        public int DbUserId { get; set; }

        public string AuthKey { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; } = null!;
        public string? Description { get; set; }
        public bool Authorized { get; set; } = false;
    }
}
