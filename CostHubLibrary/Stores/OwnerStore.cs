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

        public Person GetPersonWithRole(string RoleName, string OwnerName, DateTime PointInTime)
        {
            Person person = null;

            using (var connection = new MySqlConnection(this._connectionString))
            {
                connection.Open();

                var param = new
                {
                    RoleName = RoleName,
                    OwnerName = OwnerName,
                    PointInTime = PointInTime
                };

                person = connection.Query<Person>(
                    @"SELECT Person.PersonId AS PersonId, Person.Firstname AS Firstname, Person.Lastname AS Lastname, Person.Email AS Email 
                      FROM Owner,Person,Role 
                      WHERE Role.Type = @RoleName
                      AND Owner.Name = @OwnerName
                      AND Role.OwnerId = Owner.OwnerId
                      AND Role.PersonId = Person.PersonId
                      AND Role.StartDateTime < @PointInTime
                      AND Role.EndDateTime IS NULL", param).FirstOrDefault();
            }

            return person;
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
