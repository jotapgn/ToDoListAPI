namespace ToDoList.Application.ViewModels
{
    public record ToDoViewModel
    {
        public ToDoViewModel(Guid id, string title, bool done, DateTime date)
        {
            Id = id;
            Title = title;
            Done = done;
            Date = date;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
    }
}
