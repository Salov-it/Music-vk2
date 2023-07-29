using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myaudio.Domain;

namespace Persistance.Base
{
    public class Config : IEntityTypeConfiguration<Myaudios>
    {
        public void Configure(EntityTypeBuilder<Myaudios> builder)
        {
            builder.HasIndex(w => w.id).IsUnique();
            builder.HasKey(w => w.id);

        }
    }
}
