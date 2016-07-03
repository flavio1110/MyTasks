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
                return conn.Query<Task>(@"SELECT Id, Title, Description, Completed, Created FROM Task");
            }
        }

        public Task GetById(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {            
                conn.Open();                
                return conn.Query<Task>(@"SELECT Id, Title, Description, Completed, Created FROM Task WHERE Id = @Id",
                    new { Id = id}).FirstOrDefault();
            }
        }

        public Task Save(Task task)
        {
            return null;
        }
    }
}
