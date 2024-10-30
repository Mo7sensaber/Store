using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications.Product
{
    public class ProductSpaceParams
    {
        private string? search;
        public string? Search
        {
            get => search; set => search = value?.ToLower();
        }
        public string? Sort {  get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public int PageSize { get; set; } = 5;
        public int PageIndaex { get; set; } = 1;

    }
}
