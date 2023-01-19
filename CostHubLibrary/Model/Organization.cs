using CostHubLibrary.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostHubLibrary.Model
{
    public class Organization
    {
        public static Person GetAccountablePerson(string Owner, DateTime PointInTime)
        {
            OwnerStore os = new OwnerStore();
            Person p = os.GetPersonWithRole("Accountable", Owner, PointInTime);

            return p;
        }
    }
}
