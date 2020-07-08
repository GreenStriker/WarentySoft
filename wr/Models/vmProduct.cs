using Microsoft.AspNetCore.Http;
using wr.entity;

namespace Inventory.Models
{
    public class vmProduct:Product
    {
        public IFormFile UploadFile { get; set; }
        public string FileName { get; set; }
    }
}
