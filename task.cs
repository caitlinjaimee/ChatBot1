using System;

namespace ChatbotWebForm
{
    public class TaskItem
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
    }
}
