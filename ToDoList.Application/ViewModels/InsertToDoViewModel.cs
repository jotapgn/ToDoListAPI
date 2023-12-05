namespace ToDoList.Application.ViewModels
{
    public record InsertToDoViewModel
    {
        public InsertToDoViewModel(string title, bool done)
        {
            Title = title;
            Done = done;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
    }
}