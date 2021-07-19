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
using WaD___World_after_Death.Code.setting;


namespace WaD___World_after_Death.Code
{
    public class  CREATERECTANGLE
    {
        public static  Texture2D CreateMainRectangle(int size_x , int size_y , GraphicsDeviceManager _graphics) // draw main inventory board
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size_x , size_y);
            Color[] data = new Color[size_x*size_y];
            Color grey = new Color(97 ,97 ,97);
            int dem = 0 ;
            for(int i = 0 ; i < size_x ; i++)
            {
                for(int j = 0 ; j < size_y ; j++)
                {
                    data[dem] = grey;
                    dem++;
                }
            }
            rect.SetData(data);
            return rect;
        }
    }


    public class InventoryBoard
    {
        private int DrawPointx;
        private int DrawPointy;
        private int Width;
        private int Height;

        private Texture2D MainBoard;
        
        public  bool IsOpen = false;
        
        
        
        public InventoryBoard(int Width , int Height, GraphicsDeviceManager _graphics)
        {
            ChangeSettings(Width , Height , _graphics);
        }


        public virtual void  Open(SpriteBatch  _spriteBatch , GraphicsDeviceManager _graphics) 
        {
            if(IsOpen == false)return ;
            _spriteBatch.Begin();
            _spriteBatch.Draw(MainBoard , new Vector2(DrawPointx , DrawPointy)  , Color.White);
            _spriteBatch.End();
        }

        public void ChangeSettings(int Width, int Height , GraphicsDeviceManager _graphics)
        {
            this.Width = Width - Width/20;
            DrawPointx = Width - this.Width;

            this.Height = Height - Height / 20;
            DrawPointy = Height - this.Height;

            #region check
            if(this.Width +  this.Width %20 >= Width)
            {
                this.Width -= this.Width%20;
                DrawPointx += this.Width%20;
            }else {
                this.Width += this.Width%20;
                DrawPointx -= this.Width%20;
            }
            #endregion  // check if Width can be multiply by 20

            #region check
            if(this.Height + this.Height % 10 >= Height)
            {
                this.Height -= this.Height%10;
                DrawPointy += this.Height%10;
            }else {
                this.Height += this.Height%10;
                DrawPointy -= this.Height%10;
            }
            #endregion // check if Height can be multiply by 10

            #region LoadBoard
            MainBoard = CREATERECTANGLE.CreateMainRectangle(this.Width, this.Height ,_graphics);

            #endregion
        }
    }
}
