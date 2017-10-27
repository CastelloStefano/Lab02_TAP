using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ninject;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private readonly Dictionary<Type, Type> _myDictionary = new Dictionary<Type, Type>();
        public InterfaceResolver(String str)
        {
            try
            {
                foreach (var line in File.ReadAllLines(str))
                {

                    if (line.StartsWith("#")|| line.Equals("")) continue;
                    var item = line.Split('*');
                    var interfaceAssembly = Assembly.LoadFrom(item[0]);
                    var implementationAssembly = Assembly.LoadFrom(item[2]);
                    foreach (var type in interfaceAssembly.GetTypes())
                        if (type.IsInterface && type.FullName.Equals(item[1]))
                        {
                            foreach (var implType in implementationAssembly.GetTypes())
                            {
                                if (implType.IsClass && implType.FullName.Equals(item[3]))
                                {
                                    _myDictionary.Add(type,implType);

                                }
                            }

                        }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
    
        public T Instantiate<T>() where T : class
        {
            _myDictionary.TryGetValue(typeof(T), out var value);
            if (value == null) return null;
            return (T) Activator.CreateInstance(value);
        }
    }
}
