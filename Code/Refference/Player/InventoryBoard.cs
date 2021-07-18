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
        public static Texture2D CreateMainRectangle(int size_x , int size_y , GraphicsDeviceManager _graphics) // draw main inventory board
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size_x , size_y);
            Color[] data = new Color[size_x*size_y];
            Color vien = new Color(67 , 180 , 231);
            Color inside = new Color(88 ,174 , 126);
            int dem = 0 ;
            for(int i =  0 ; i < size_x ; i++)
            {
                for(int j = 0 ;  j < size_y ; j++)
                {
                    if(i  == 0  || i == size_x-1)
                    { 
                        data[dem] = vien;
                    }
                    else if(j == 0 ||  j == size_y-1)
                    {
                        data[dem] = vien;
                    }
                    else if(i == 0 && (j == 1 || j == size_y-1 ))
                    {
                        data[dem]  = vien;
                    }
                    else if(i == size_x-1 && (j ==  1 || j  == size_y-1))
                    {
                        data[dem] = vien;
                    }else  {
                        data[dem]= inside;
                    }
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
        
        public  bool IsOpen = false;
        
        
        
        public InventoryBoard(int Width , int Height)
        {
            this.Width = Width - Width/20;
            DrawPointx = Width - this.Width;

            this.Height = Height - Height / 20;
            DrawPointy = Height - this.Height;

            #region check
            if(this.Width +  this.Width %12 >= Width)
            {
                this.Width -= this.Width%12;
                DrawPointx += this.Width%12;
            }else {
                this.Width += this.Width%12;
                DrawPointx -= this.Width%12;
            }
            #endregion // check if Width can be multiply by 12
        }


        public virtual void  Open(SpriteBatch  _spriteBatch , GraphicsDeviceManager _graphics) 
        {
            #region Needed to fix because  MainRectangle created every time function is called
            Texture2D  MainRectangle =  CREATERECTANGLE.CreateMainRectangle(this.Width ,  this.Height ,_graphics );
            _spriteBatch.Begin();
            _spriteBatch.Draw(MainRectangle , new Vector2(DrawPointx , DrawPointy) , Color.White);
            _spriteBatch.End();   

            #endregion;         
        }

        public void ChangeSettings(int Width, int Height)
        {
            this.Width = Width - Width/20;
            DrawPointx = Width - this.Width;

            this.Height = Height - Height / 20;
            DrawPointy = Height - this.Height;

            #region check
            if(this.Width +  this.Width %12 >= Width)
            {
                this.Width -= this.Width%12;
                DrawPointx += this.Width%12;
            }else {
                this.Width += this.Width%12;
                DrawPointx -= this.Width%12;
            }
            #endregion  // check if Width can be multiply by 12
        }
    }
}
