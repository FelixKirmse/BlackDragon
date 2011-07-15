using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.Components
{
    abstract class Component
    {        
        public abstract void Receive<T>(string message, T obj);
    }
}
