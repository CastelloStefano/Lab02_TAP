/*
 * Ver 2.0
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Ninject.Modules;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private readonly Dictionary<Type, Type> _myDictionary = new Dictionary<Type, Type>();
        public InterfaceResolver(String str)
        {
            LoadFromFile(str);
        }

        private bool LoadFromFile(String file)
        {
            try{
               foreach (var line in File.ReadAllLines(file)){
                    if (line.StartsWith("#") || line.Equals("")) continue;
                    var item = line.Split('*');
                    var interfaceAssembly = Assembly.LoadFrom(item[0]);
                    var implementationAssembly = Assembly.LoadFrom(item[2]);
                    foreach (var type in interfaceAssembly.GetTypes())
                        if (type.IsInterface && type.FullName.Equals(item[1]))
                            foreach (var implType in implementationAssembly.GetTypes())
                                if (implType.IsClass && implType.FullName.Equals(item[3]))
                                    _myDictionary.Add(implType, type);
                }
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e);
                throw;
            }
            return true;
        }
    
        public T Instantiate<T>() where T : class
        {
            // _myDictionary.Values.ToList().IndexOf(typeof(T)); // if I want a list
            return (T) Activator.CreateInstance(_myDictionary.FirstOrDefault(x => x.Value == typeof(T)).Key);
        }
    }
}
