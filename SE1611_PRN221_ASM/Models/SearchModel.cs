using Repository.Entities;

namespace SE1611_PRN221_ASM.Models
{
    public class SearchModel
    {
        public string minPrice { get; set; }
        public string maxPrice { get; set; }
        public string query { get; set; }
        public string[] genres { get; set; }
        public int size { get; set; }
        public string[] sortOptions { get; set; }
    }
}
