using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ChatbotWebForm
{
    public class TaskRepository
    {
        string connString =
            ConfigurationManager.ConnectionStrings["ChatbotDB"].ConnectionString;

        public void AddTask(string name, string desc, DateTime due)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query =
                    "INSERT INTO Tasks (TaskName, TaskDescription, DueDate) VALUES (@n,@d,@date)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@d", desc);
                cmd.Parameters.AddWithValue("@date", due);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<TaskItem> GetTasks()
        {
            List<TaskItem> list = new List<TaskItem>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM Tasks", conn);

                conn.Open();

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    list.Add(new TaskItem()
                    {
                        TaskID = (int)r["TaskID"],
                        TaskName = r["TaskName"].ToString(),
                        TaskDescription = r["TaskDescription"].ToString(),
                        DueDate = Convert.ToDateTime(r["DueDate"])
                    });
                }
            }

            return list;
        }

        public void DeleteTask(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM Tasks WHERE TaskID=@id", conn);

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
