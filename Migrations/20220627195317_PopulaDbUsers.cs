using Microsoft.EntityFrameworkCore.Migrations;

namespace DESAFIO_MVC.Migrations
{
    public partial class PopulaDbUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO aspnetusers(
                Id,
                UserName,
                NormalizedUserName,
                Email,
                NormalizedEmail,
                EmailConfirmed,
                PasswordHash,
                SecurityStamp,
                ConcurrencyStamp,
                PhoneNumberConfirmed,
                TwoFactorEnabled,
                LockoutEnabled,AccessFailedCount) 
                
                Values(
                    '2e19946f-6171-4a59-893f-9ba908d714c2',
                    'admin@gft.com',
                    'ADMIN@GFT.COM',
                    'admin@gft.com',
                    'ADMIN@GFT.COM',
                    0,
                    'AQAAAAEAACcQAAAAEHIjhV3sN5OjQaxFuPCRCWwzkMAQECtidoF/r7mpZcz3hvI40GkDKAlNUsPqZwForA==',
                    'D7XQCTKKPUY4LTMHH7TNRX5AXKGOWKNX',
                    'c78fc454-4a9d-4032-8bcc-96776e5c5dab',
                    0,
                    0,
                    1,
                    0)");

            migrationBuilder.Sql("INSERT INTO aspnetusers(Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount) Values('383a1cf6-c0a6-481f-8092-58c76f137987','usuario@gft.com','USUARIO@GFT.COM','usuario@gft.com','USUARIO@GFT.COM',0,'AQAAAAEAACcQAAAAELg2zKp1+FEeJn6/4HPJTTLeBfGAtg+tRSCnZmdUK+Jf9eia3QwABhEdMpz6GL0PuQ==','O6BPFBQTIA2S6JILFNSDULNKU55Y2RTI','08761a57-fb7a-4b97-9a35-6bc077c39b81',0,0,1,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM aspnetusers");
        }
    }
}
