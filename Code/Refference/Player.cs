using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content ;
using WaD___World_after_Death.Code.LOGIC; // thư viện logic của tôi

namespace WaD___World_after_Death.Code
{
    public class Player : PlayerPhysic
    {


        private float speed = 6.7f;
        private string skin;

        

        private float friction = 0.9f;

        private Texture2D texture;
        
        private void Move()
        {
            if(Keyboard.GetState().IsKeyDown(Input.Up) ||Keyboard.GetState().IsKeyDown(Input.Sub_Up))
            {
                Velocity.Y -= speed;
            }
            if(Keyboard.GetState().IsKeyDown(Input.Down) ||Keyboard.GetState().IsKeyDown(Input.Sub_Down))
            {
                Velocity.Y += speed;
            }
            if(Keyboard.GetState().IsKeyDown(Input.Left) ||Keyboard.GetState().IsKeyDown(Input.Sub_Left))
            {
                Velocity.X -= speed;
            }
            if(Keyboard.GetState().IsKeyDown(Input.Right) ||Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X += speed;
            }
        }


        public Player(Vector2 position , string texture )  : base(position)
        {
            this.position = position;
            this.skin = texture;
        }
        public override void Update(GameTime gameTime) // fixed
        {
            this.oldPosition = position;
            Move();
            position += Velocity;
            Velocity *= friction;

        }

        public virtual void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(skin);
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.texture , position , Color.White);
            _spriteBatch.End();
        }
    } 
}