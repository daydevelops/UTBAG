using Microsoft.EntityFrameworkCore;

namespace TBAG.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int SaveId { get; set; }
        public string Name { get; set; }
        public string CurrentScene { get; set; }
        public DateTime LastUpdated { get; set; }

        public Player(int saveId, string currentScene)
        {
            SaveId = saveId;
            CurrentScene = currentScene;
        }
    }
}
