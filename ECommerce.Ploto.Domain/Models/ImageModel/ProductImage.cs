namespace ECommerce.Ploto.Domain.Models.Image
{
    public class ProductImage : Image
    {
        public Guid ProductId { get; protected set; }
        public Product Product { get; protected set; }

        private ProductImage()
        {
            
        }


        private ProductImage(byte[] file  , string contentType , Product product) :base (file , contentType)
        {
            Product = product;
        }

        public static ProductImage Create(Product product , byte[] file, string contentType)
        {
            return new ProductImage(file , contentType , product);
        }
    }
}
