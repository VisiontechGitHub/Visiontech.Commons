using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VisiontechCommons.Models
{
    public class CustomSerializationBinder : DefaultSerializationBinder
    {

        public CustomSerializationBinder(IDictionary<Type, string> typeNames = null)
        {
            if (typeNames != null)
            {
                foreach (var typeName in typeNames)
                {
                    Map(typeName.Key, typeName.Value);
                }
            }
        }

        readonly IDictionary<Type, string> typeToName = new Dictionary<Type, string>();
        readonly IDictionary<string, Type> nameToType = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        public void Map(Type type, string name)
        {
            typeToName.Add(type, name);
            nameToType.Add(name, type);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            if (typeToName.ContainsKey(serializedType))
            {
                assemblyName = null;
                typeName = typeToName[serializedType];
            } else if (serializedType.IsGenericType && typeToName.ContainsKey(serializedType.GetGenericTypeDefinition())) {
                assemblyName = null;
                typeName = typeToName[serializedType.GetGenericTypeDefinition()];
            } else {
                base.BindToName(serializedType, out assemblyName, out typeName);
            }
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            return assemblyName == null && nameToType.ContainsKey(typeName)
                ? nameToType[typeName]
                : Type.GetType(string.Format("{0}, {1}", typeName, assemblyName), true);
        }

    }
}
