﻿using Azure;
using Microsoft.Data.SqlClient;
using Task_Taker.Utils;
using Task_Taker.Models;
using Task_Taker.Repositories;

namespace Task_Taker.Repositories
{
    public class TaskListRepository : BaseRepository, ITaskListRepository
    {
        public TaskListRepository(IConfiguration configuration) : base(configuration) { }
        //view
        public List<TaskList> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, UserId, ListTitle
                        FROM TaskList
                        ORDER BY ListTitle";
                    var reader = cmd.ExecuteReader();
                    var taskList = new List<TaskList>();
                    while (reader.Read())
                    {
                        taskList.Add(new TaskList()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            ListTitle = DbUtils.GetString(reader, "ListTitle")
                        });
                    }
                    reader.Close();
                    return taskList;
                }
            }
        }
        //add
        public void Add(TaskList taskList)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO TaskList (
                            UserId, ListTitle )
                        OUTPUT INSERTED.ID
                        VALUES (
                            @UserId, @ListTitle )";
                    DbUtils.AddParameter(cmd, "@UserId", taskList.UserId);
                    DbUtils.AddParameter(cmd, "@ListTitle", taskList.ListTitle);
                    taskList.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        //delete

        public List<TaskList> GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, UserId, ListTitle FROM TaskList " +
                                      "WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new List<TaskList>() {new TaskList()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                        ListTitle = reader.GetString(reader.GetOrdinal("ListTitle")),
                    }};
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Delete(int taskListId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TaskList " +
                                      "WHERE Id = @TaskListId";
                    DbUtils.AddParameter(cmd, "@TaskListId", taskListId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTaskList(TaskList taskList)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                 UPDATE TaskList
                 SET ListTitle = @ListTitle
                 WHERE id = @id";
                    cmd.Parameters.AddWithValue("@ListTitle", taskList.ListTitle);
                    cmd.Parameters.AddWithValue("@id", taskList.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public TaskList GetTaskListById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
            SELECT Id, UserId, ListTitle FROM TaskList
            WHERE Id = @id
            ";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        TaskList taskList = new TaskList()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserId = reader.GetInt32(reader.GetOrdinal("Id")),
                            ListTitle = reader.GetString(reader.GetOrdinal("ListTitle")),
                        };
                        reader.Close();
                        return taskList;
                    }
                    reader.Close();
                    return null;
                }
            }
        }
    }
}
