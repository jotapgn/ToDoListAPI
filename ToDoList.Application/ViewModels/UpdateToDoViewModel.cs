namespace ToDoList.Application.ViewModels
{
    public record UpdateToDoViewModel
    {
        public UpdateToDoViewModel(Guid id, string title, bool done)
        {
            Id = id;
            Title = title;
            Done = done;
        }

        public Guid Id { get; private set; }
        public String Title { get; private set; }
        public bool Done { get; private set; }
    }
}
