using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokeEngine.Menu;
using PokeEngine.Input;
using System.Threading;

namespace PokeEngine.Screens
{
    public class DialogBox : Screen
    {

        private MenuWindow menuWindow;
        private string lineOne, lineTwo, remainingText;
        private Queue<String> messageQueue;

        public DialogBox(GraphicsDeviceManager g, ContentManager c, SpriteFont f, String s)
            : base(g, c, f)
        {
            Name = "DialogBox";

            messageQueue = new Queue<string>();
            
            splitMessage(s);
            
            List<string> stringList = new List<string>();
            stringList.Add(lineOne);
            stringList.Add(lineTwo);
            
            menuWindow = new MenuWindow(
                Vector2.Zero,
                stringList,
                5f);

            menuWindow.SetMarkerEnabled(false);

            setPosition();
        }

        private void splitMessage(string s)
        {
            lineOne = ""; lineTwo = ""; remainingText = "";

            string[] words = s.Split(' ');

            bool lineOneDone = false, lineTwoDone = false;
            float maxWidth = ScreenHandler.SCREEN_WIDTH - (32 * 2) - (5 * 2);

            for (int i = 0; i < words.Length; i++)
            {
                words[i] += ' ';
                if (!lineOneDone)
                {
                    string newLine = lineOne + words[i];
                    float newLineLength = font.MeasureString(newLine).X;
                    if (newLineLength < maxWidth)
                    {
                        lineOne = newLine;
                        continue;
                    }
                    else
                    {
                        lineOneDone = true;
                    }
                }
                else if (!lineTwoDone)
                {
                    string newLine = lineTwo + words[i];
                    float newLineLength = font.MeasureString(newLine).X;
                    if (newLineLength < maxWidth)
                    {
                        lineTwo = newLine;
                        continue;
                    }
                    else
                    {
                        lineTwoDone = true;
                    }
                }
                else
                {
                    remainingText += words[i];
                }
            }
        }

        private void setPosition()
        {
            menuWindow.Position = new Vector2(
                (ScreenHandler.SCREEN_WIDTH / 2) - ((menuWindow.size.x * 32) / 2),
                ScreenHandler.SCREEN_HEIGHT - (menuWindow.size.y * 32));
        }

        public void QueueMessage(String msg)
        {
            messageQueue.Enqueue(msg);
        }

        public override void HandleInput(GamePadState gamePadState, KeyboardState keyState, MouseState mouseState)
        {
            if(InputHandler.WasKeyPressed(keyState, KeyConfig.KeyList[4], 10))
            {
                if (remainingText.Replace(" ", "") == "")
                {
                    if (messageQueue.Count > 0)
                    {
                        splitMessage(messageQueue.Dequeue());
                        setPosition();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    splitMessage(remainingText);
                    menuWindow.ChangeOption(0, lineOne);
                    if (lineTwo.Replace(" ", "") == "")
                    {
                        menuWindow.RemoveOption(1);
                        setPosition();
                    }
                    else
                    {
                        menuWindow.ChangeOption(1, lineTwo);
                        setPosition();
                    }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            
             
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuWindow.Draw(spriteBatch, font, Color.White);
        }
    }

}
