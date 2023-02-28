using Repository.Entities;

namespace SE1611_PRN221_ASM.Models
{
    public class SearchModel
    {
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public string query { get; set; }
        public string[] genres { get; set; }
        public int size { get; set; }
        public string sort { get; set; }
    }
}
