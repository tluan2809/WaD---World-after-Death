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

namespace WaD___World_after_Death.Code.Menu
{

    public class Original  // Lưu lại size thực và tỉ lệ của chúng
    {
        public static int Width ;

        public static int Height ; 

        public static int MenuSize_x;

        public static int MenuSize_y;
    }
    interface Button
    {

        public  void Update(GameTime gameTime);
        public void Draw(SpriteBatch _spriteBatch);

        public int Draw_x {get ; set;}
        public int Draw_y {get ; set;}

        public int End_x {get ; set;}

        public int End_y {get ; set;}

        public int size_x {get ; set;}

        public int size_y {get ; set;}

        public int Edgesize {get ; set ; }
    }



    #region MainMenu
    public class MainMenu
    {
        private bool IsOpen = false;
        public int Draw_x = 0 ;
        public int Draw_y  = 0 ; 

        public int End_x = 0 ;

        public int End_y = 0 ;
        
        public int size_x  = 0 ;

        public int size_y = 0 ;

        private bool Is_Pressed = false;

     
        private Texture2D Shape;

        public bool GetMouseState()
        {
            return this.IsOpen;
        }

        

        private void Check()
        {
            if(Keyboard.GetState().IsKeyDown(Input.OPEN_SETTINGS) && !Is_Pressed)
            {
                IsOpen = !IsOpen;
                Is_Pressed =true;
            }
            if(Keyboard.GetState().IsKeyUp(Input.OPEN_SETTINGS))
            {
                Is_Pressed = false;
            }
        }
        
        public void Draw(SpriteBatch _spriteBatch)
        {
            if(this.IsOpen == false)return ; 
            _spriteBatch.Begin();
            _spriteBatch.Draw(this.Shape , new Rectangle(Draw_x , Draw_y , size_x , size_y) , Color.White);
            _spriteBatch.End();
        }


        public void Update(GameTime gameTime)
        {
            Check();
            if(!IsOpen)
            {
                return ; 
            }

        }


        public MainMenu(int ScreenWidth , int ScreenHeight , ContentManager Content)
        {
            this.Shape  = Content.Load<Texture2D>("Assets/Menu/Menu/menu");
            Original.Width = ScreenWidth/ Shape.Width;
            Original.Height = 
            this.size_x = ScreenWidth;
            this.size_y = ScreenHeight;
            this.End_x = Draw_x + size_x;
            this.End_y = Draw_y + size_y;
        }



    }

    #endregion

    /*public class Sound : Button
    {

    }


    public class Graphics : Button
    {

    }

    public class Control : Button
    {


    }


    public class Quit : Button
    {

    }
*/
    public class BannerSettings : Button
    {
        public void Update(GameTime gameTime)
        {

        }



        public void Draw(SpriteBatch _spriteBatch)
        {

        }
        public int Draw_x {get ; set;}
        public int Draw_y {get ; set;}

        public int End_x {get ; set;}

        public int End_y {get ; set;}

        public int size_x {get ; set;}

        public int size_y {get ; set;}

        public int Edgesize {get ; set ; }

        public Texture2D Shape ;


        public BannerSettings(int Width , int Height , ContentManager Content)
        {
            Shape = Content.Load<Texture2D>("Assets/Menu/Menu/settings");

        }


    }
/*
    public class Resume : Button
    {

    }

    public class GAME : Button
    {
        
    }
*/
}