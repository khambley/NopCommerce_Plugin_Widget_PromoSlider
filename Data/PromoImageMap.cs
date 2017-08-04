using Nop.Plugin.Widget.PromoSlider.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widget.PromoSlider.Data
{
    public class PromoImageMap : EntityTypeConfiguration<PromoImageRecord>
    {
        public PromoImageMap()
        {
            ToTable("PromoSlider_PromoImages");

            HasKey(m => m.PromoImageId);

            Property(m => m.PromoSliderId);
            Property(m => m.Caption);
            Property(m => m.DisplayOrder);
            Property(m => m.Url);

            //this establishes relationship between slider and the images.
            this.HasRequired(i => i.PromoSlider)
                .WithMany(s => s.Images)
                .HasForeignKey(i => i.PromoSliderId);
        }

    }
}
