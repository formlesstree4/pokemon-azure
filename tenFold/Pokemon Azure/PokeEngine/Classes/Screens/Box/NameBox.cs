using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PokeEngine.Menu;

namespace PokeEngine.Screens
{
    public struct charBox
    {
        public Vector2 position;
        public char value;
    }

    public struct button
    {
        public Texture2D texture;
        public Rectangle rect;
    }

    public enum MenuState
    {
        UPPER,
        LOWER,
        OTHERS
    }

    public class NameBox : Screen
    {
        private string name;
        private charBox[,] charBoxGrid;
        private byte selection;
        private Texture2D charBoxTexture;
        private MenuState menuState;
        private Vector2 gridPos;

        /// <summary>
        /// 0 = UPPER; 2 = lower; 3 = Others; 4 = DELETE; 5 = OK;
        /// </summary>
        private button[] buttonList;

        public NameBox(GraphicsDeviceManager g, ContentManager c, SpriteFont f)
            : base(g, c, f)
        {
            name = "";
            charBoxGrid = new charBox[23, 3];
            selection = 0;
            menuState = MenuState.UPPER;

            gridPos = new Vector2(5, 5);

            populateGrid();
        }

        private void populateGrid()
        {
            for (int x = 0; x < charBoxGrid.GetUpperBound(0); x++)
            {
                for (int y = 0; y < charBoxGrid.GetUpperBound(1); y++)
                {
                    charBoxGrid[x, y].position = new Vector2(
                        gridPos.X + ((charBoxTexture.Width + 1) * x),
                        gridPos.Y + ((charBoxTexture.Height + 1) * y));
                }
            }

            switch (menuState)
            {
                case MenuState.UPPER:
                    int count = 0;
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (count < 26)
                                charBoxGrid[x, y].value = font.Characters[count + 33];
                            else
                                charBoxGrid[x, y].value = ' ';
                            count++;
                        }
                    }

                    for (int x = 10; x < 13; x++)
                    {
                        for(int y = 0; y < 3; y++)
                        {
                            if (x == 10)
                            {
                                //charBoxGrid
                            }
                        }
                    }
                    break;
                case MenuState.LOWER:
                    break;
                case MenuState.OTHERS:
                    break;
            }
        }

        public override void HandleInput(GamePadState gamePadState, KeyboardState keyState, MouseState mouseState)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
