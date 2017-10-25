using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {

        IKernel controller = new StandardKernel();
        Dictionary<Type, Type> myDictionary = new Dictionary<Type, Type>();
        public InterfaceResolver(String str)
        {
            try
            {
                foreach (var line in File.ReadAllLines(str))
                {
                    if (line.StartsWith("#")) continue;
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
                                    controller.Bind(type).To(implType);
                                    myDictionary.Add(type,implType);
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
            var val = controller.Get(typeof(T));
            myDictionary.TryGetValue(typeof(T), out value);
            return (T) Activator.CreateInstance(value);
        }
    }
}
