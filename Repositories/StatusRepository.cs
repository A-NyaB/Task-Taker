using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Task_Taker.Models;
using Task_Taker.Utils;

namespace Task_Taker.Repositories
{
    public class StatusRepository : BaseRepository, IStatusRepository
    {
        public StatusRepository(IConfiguration configuration) : base(configuration) { }
        //view
        public List<Status> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Progress
                        FROM Status";
                    var reader = cmd.ExecuteReader();
                    var status = new List<Status>();
                    while (reader.Read())
                    {
                        status.Add(new Status()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Progress = DbUtils.GetString(reader, "Progress")
                        });
                    }
                    reader.Close();
                    return status;
                }
            }
        }
    }
}