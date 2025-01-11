
using TBAG.Scenes;

namespace TBAG
{
    class StartUp {
        
        public static void Main() {
            DotNetEnv.Env.Load();
            (new StartMenu()).Start();
        }
    }
}
