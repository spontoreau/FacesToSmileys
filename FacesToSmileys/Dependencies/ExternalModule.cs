using System;
using System.Collections.Generic;
using Autofac;

namespace FacesToSmileys.Dependencies
{
    /// <summary>
    /// External dependencies module
    /// </summary>
    public class ExternalModule : Module
    {
        /// <summary>
        /// External dependencies
        /// </summary>
        static IDictionary<Type, Type> Dependencies = new Dictionary<Type, Type>();

        /// <summary>
        /// Register an external dependencies
        /// </summary>
        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            if(!Dependencies.ContainsKey(typeof(TInterface)))
            {
                Dependencies.Add(typeof(TInterface), typeof(TImplementation));
            }
        }

        /// <summary>
        /// Load module dependencies
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            foreach(var dependency in Dependencies)
            {
                builder.RegisterType(dependency.Value).As(dependency.Key);
            }
        }
    }
}
