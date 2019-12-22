using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NfcAdapters.Database.Entities
{
    [Table(name: "Lendings")]
    public class Lending
    {
        [Key]
        public int LendingId { get; set; }
        public Adapter Adapter { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime LendingStart { get; set; }
        public DateTime? Returned { get; set; }

        /// <summary>
        /// Creates a new lending in the database
        /// </summary>
        /// <param name="adapter">The adapter to lend out</param>
        /// <param name="username">The user to lend it to</param>
        public Lending(Adapter adapter, string username)
        {
            Adapter = adapter;
            Username = username;
        }

        /// <summary>
        /// For ef core
        /// </summary>
        public Lending()
        {
        }
    }
}
