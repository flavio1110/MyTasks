using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasks.Domain;
using MySql.Data.MySqlClient.MySqlConnection;

namespace MyTasks.Infra
{
    public class TaskRepository : ITaskRepsository
    {
        public IEnumarable<Task> GetAll()
        {
            string myConnectionString;

            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=12345;database=MyArboretum;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            yield return new Task(){ Id = 1, Description = "do x 1" };
            yield return new Task(){ Id = 2, Description = "do x 2" };
            yield return new Task(){ Id = 3, Description = "do x 3" };
            yield return new Task(){ Id = 4, Description = "do x 4" };
        }
    }
}
