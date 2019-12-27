using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NfcAdapters.Database;

namespace NfcAdapters.Web.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public AdapterContext AdapterContext { get; }

        public BaseController(AdapterContext adapterContext)
        {
            AdapterContext = adapterContext;
        }

        protected Task<bool> AuthenticateAsync (string username, string key)
        {
            return AdapterContext.DbUsers.Where(e => e.Username == username && e.AuthKey == key).AnyAsync();
        }
    }
}