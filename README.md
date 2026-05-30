# ChatBot1
The chatbot is designed to simulate a smart assistant that responds to user queries, remembers conversation context, and manages simple tasks using a SQL Server database.

ChatBot System
Keyword-based cybersecurity responses
topic detection (passwords, phishing, VPN, malware,help)
Conversation history

 memory & Recall
- Stores chat history during session
- Recall previous conversation (`history`)
- Remembers last topic discussed
- Basic conversational flow simulation

Task Manager
- Add tasks with description and due date
- View all tasks in database
- Delete tasks using query string
- SQL Server integration (ADO.NET)



---

 Database Setup

Create Database
```sql
CREATE DATABASE ChatbotDB;
GO

USE ChatbotDB;
```
 Create Tasks Table
```sql
CREATE TABLE Tasks
(
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    TaskName NVARCHAR(100) NOT NULL,
    TaskDescription NVARCHAR(500),
);
    DueDate DATE NOT NULL
);
