using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace PokeEngine.Input
{
    class KeyboardInput
    {

        private const int KEY_COOLDOWN_MAX = 3;
        
        private string buffer;
        private int keyCoolDown;
        private bool keyIsCooling;
        private bool isInputting;

        public KeyboardInput()
        {
            buffer = "";
            keyCoolDown = KEY_COOLDOWN_MAX;
            keyIsCooling = false;
            isInputting = false;
        }

        private char getCharFromKeyboard()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (pressedKeys.Length > 0)
            {
                int keyNumber = (int)pressedKeys[0];

                if (keyNumber >= 65 && keyNumber <= 90)
                    if ((char)keyNumber != '\0')
                        return (char)keyNumber;
            }

            return (char)0;
        }

        public void Update()
        {
            if (isInputting)
            {
                if (Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    if (!keyIsCooling)
                    {
                        string key = getCharFromKeyboard().ToString();
                        buffer += key;
                        Console.WriteLine("adding " + key + " to buffer");
                        keyIsCooling = true;
                        keyCoolDown = KEY_COOLDOWN_MAX;
                    }
                    else
                    {
                        if (keyCoolDown > 0)
                            keyCoolDown--;
                        else
                            keyIsCooling = false;
                    }
                }
            }
        }

        public void ChangeInputState() { isInputting = isInputting ? false : true; }

        public void ChangeInputState(bool state) { isInputting = state; }

        public bool GetInputState() { return isInputting; }

        public string GetText() { return buffer; }

    }
}
