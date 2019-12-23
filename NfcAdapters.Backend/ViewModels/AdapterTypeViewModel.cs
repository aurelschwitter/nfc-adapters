using NfcAdapters.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NfcAdapters.Backend.ViewModels
{
    public class AdapterTypeViewModel
    {
        public int AdapterTypeId { get; set; }
        public string Description { get; set; } = null!;

        public int NrAvailable { get; }

        public AdapterTypeViewModel(AdapterType adapterType)
        {
            if (adapterType == null) throw new ArgumentNullException(nameof(adapterType));

            AdapterTypeId = adapterType.AdapterTypeId;
            Description = adapterType.Description;
            NrAvailable = adapterType.GetAvailableAdapters().Count();
        }
    }
}
