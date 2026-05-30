using System;
using System.Collections.Generic;

namespace ChatbotWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        SmartCybersecurityChatbot bot = new SmartCybersecurityChatbot();
        TaskRepository repo = new TaskRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ChatHistory"] == null)
                    Session["ChatHistory"] = new List<string>();

                if (Session["UserName"] == null)
                    Session["UserName"] = "";

                if (Session["LastTopic"] == null)
                    Session["LastTopic"] = "";
            }

            if (Request.QueryString["delete"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["delete"]);
                repo.DeleteTask(id);
            }
        }

        
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim().ToLower();
            if (input == "") return;

            List<string> history =
                (List<string>)Session["ChatHistory"];

            string response = "";

            if (input.StartsWith("my name is"))
            {
                string name = input.Substring(11).Trim();
                Session["UserName"] = name;

                response = "Nice to meet you " + name + " ";
            }

         
            else if (input == "history")
            {
                response = string.Join("<br/>", history);
            }

            else if (input == "more")
            {
                string lastTopic = Session["LastTopic"].ToString();

                if (lastTopic == "password")
                    response = "More password tips: use passphrases, password managers, and enable MFA.";

                else if (lastTopic == "phishing")
                    response = "More phishing tips: always verify links and check sender domains.";

                else
                    response = "I need a topic first. Ask about password, phishing, vpn, etc.";
            }

            
            else
            {
                response = bot.GetResponse(input);

             
                if (input.Contains("password"))
                    Session["LastTopic"] = "password";

                else if (input.Contains("phishing"))
                    Session["LastTopic"] = "phishing";

                else if (input.Contains("vpn"))
                    Session["LastTopic"] = "vpn";
            }

            string nameValue = Session["UserName"].ToString();
            if (!string.IsNullOrEmpty(nameValue))
            {
                response = "Hi " + nameValue + ", " + response;
            }

         
            history.Add("You: " + txtInput.Text);
            history.Add("Bot: " + response);

            Session["ChatHistory"] = history;

       
            lblChat.Text +=
                "<b>You:</b> " + txtInput.Text +
                "<br/><b>Bot:</b> " + response +
                "<hr/>";

            txtInput.Text = "";
        }

        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblChat.Text = "";
            Session["ChatHistory"] = new List<string>();
        }

      
        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                repo.AddTask(
                    txtTaskName.Text,
                    txtTaskDesc.Text,
                    DateTime.Parse(txtDueDate.Text)
                );

                lblTasks.Text = "Task added successfully!";
            }
            catch
            {
                lblTasks.Text = "Invalid task input.";
            }
        }

        protected void btnViewTasks_Click(object sender, EventArgs e)
        {
            var tasks = repo.GetTasks();

            string output = "";

            foreach (var t in tasks)
            {
                output +=
                    "<b>" + t.TaskName + "</b><br/>" +
                    t.TaskDescription + "<br/>" +
                    t.DueDate.ToShortDateString() +
                    "<hr/>";
            }

            lblTasks.Text = output;
        }
    }
}
