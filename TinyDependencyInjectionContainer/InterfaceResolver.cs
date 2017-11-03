/*
 * Ver 2.0
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                                    // creo tutte le associazioni possibili
                                    // le ritorno poi ad ogni richiesta esterna
                                    _myDictionary.Add(type, implType);
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
            _myDictionary.TryGetValue(typeof(T), out var value);
            if (value == null) return null;
            return (T) Activator.CreateInstance(value);
        }
    }

    public class GenericModule : NinjectModule
    {
        private readonly Type _bindType, _toType;

        public GenericModule(Type bindType, Type toType)
        {
            this._bindType = bindType;
            this._toType = toType;
        }

        public override void Load()
        {
            Bind(_bindType).To(_toType);
        }
    }
}
