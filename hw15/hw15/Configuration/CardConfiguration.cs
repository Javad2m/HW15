using hw15.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Cards");

        builder.HasData(new List<Card>()
        {
            new Card() {Id = 1 ,UserId = 1 ,CardNumber = "6219861922113740" , HolderName = "blue" ,Password = "1234" ,Balance = 500, CVV2 = "123"},
            new Card() {Id = 2 ,UserId = 2 ,CardNumber = "6219861922113741" , HolderName = "red" ,Password = "1234" ,Balance = 100, CVV2 = "123"},
        });
    }
}
