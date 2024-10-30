namespace Store.Core.Entities.Order
{
    public class ProductItemOrder
    {
        public ProductItemOrder() { } // 

        public ProductItemOrder(int ProductId, string ProductName, string PictureURL)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.PictureURL = PictureURL;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureURL { get; set; }
    }
}
