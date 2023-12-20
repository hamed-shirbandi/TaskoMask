using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskoMask.Services.Identity.Api.Domain.Entities;

namespace TaskoMask.Services.Identity.Api.Infrastructure.Data.EntityMapping;

public class UserMapping
{
    public UserMapping(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
    }
}
