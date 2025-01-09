namespace TBAG
{
    class Menu
    {
        public MenuItem[] Items { get; }

        public string Prompt;
        
        public Menu(string prompt, MenuItem[] items)
        {
            Prompt = prompt;
            Items = items;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(Prompt);
            Console.WriteLine("\n");
            
            foreach (MenuItem item in Items)
            {
                Console.WriteLine($"{item.Id}. {item.Text}");
            }
            bool inMenu = true;
            while (inMenu)
            {
                string input = Console.ReadLine();
                foreach (MenuItem item in Items)
                {
                    if (input == item.Id)
                    {
                        item.handle();
                        if (item.LeavesMenu)
                        {
                            inMenu = false;
                        }
                        break;
                    }
                }
            }
        }
    }
}

