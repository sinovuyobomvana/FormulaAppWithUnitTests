using FormularApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularApp.UnitTests.Fixtures
{
    public class FansFixtures
    {
        public static List<Fan> GetFans() => new()
        {
            new Fan()
            {
               Email = "snvbmvn@gmail.com",
               Id = 1,
               Name = "Sinovuyo"
            },
            new Fan()
            {
               Email = "vusi@gmail.com",
               Id = 2,
               Name = "Vusi"

            }
        };
    }
}
