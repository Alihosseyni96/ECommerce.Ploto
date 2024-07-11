using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models.Image
{
    public class Image : BaseEntity<Guid>
    {
        public byte[] File { get; protected set; }
        public string ContentType { get; protected set; }


        protected Image()
        {
            
        }

        protected Image(byte[] file, string contentType)
        {
            File = file;
            ContentType = contentType;
        }



    }
}
