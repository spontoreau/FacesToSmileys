using System;
using System.Collections.Generic;
using Autofac;

namespace FacesToSmileys.Dependencies
{
    public class ExternalModule : Module
    {
        static IDictionary<Type, Type> Dependencies = new Dictionary<Type, Type>();

        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            if(!Dependencies.ContainsKey(typeof(TInterface)))
            {
                Dependencies.Add(typeof(TInterface), typeof(TImplementation));
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach(var dependency in Dependencies)
            {
                builder.RegisterType(dependency.Value).As(dependency.Key);
            }
        }
    }
}
