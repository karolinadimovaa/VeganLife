namespace VeganLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VeganLife.Data.Common.Models;

    public class ProductImage : BaseModel<string>
    {
        public ProductImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Extension { get; set; }
    }
}
