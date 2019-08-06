using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokeEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PokeEngine.Menu
{
    static class Pokemon_InventoryScreen
    {

        private static Menu BASE_POKE_MENU = new Menu(8, 3, new Vector2(10, 10));

        private static Menu[] pokemonMenus = new Menu[6];
        private static int xScale = 10;
        private static int yScale = 10;

        //Selection will be 0-5 for pokemon and 6 for cancel
        private static int pselection = 0;
        private static int selection
        {
            get { return pselection; }
            set
            {                
                if (value > 6 && pselection != 6)
                    pselection = 6;
                else if (value > 6 && pselection == 6)
                    pselection = 0;
                else if (value < 0)
                    pselection = 6;
                else
                    pselection = value;
            }
        }

        public static bool IsVisible = false;
        public static bool IsActive = false;

        public static void Initialize()
        {
            for (int i = 0; i < pokemonMenus.Length; i++)
            {
                Vector2 pos;

                if (i == 0)
                {
                    pokemonMenus[i] = BASE_POKE_MENU;
                    continue;
                }
                else if (i % 2 == 0)
                    pos.X = BASE_POKE_MENU.Position.X + (BASE_POKE_MENU.size.x * 32) + xScale;
                else
                    pos.X = BASE_POKE_MENU.Position.X;

                pos.Y = BASE_POKE_MENU.Position.Y * ((int)(i / 2) * (BASE_POKE_MENU.size.y * 32) + yScale);

                pokemonMenus[i] = new Menu(BASE_POKE_MENU.size.x, BASE_POKE_MENU.size.y, pos);
            }
        }

        static public void Draw()
        {
            if (IsVisible)
            {
                
            }
        }

        static public void Update()
        {
        }

        static public void handleKeys()
        {
            if (IsActive)
            {
                //if you press the right button or D then increment the selection by one
                if (Input.InputHandler.isKeyPress(Keys.D) || Input.InputHandler.isKeyPress(Keys.Right))
                {
                    selection++;
                }
                //if you press the left button or A then decrement the selection by one
                if (Input.InputHandler.isKeyPress(Keys.A) || Input.InputHandler.isKeyPress(Keys.Left))
                {
                    selection--;
                }
                //if you press down or S then increment the selection by two
                if (Input.InputHandler.isKeyPress(Keys.S) || Input.InputHandler.isKeyPress(Keys.Down))
                {
                    selection+=2;
                }
                //if you press up or W then decrement the selection by two
                if (Input.InputHandler.isKeyPress(Keys.W) || Input.InputHandler.isKeyPress(Keys.Up))
                {
                    selection-=2;
                }
                
            }
        }
    }
}
