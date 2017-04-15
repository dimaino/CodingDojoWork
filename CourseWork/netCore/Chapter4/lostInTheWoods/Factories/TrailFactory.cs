using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lostInTheWoods.Models;
using Microsoft.Extensions.Options;
 
namespace lostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;
        
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        
        internal IDbConnection Connection
        {
            get { return new MySqlConnection(MySqlConfig.Value.ConnectionString);}
        }

        // private string connectionString;
        // public TrailFactory()
        // {
        //     connectionString = "server=localhost;userid=root;password=root;port=8889;database=lost_in_the_woods;SslMode=None";
        // }
        // internal IDbConnection Connection
        // {
        //     get {
        //         return new MySqlConnection(connectionString);
        //     }
        // }
        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (trail_name, description, trail_length, elevation_change, latitude, longitude, created_at, updated_at) VALUES (@Trail_Name, @Description, @Trail_Length, @Elevation_Change, @Latitude, @Longitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Trail> SortByLength()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails ORDER BY trail_length DESC");
            }
        }

        public IEnumerable<Trail> SortByElevationChange()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails ORDER BY elevation_change DESC");
            }
        }
    }
}