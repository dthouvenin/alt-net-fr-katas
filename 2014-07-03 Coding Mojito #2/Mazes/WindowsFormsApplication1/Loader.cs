using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Text;
using Mazes.Core;

namespace Mazes.Runner
{
    public static class Loader 
    {
        public static I Load<I>(string filename)
        {
            var assembly = Assembly.LoadFile(filename);
            foreach(var type in assembly.GetExportedTypes())
            {
                var intf = type.GetInterface(typeof(I).Name);
                if(intf != null)
                    return (I)Activator.CreateInstance(type);
            }
            throw new InstanceNotFoundException();
        }
    }
}
