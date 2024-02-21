using System;
using System.Text.Json;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ArchivedTests
{
    public class T20230322_BuiltInSerialization : ITest
    {
        public void Test()
        {
            var k = new EstateComparableEstatesSearchFilter()
            {
                ReferenceEstateId = 1,
                BuildingTypeIds = new long[] { 1, 2, 3, 4 },
                NumberOfRoomsRange = new EstateComparableEstatesSearchFilter.RangeInteger() { From = 1, To = null },
            };

            var kString = JsonSerializer.Serialize(k);
            Console.WriteLine(kString);
        }

        public class EstateComparableEstatesSearchFilter
        {
            public long ReferenceEstateId { get; set; }
            public long[] BuildingTypeIds { get; set; }
            public RangeInteger NumberOfRoomsRange { get; set; }

            public class RangeInteger
            {
                public int? From { get; set; }
                public int? To { get; set; }
            }
        }
    }
}
