namespace TBAG.Resources
{
    class MenuItem
    {
        public string Id { get; }
        public string Text { get; }
        public Action Callback { get; }
        public bool LeavesMenu { get; }
        
        
        public MenuItem(string id, string text, Action callback, bool leavesMenu = true)
        {
            Id = id;
            Text = text;
            Callback = callback;
            LeavesMenu = leavesMenu;
        }

        public void handle()
        {
            Callback?.Invoke();
        }
    }
}

