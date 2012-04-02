using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveORM.Tests
{
    class Class3
    {
         object e = Enumerable
                    .Range(1,100)
                    .Where(x => (x % 2) == 0)
                    .ToList();
                    
    }
}
