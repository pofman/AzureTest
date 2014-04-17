using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AzureTest.Foundations
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> ConcreteSubclassesOf(this Assembly assembly, Type type)
        {
            return assembly.GetTypes().Where(x => !x.IsAbstract && type.IsAssignableFrom(x));
        }
    }
}
