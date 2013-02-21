using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PlanetaryDefence.Gameplay.Cameras;
using PlanetaryDefence.Gameplay.Levels;
using PlanetaryDefence.Gameplay;
using PlanetaryDefence.Engine;


namespace PlanetaryDefence.Gameplay.HUD
{
    class HeadsUpDisplay
    {
        public int playerscore, playerhealth;
        public SpriteFont hudfont;
        public Vector2 playerscorepos;
        public Vector2 playerhealthpos;
        public bool showhud;










        //constructor

        public HeadsUpDisplay(int health)
        {
            playerscore = 0;
            playerhealth = health;

            showhud = true;


            hudfont = null;


        }



        //load content

        public void LoadContent(ContentManager Content)
        {
            hudfont = Content.Load<SpriteFont>(Constants.HudFont);


        }

        //update
        public void Update(int score, int health, Vector2 scorePos, Vector2 healthPos)
        {
            playerscore = score;
            playerhealth = health;

            playerscorepos = scorePos;
            playerhealthpos = healthPos;
        }

        //Draw
        public void Draw(SpriteBatch spritebatch)
        {
            if (showhud)
                spritebatch.DrawString(hudfont, "Score: " + playerscore, playerscorepos, Color.Red);
            spritebatch.DrawString(hudfont, "Health " + playerhealth, playerhealthpos, Color.Blue);

        }
    }
}
