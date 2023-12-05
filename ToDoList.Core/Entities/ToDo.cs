namespace ToDoList.Core.Entities
{
    public record ToDo
    {
        public ToDo(string title, bool done)
        {
            Id = new Guid();
            Title = title;
            Done = done;
            Date = DateTime.Now;
        }
        public ToDo(Guid id, string title, bool done)
        {
            Id = id;
            Title = title;
            Done = done;
            Date = DateTime.Now;
        }
        public Guid Id;
        public string Title;
        public bool Done;
        public DateTime Date;

    }
}
