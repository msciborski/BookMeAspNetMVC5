using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Concrete.Helpers {
    public static class TestableDbFunctions {
        [System.Data.Entity.DbFunction("Edm", "DiffDays")]
        public static int? DiffDays(DateTime? dateValue1, DateTime? dateValue2){
            if (!dateValue1.HasValue || !dateValue2.HasValue)
                return null;
            return (int) (dateValue2.Value - dateValue1.Value).TotalDays;
        }
    }
}
