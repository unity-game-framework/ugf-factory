using System;
using System.Collections.Generic;
using System.Reflection;
using UGF.Assemblies.Runtime;
using UnityEngine;

namespace UGF.Factory.Runtime
{
    /// <summary>
    /// Provides utilities for working with factories.
    /// </summary>
    public static class FactoryUtility
    {
        /// <summary>
        /// Registers all found factory defines to the specified provider. 
        /// </summary>
        /// <param name="provider">The factory provider.</param>
        public static void RegisterFactories(IFactoryProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            
            var defines = new List<IFactoryDefine>();
            
            GetFactoryDefines(defines);

            for (int i = 0; i < defines.Count; i++)
            {
                IFactoryDefine define = defines[i];
                IFactoryCollection collection = define.GetCollection(provider);
                IFactory factory = define.GetFactory(provider, collection);
                
                define.RegisterBuilders(provider, collection, factory);
            }
        }
        
        /// <summary>
        /// Gets all found factory defines to the specified collection.
        /// </summary>
        /// <param name="defines">The collection of the defines to fill.</param>
        public static void GetFactoryDefines(List<IFactoryDefine> defines)
        {
            if (defines == null) throw new ArgumentNullException(nameof(defines));
            
            var types = new List<Type>();
            
            AssemblyUtility.GetBrowsableTypes(types, typeof(FactoryDefineAttribute));
            
            GetFactoryDefines(defines, types);
        }
        
        /// <summary>
        /// Gets all found factory defines from the specified assembly to the specified collection.
        /// </summary>
        /// <param name="defines">The collection of the defines to fill.</param>
        /// <param name="assembly">The assembly to find.</param>
        public static void GetFactoryDefines(List<IFactoryDefine> defines, Assembly assembly)
        {
            if (defines == null) throw new ArgumentNullException(nameof(defines));
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            
            var types = new List<Type>();
            
            AssemblyUtility.GetBrowsableTypes(types, assembly, typeof(FactoryDefineAttribute));
            
            GetFactoryDefines(defines, types);
        }
        
        /// <summary>
        /// Gets all factory defines the specified collection of the types.
        /// </summary>
        /// <param name="defines">The collection of the defines to fill.</param>
        /// <param name="types">The collection of the types to find.</param>
        public static void GetFactoryDefines(List<IFactoryDefine> defines, List<Type> types)
        {
            if (defines == null) throw new ArgumentNullException(nameof(defines));
            if (types == null) throw new ArgumentNullException(nameof(types));
            
            for (int i = 0; i < types.Count; i++)
            {
                Type type = types[i];

                if (TryCreateFactoryDefine(type, out IFactoryDefine define))
                {
                    defines.Add(define);
                }
            }
        }

        /// <summary>
        /// Tries to create factory defines from the specified type.
        /// <para>
        /// Returns true if the define was created, otherwise false.
        /// </para>
        /// </summary>
        /// <param name="type">The type of the define to create.</param>
        /// <param name="define">The created factory define.</param>
        public static bool TryCreateFactoryDefine(Type type, out IFactoryDefine define)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            
            try
            {
                define = (IFactoryDefine)Activator.CreateInstance(type);
            }
            catch (Exception exception)
            {
                Debug.LogWarning($"Can not create factory define from the specified type: {type}/n{exception}");

                define = null;
                return false;
            }
            
            return true;
        }
    }
}