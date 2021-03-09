using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClaimsApi.Models
{
    public class Claim
    {   
        [Key]
        [Name("MemberID")]
        public int MemberId { get; set; }
        public DateTime ClaimDate { get; set; }
        public double ClaimAmount { get; set; }
    }
}
