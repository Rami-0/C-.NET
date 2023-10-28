namespace Project2.Models
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }

    public class TaskProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public int AuthorId { get; set; }
        public Employee Author { get; set; }
        public int ExecutorId { get; set; }
        public Employee Executor { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
