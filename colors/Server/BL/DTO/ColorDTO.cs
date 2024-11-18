using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class ColorDTO
    {
        [JsonConstructor]
        public ColorDTO(int colorId, string? ColorName, int? Price, bool? IsInStock, int? presentationOrder)
        {
            this.colorId = colorId;
            this.ColorName = ColorName;
            this.Price = Price;
            this.IsInStock = IsInStock;
            this.presentationOrder = presentationOrder;
        }
        public int colorId { get; set; }
        public string? ColorName { get; set; }
        public int? Price { get; set; }
        public bool? IsInStock { get; set; }
        public int? presentationOrder { get; set; }

    }
}
