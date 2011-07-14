using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.Menus
{
    abstract class Menu
    {
        public abstract void NextMenuItem();
        public abstract void PreviousMenuItem();
        public abstract void ResolveMouseSelection();
        public abstract void UpdateColors();
        public abstract void SelectMenuItem();        
    }
}
