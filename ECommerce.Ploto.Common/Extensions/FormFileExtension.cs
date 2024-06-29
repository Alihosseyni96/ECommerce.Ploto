using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Extensions
{
    public static class FormFileExtension 
    {
        public async static Task<byte[]> GetBytesAsync(this IFormFile file)
        {
            //byte[] fileByteArray;
            using var st = new MemoryStream();
            file.CopyTo(st);
            var  fileByteArray = st.ToArray();
            
            return fileByteArray;
        }
    }
}
