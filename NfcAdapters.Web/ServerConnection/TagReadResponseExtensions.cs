using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NfcAdapters.Web.ServerConnection
{
    public static class TagReadResponseExtensions
    {
        public static TagReadResponse<int> GetTagUid(this TagReadResponse<int[]> response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            int id = 0;

            for (int i = 0; i < response.Data.Length; i++)
            {
                id += (int)Math.Pow(2, i) * response.Data[i];
            }

            return new TagReadResponse<int>()
            {
                Method = response.Method,
                Data = id,
                Success = response.Success
            };
        }
    }
}
