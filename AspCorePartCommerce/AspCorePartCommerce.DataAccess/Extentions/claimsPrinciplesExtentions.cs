using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Extentions
{
    public static class claimsPrinciplesExtentions
    {
        public static string emailfromprinciples(this ClaimsPrincipal user )
        {
            return user?.Claims?.FirstOrDefault(x=>x.Type==ClaimTypes.Email)?.Value;
        }
    }
}
