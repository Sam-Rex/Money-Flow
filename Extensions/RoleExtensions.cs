using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Extensions
{
    public class RoleExtensions : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole{
                    // Admin
                    Name = "Alpha",
                    NormalizedName="ALPHA"
                },
                new IdentityRole
                {
                    // General Manager
                    Name = "Bravo",
                    NormalizedName = "BRAVO"
                },
                new IdentityRole
                {
                    // Product Manager
                    Name = "Delta",
                    NormalizedName = "DELTA"
                },
                new IdentityRole
                {
                    
                    // Teem Leader
                    Name = "Oscar",
                    NormalizedName = "OSCAR"
                },
                new IdentityRole
                {
                    // Developer
                    Name = "Tango",
                    NormalizedName = "TANGO"
                },
                new IdentityRole
                {
                    // Sales
                    Name = "Romeo",
                    NormalizedName = "ROMEO"
                },
                new IdentityRole
                {
                    // Customer Supoort
                    Name = "Papa",
                    NormalizedName = "PAPA"
                },
                new IdentityRole
                {
                    // Marketing
                    Name = "Joliett",
                    NormalizedName = "JOLIETT"
                },
                new IdentityRole
                {
                    // Fainaincial
                    Name = "Zulu",
                    NormalizedName = "ZULU"
                },
                new IdentityRole
                {
                    Name = "SP_Billboard",
                    NormalizedName = "SP_BILLBOARD"
                },
                new IdentityRole
                {
                    Name = "SP_Design",
                    NormalizedName = "SP_DESIGN"
                },
                new IdentityRole
                {
                    Name = "SP_Inistall",
                    NormalizedName = "SP_INSTALL"
                },
                new IdentityRole
                {
                    Name = "SP_Print",
                    NormalizedName = "SP_PRINT"
                },
                new IdentityRole
                {
                    Name = "SP_Freelancer",
                    NormalizedName = "SP_FREELANCER"
                },
                new IdentityRole
                {
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                }
                );
        
        }
    }
}
