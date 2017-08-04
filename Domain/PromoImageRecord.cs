using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Plugin.Widget.PromoSlider.Domain
{
    public class PromoImageRecord : BaseEntity
    {
        public virtual int PromoImageId { get; set; }

        //used in db as a foreign key column
        public virtual int PromoSliderId { get; set; }
        public virtual string Caption { get; set; }
        public virtual string Url { get; set; }
        public virtual string FilePath { get; set; }
        public virtual int DisplayOrder { get; set; }

        //another navigation property of the Entity Framework, 
        //allows us to navigate up to the parent slider
        public PromoSliderRecord PromoSlider { get; set; }
    }
}