using IntegratedIdentity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegratedIdentity.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20261018090000_add-refresh-token-to-users")]
    partial class addrefreshtokentousers
    {
    }
}
