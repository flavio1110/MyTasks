using System;
using System.Collections.Generic;
using System.Linq;
using MyTasks.Domain;
using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MyTasks.Infra
{
    public class TaskRepository : ITaskRepository
    {
        private string _connectionString;

        public TaskRepository(IConfigurationRoot configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");            
        }

        public IEnumerable<Task> GetAll()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {            
                conn.Open();                
                return conn.Query<Task>("SELECT Id, Title, Description, Completed, Created FROM Task");
            }
        }

        public Task GetById(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {            
                conn.Open();                
                return conn.Query<Task>("SELECT Id, Title, Description, Completed, Created FROM Task WHERE Id = @Id",
                    new { Id = id}).FirstOrDefault();
            }
        }

        public Task Save(Task task)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {       
                System.Console.WriteLine(task.Id > 0);     
                conn.Open();  
                if(task.Id == 0)
                {              
                    task.Id = conn.Query<int>(@"INSERT INTO task (title, description, completed, created ) values 
                                                (@title, @description, @completed, @created) RETURNING id", task).Single();
                }
                else
                {                    
                    conn.Execute(@"UPDATE task SET title = @title, 
                                                  description = @description,
                                                  completed = @completed,
                                                  created = @created
                                            WHERE Id = @id", task);
                }
            }

            return task;
        }

        public void Delete(Task task)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {            
                conn.Open();                
                conn.Execute("DELETE FROM Task WHERE Id = @Id", task);
            }
        }
    }
}
