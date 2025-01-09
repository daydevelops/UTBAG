using Microsoft.EntityFrameworkCore;

namespace TBAG.Models
{
    public class Save
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
