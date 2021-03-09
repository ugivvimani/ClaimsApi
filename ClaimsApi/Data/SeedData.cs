using ClaimsApi.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsApi.Data
{
    public static class SeedData
    {
        public static void Initialize(InsuranceDbContext context)
        {
            if (!context.Claims.Any())
            {
                using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/Data/Files/Claim.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Claim>();
                    context.Claims.AddRange(records);
                }
                context.SaveChanges();
            }

            if (!context.Members.Any())
            {
                using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/Data/Files/Member.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Member>();                    
                    context.Members.AddRange(records);
                }
                context.SaveChanges();
            }

            context.Database.ExecuteSqlRaw(
                        @"CREATE VIEW vw_MemberClaims AS
                            SELECT m.MemberId, m.FirstName, m.LastName, c.ClaimAmount, c.ClaimDate
                            FROM Members m
                            JOIN Claims c on c.MemberId = m.MemberId");
        }
    }
}
