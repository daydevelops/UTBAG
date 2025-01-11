
using TBAG.Database;
using TBAG.Models;

namespace TBAG
{
    class Game
    {
        private readonly AppDbContext _db = new AppDbContext();
        
        public Game(AppDbContext db)
        {
            _db = db;
        }

        public void New()
        {
            string intro = $"\n\n\n\nWelcome to {Environment.GetEnvironmentVariable("GAME_NAME")}!\n" +
                           $"Please enter a character name...\n";
            
            Console.WriteLine(intro);
            string name = Console.ReadLine();
            
            // create new save
            Save save = new Save();
            save.Name = name;
            _db.Saves.Add(save);
            _db.SaveChanges();

            Player player = new Player(save.Id,"OpeningScene");
            player.Name = name;
            _db.Players.Add(player);
            _db.SaveChanges();
        }

        public void FromSave(int saveId)
        {
            
        }
    }
}

