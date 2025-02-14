﻿using System;
using TBAG.Database;
using TBAG.Resources;

namespace TBAG.Scenes
{
    class StartMenu {
        
        private readonly AppDbContext _db = new AppDbContext();
        
        public void Start() {
            ShowStartMenu();
        }
        
        public void NewGame() {
            Console.WriteLine("Starting new game...");
            Game Game = new Game(_db);
            Game.New();
        }
        
        private void ShowStartMenu() {
            string text = "Welcome to TBAG!";
            MenuItem[] items = new []
            {
                new MenuItem("1","Start a new game", () => { NewGame();}),
                new MenuItem("2","Load game", () => { ShowSaves();}),
                new MenuItem("3","Help", () => { ShowHelp();}),
                new MenuItem("4","Exit", () => { ExitGame();})
            };
            Menu menu = new Menu(text, items);
            menu.ShowMenu();
        }
        
        public void ShowSaves() {
            MenuItem[] saveList = GetSaves();
            if (saveList.Length > 0)
            {
                Menu savesMenu = new Menu("Select a save to load", saveList);
                savesMenu.ShowMenu();
            }
            else
            {
                Console.WriteLine("there are no saves avaliable\n");
                ShowStartMenu();
            }
        }
        
        public void ExitGame() {
            Console.WriteLine("\n\n");
            Console.WriteLine("Good Bye");
            Environment.Exit(0);
        }
        
        private MenuItem[] GetSaves()
        {
            var saves = _db.Saves;
            if (saves.Count() == 0)
            {
                return new MenuItem[0];
            }
            
            MenuItem[] saveList = new MenuItem[saves.Count()];
            int i = 0;
            foreach (var save in saves)
            {
                saveList[i] = new MenuItem(save.Id.ToString(), save.Name, () => { LoadGame(save.Id);});
                i++;
            }
            return saveList;
        }
        
        public void LoadGame(int id)
        {
            Console.WriteLine("Loading game...");
            Game Game = new Game(_db);
            Game.FromSave(id);
        }
        
        private void ShowHelp()
        {
            string text = "Here is a list of commands that you can execute during game play \n" +
                          " /help - shows this list\n" +
                          " /exit - exits the game";
            MenuItem[] items = new []
            {
                new MenuItem("1","return", () => { ShowStartMenu();})
            };
            Menu helpMenu = new Menu(text, items);
            helpMenu.ShowMenu();
        }
    }
    
}
