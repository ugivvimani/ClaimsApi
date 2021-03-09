using ClaimsApi.Controllers.Dto;
using ClaimsApi.Models;
using ClaimsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsService;
        public ClaimsController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }

        // GET: api/Claim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaims()
        {
            return await _claimsService.GetClaims();
        }        

        // GET: api/Claim/2020-09-01
        [HttpGet("{claimDate}")]
        public async Task<ActionResult<IEnumerable<MemberClaim>>> GetClaimsByMember([FromRoute] DateTime claimDate)
        {
            var mc = await _claimsService.GetMemberClaims(claimDate);

            if (mc == null)
            {
                return NotFound();
            }

            return mc;
        }
    }
}
