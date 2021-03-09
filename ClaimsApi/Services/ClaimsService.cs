using ClaimsApi.Controllers.Dto;
using ClaimsApi.Data;
using ClaimsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsApi.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly InsuranceDbContext _context;

        public ClaimsService(InsuranceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Claim>> GetClaims()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<List<MemberClaim>> GetMemberClaims(DateTime claimDate)
        {
            return await _context.MemberClaims.Where(a => a.ClaimDate <= claimDate).ToListAsync();
        }
    }
}
