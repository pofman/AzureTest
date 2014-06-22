using System;
using System.Linq.Expressions;

namespace AzureTest.Support
{
    public static class ReflectionExtensions
    {
        /// <summary>
        ///   Retrieves the member expression represented by the specified expression
        /// </summary>
        /// <typeparam name = "T"></typeparam>
        /// <typeparam name = "TReturn"></typeparam>
        /// <param name = "expression">The expression.</param>
        /// <returns></returns>
        public static MemberExpression MemberExpression<T, TReturn>(this Expression<Func<T, TReturn>> expression)
        {
            return expression.Body.MemberExpression();
        }

        /// <summary>
        ///   Retrieves the member expression represented by the specified expression
        /// </summary>
        /// <param name = "expression">The expression.</param>
        /// <returns></returns>
        public static MemberExpression MemberExpression(this Expression expression)
        {
            MemberExpression memberExpression = null;
            switch (expression.NodeType)
            {
                case ExpressionType.Convert:
                    {
                        var body = (UnaryExpression)expression;
                        memberExpression = body.Operand as MemberExpression;
                    }
                    break;
                case ExpressionType.MemberAccess:
                    memberExpression = expression as MemberExpression;
                    break;
                case ExpressionType.Lambda:
                    {
                        var lambdaExpression = (LambdaExpression)expression;
                        memberExpression = lambdaExpression.Body as MemberExpression;
                    }
                    break;
            }

            if (memberExpression == null) throw new ArgumentException("Not a member access", "expression");
            return memberExpression;
        }
    }
}
