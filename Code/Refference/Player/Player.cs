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
//using WaD___World_after_Death.Code;

namespace WaD___World_after_Death.Code
{
    public class Player : PlayerPhysic
    {


        private float speed = 1.7f;
        private string skin;

        private InventoryBoard Inventory ;

        

        private float friction = 0.9f;

        private bool Is_Pressed = false;

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
          
        #region ChangeMouse
        
        public bool GetMouseState()
        {
            return Inventory.IsOpen;
        }

        #endregion

        private void IsOpeningInventory()
        {
            
            if(Keyboard.GetState().IsKeyDown(Input.OPENINVENTORY) && !Is_Pressed)
            {
                if(Inventory.IsOpen == true)
                {
                    Inventory.IsOpen = false;
                    
                }else
                {
                    Inventory.IsOpen = true;
                };
                Is_Pressed = true;
            }
            if(Keyboard.GetState().IsKeyUp(Input.OPENINVENTORY) && Is_Pressed)
            {
                Is_Pressed = false;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Escape) && Inventory.IsOpen == true)
            {
                Inventory.IsOpen = false;
                Is_Pressed = false;
            }
        }

        public Player(Vector2 position , string texture ,int width , int height , GraphicsDeviceManager _graphics  )  : base(position)
        {
            this.position = position;
            this.skin = texture;
            Inventory = new InventoryBoard(width, height , _graphics , this);
        }

        public virtual void Update(GameTime gameTime, SpriteBatch _spriteBatch,GraphicsDeviceManager _graphics)
        {
            IsOpeningInventory();
            
        }


        public virtual void PhysicUpdate(GameTime gameTime ) // fixed
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

        public virtual void Draw(SpriteBatch _spriteBatch , GraphicsDeviceManager _graphics)
        {
            _spriteBatch.Begin();
            Vector2 Draw_POS = Vector2.Lerp(oldPosition, position , FixedUpdate.ALPHA);
            _spriteBatch.Draw(this.texture , Draw_POS , Color.White);

            
            _spriteBatch.End();

            Inventory.Open(_spriteBatch, _graphics);
            
        }

        public virtual void Draw(SpriteBatch _spriteBatch  , int size_x , int size_y , int Draw_x , int Draw_y)
        {
            _spriteBatch.Draw(this.texture , new Rectangle((int)Draw_x , (int)Draw_y , size_x , size_y) , Color.White);
        }
    } 
}