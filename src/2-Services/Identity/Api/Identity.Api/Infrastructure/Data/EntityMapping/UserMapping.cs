using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Infrastructure.Data.DbContext
{
    public class UserMapping
    {
        public UserMapping(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
    

}
