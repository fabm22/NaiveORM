using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveORM.Tests
{
    class Class2
    {
        delegate int deleg(int i);  
        static void Main(string[] args)
        {
            deleg myDelegate = x => x * x;
            int j = myDelegate(5);  //j=25
        }

        public Class2(){
            //avec des fonctions anonymes
            List<int> myList = new List<int>( new int[] {-2,-1, 5, 45, 7} );
            List<int> positiveNumbers = myList.FindAll( delegate(int i) { return i > 0; } );

            //avec des expressions Lambda
            List<int> list2 = new List<int>(new int[]{-3, -4, 7,0,34});
            var positiveNumbers2 = list2.FindAll( (int i) => i > 0 ); //exp lambda
            
            foreach(int positiveNum in positiveNumbers2)
            {
                Console.WriteLine( positiveNum );
            }
        }

    }
}
