using ClaimsApi.Controllers.Dto;
using ClaimsApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsApi.Services
{
    public interface IClaimsService
    {
        public Task<List<Claim>> GetClaims();
        public Task<List<MemberClaim>> GetMemberClaims(DateTime claimDate);
    }
}
