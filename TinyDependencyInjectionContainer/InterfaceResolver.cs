using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ninject;


namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private readonly IKernel _controller = new StandardKernel();
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
                                    _controller.Bind(type).To(implType);
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
        {   Type value;
            var a =_controller.Get(typeof(T));
            _myDictionary.TryGetValue(typeof(T), out value);
            if (value == null) return null;
            return (T) Activator.CreateInstance(value);
        }
    }
}
