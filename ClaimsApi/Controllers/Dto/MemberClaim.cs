using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsApi.Controllers.Dto
{
    [Keyless]
    public class MemberClaim
    {
        public int MemberId { get; set; }
        public double ClaimAmount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ClaimDate { get; set; }
    }
}
