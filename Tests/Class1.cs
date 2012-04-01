using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace NaiveORM.Tests
{
    class Class1
    {
        public Class1()
        {
            ParameterExpression value = Expression.Parameter(typeof(int), "value");
            ParameterExpression result = Expression.Parameter(typeof(int), "result");

            LabelTarget label = Expression.Label(typeof(int));

            BlockExpression block = Expression.Block(
                new[] { result },
                Expression.Assign(result, Expression.Constant(1)),
                
                Expression.Loop(
                    Expression.IfThenElse(
                        Expression.GreaterThan(value, Expression.Constant(1)),
                        Expression.MultiplyAssign(result, Expression.PostDecrementAssign(value)),
                        Expression.Break(label, result)
                    ),
                    label
                )
            );//end block

            int factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5); //5

            Console.WriteLine(factorial); //return 120
        }
    }
}
