using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon.Managers
{
    static class InputProvider
    {
        public static KeyboardState KeyState { get; private set; }
        public static MouseState MouseState { get; private set; }

        public static void Update()
        {
            KeyState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        }
    }
}
