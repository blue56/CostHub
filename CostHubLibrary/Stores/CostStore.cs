using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostHubLibrary.Model;
using Dapper;
using MySqlConnector;

namespace CostHubLibrary.Stores
{
    public class CostStore : BaseStore
    {
        public void Insert(Cost[] CostList)
        {
            var sql = "INSERT INTO Cost (CostId,Service,Name,Amount,StartDate,EndDate) VALUES (@CostId,@Service,@Name,@Amount,@StartDate,@EndDate)";

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                foreach (Cost cost in CostList)
                {
                    var affectedRows = connection.Execute(sql, cost);
                }
            }
        }

        public Cost Get(string CostId)
        {
            Cost cost = null;

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                var param = new
                {
                    CostId = CostId
                };

                cost = connection.Query<Cost>(
                    "SELECT * FROM Cost WHERE CostId = @CostId", param).FirstOrDefault();
            }

            return cost;
        }


        public Cost[] List(string UnitId)
        {
            List<Cost> list = null;

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                var param = new
                {
                    UnitId = UnitId
                };

                list = connection.Query<Cost>(
@"SELECT Cost.ResourceId AS ResourceId,Cost.Amount AS Amount,Resources.Name AS ResourceName, 
         Cost.StartDate AS StartDate, Cost.EndDate AS EndDate, Resources.Service AS Service,
         Cost.Currency AS Currency
FROM Cost
INNER JOIN Resources ON Cost.ResourceId = Resources.ResourceId
WHERE Resources.UnitId = @UnitId", param).ToList();
            }

            return list.ToArray();
        }

        public Cost[] List()
        {
            List<Cost> list = null;

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                list = connection.Query<Cost>(
                    "SELECT * FROM Cost").ToList();
            }

            return list.ToArray();
        }
    }
}
