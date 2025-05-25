using DotNetExample.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace DotNetExample.DataAccessLayer
{
    public class ApplicationUser : IdentityUser<int>
    {
        public required string FullName { get; set; }
        public string? Address { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }

        public ICollection<OrderEntity>? Orders { get; set; }
    }
}
