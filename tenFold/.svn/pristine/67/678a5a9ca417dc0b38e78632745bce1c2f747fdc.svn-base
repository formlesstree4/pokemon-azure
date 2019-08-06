using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using PokeEngine.Menu;
using PokeEngine.Screens;

namespace PokeEngine.Input
{
    static class InputHandler
    {
        private static int coolDown = 0;

        public static bool WasKeyPressed(KeyboardState keyState, Keys key, int newCoolMax)
        {
            bool check = false;

            if (coolDown <= 0)
            {
                if (keyState.IsKeyDown(key))
                {
                    check = true;
                    coolDown = newCoolMax;
                }
            }

            return check;
        }

        public static Keys[] GetSelectedKeys(KeyboardState keyState, int newCoolMax)
        {
            Keys[] keylist = { Keys.None };

            if (coolDown <= 0)
            {
                keylist = keyState.GetPressedKeys();
                coolDown = newCoolMax;
            }

            return keylist;
        }

        public static void UpdateCooling()
        {
            if (coolDown > 0)
                coolDown--;
        }

        public static int GetCooldown() { return coolDown; }

        public static void ResetCool() { coolDown = 0;}

    }
}