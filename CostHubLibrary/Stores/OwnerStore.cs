using CostHubLibrary.Model;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostHubLibrary.Stores
{
    public class OwnerStore : BaseStore
    {
        public Owner[] List()
        {
            List<Owner> list = null;

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                list = connection.Query<Owner>(
                    "SELECT * FROM Owners").ToList();
            }

            return list.ToArray();
        }

        public Owner Get(string OwnerId)
        {
            Owner item = null;

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                var param = new
                {
                    OwnerId = OwnerId
                };

                item = connection.Query<Owner>(
                    "SELECT * FROM Owners WHERE OwnerId = @OwnerId", param).FirstOrDefault();
            }

            return item;
        }
    }
}
