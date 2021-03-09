using ClaimsApi.Controllers.Dto;
using ClaimsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimsApi.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> contextOptions) : base(contextOptions) { }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberClaim> MemberClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>()
                .Property(a => a.MemberId).ValueGeneratedNever();

            modelBuilder.Entity<Member>()
                .Property(a => a.MemberId).ValueGeneratedNever();

            modelBuilder
                .Entity<MemberClaim>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("vw_MemberClaims");
                        eb.Property(v => v.MemberId).HasColumnName("MemberId");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
