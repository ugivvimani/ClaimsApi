using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClaimsApi.Models
{
    public class Member
    {
        [Key]
        [Name("MemberID")]
        public int MemberId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }              
    }
}
