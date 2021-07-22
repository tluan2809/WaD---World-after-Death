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
    #region MainRectangle
    public class  MAINRECTANGLE
    {
        public int Draw_x;
        public int Draw_y;

        public int size_x ;
        public int size_y;

        public int End_x;
        public int End_y;
        public Texture2D CreateMainRectangle(int size_x , int size_y , GraphicsDeviceManager _graphics) // draw main inventory board
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

        private Texture2D Shape;


        public MAINRECTANGLE(int width, int height , GraphicsDeviceManager _graphics)
        {
            Draw_x = width/ 25;
            Draw_y = width/25;
            End_x = width - Draw_x; // góc phải dưới x
            End_y = height - Draw_y;// góc phải dưới y
            size_x = End_x - Draw_x;
            size_y = End_y - Draw_y;
            // tính toán 
            if(size_x %20 != 0 )
            {
                size_x += 20 - (size_x %20);
            }
            if(size_y %10 != 0 )
            {
                size_y += 10 - (size_y % 10);
            }
            End_x =Draw_x +  size_x;
            End_y = Draw_y + size_y;
            int half_width = width/2;
            int half_height = height/2;
            int temp_x = Draw_x +  (End_x - Draw_x)/2 ; 
            while(temp_x  >= half_width)
            {
                Draw_x -= 1;
                End_x -= 1;
                temp_x = Draw_x + (End_x - Draw_x)/2;
            }
            int temp_y = Draw_y + (End_y - Draw_y)/2;
            while(temp_y  >= half_height)
            {
                Draw_y -= 1;
                End_y -= 1;
                temp_y = Draw_y + (End_y - Draw_y)/2;
            }
            this.Shape = CreateMainRectangle(size_x , size_y ,_graphics );
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Shape , new Vector2(this.Draw_x , this.Draw_y) , Color.White);
            
        }
    }
    #endregion
    
    public class SQUARE
    {
        public static Texture2D CreateRightAngle(int size , GraphicsDeviceManager _graphics , Color COLOR)
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size , size);
            Color[] color = new Color[size * size];
            for(int i = 0 ; i < size * size; i++)
            { 
                color[i] = COLOR;
            }
            rect.SetData(color);
            return rect;
        }

        public static Texture2D CreateStuffBoard(int size_x ,int size_y ,int Edgesize, GraphicsDeviceManager _graphics , Color EdgeColor , Color COLOR)
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size_x ,size_y);
            Color[] data = new Color[size_x * size_y];
            int dem= 0 ;
            for(int i = 0 ;  i< size_y; i++)
            {
                for(int j = 0 ; j < size_x ; j++)
                {
                    if(i <= Edgesize || j <= Edgesize || j >= size_x - Edgesize)
                    {
                        data[dem] = EdgeColor;
                        dem++;
                        continue;
                    }
                    if(i >= size_y - Edgesize)
                    { 
                        data[dem] = EdgeColor;
                        dem++;
                        continue;
                    }
                    data[dem] = COLOR;
                    dem++;
                }
            }
            rect.SetData(data);
            return rect;
        }
    }

    #region StepBrother  
    public class STEPMAINBOARD
    {
        public int Edgesize ;
        private int RightAngle;

        private Texture2D  Square;
        public Texture2D CreateStepMainBoard(int size_x , int size_y  ,int Edgesize , int RightAngle , GraphicsDeviceManager _graphics)
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size_x , size_y);
            Color[] data = new Color[size_x * size_y];
            Color grey = new Color(97 ,97 ,97);
            Color black = new Color(0  ,0 , 0);
            this.Edgesize = Edgesize;
            this.RightAngle = RightAngle;
            
            int dem= 0 ;
            for(int i = 0 ;  i< size_y; i++)
            {
                for(int j = 0 ; j < size_x ; j++)
                {
                    if(i <= Edgesize || j <= Edgesize || j >= size_x - Edgesize)
                    {
                        data[dem] = black;
                        dem++;
                        continue;
                    }
                    if(i >= size_y - Edgesize)
                    { 
                        data[dem] = black;
                        dem++;
                        continue;
                    }
                    data[dem] = grey;
                    dem++;
                }
            }
            Square = SQUARE.CreateRightAngle(RightAngle , _graphics , Color.Black);

            rect.SetData(data);
            return rect; 
        }

        
        public int Draw_x;

        public int Draw_y;

        public int size_x;

        public int size_y;

        public int End_x;

        public int End_y;

        private Texture2D Shape;
        

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(this.Shape , new Vector2(Draw_x, Draw_y) ,Color.White);
            _spriteBatch.Draw(this.Square , new Vector2(Draw_x + Edgesize, Draw_y + Edgesize), Color.White);
            _spriteBatch.Draw(this.Square , new Vector2(Draw_x + Edgesize , End_y - Edgesize*2) , Color.White);
            _spriteBatch.Draw(this.Square , new Vector2(End_x - Edgesize*2 , Draw_y + Edgesize) , Color.White);
            _spriteBatch.Draw(this.Square , new Vector2(End_x -  Edgesize*2 , End_y - Edgesize*2) , Color.White);
            
        }
        public STEPMAINBOARD(int width, int height , int MaxWidth, int MaxHeight,GraphicsDeviceManager _graphics)
        {
            Draw_x = width + MaxHeight/50;
            Draw_y = height + MaxHeight/50;
            End_y = MaxHeight -  MaxHeight/50 ;
            End_x = MaxWidth - MaxHeight/50;
            size_x = End_x - Draw_x;
            size_y = End_y - Draw_y;
            Shape = CreateStepMainBoard(size_x , size_y , size_x / 50 , size_x / 50 , _graphics);
        }
    }
    #endregion

    public class Inventory 
    {
        public int Edgesize ;
        public int RightAngle;
        
        private Texture2D BlackSquare;

        private Texture2D GreySquare;

        private Texture2D BrownSquare;

        private Texture2D Shape;
        private Texture2D CreateInventory(int size_x , int size_y , GraphicsDeviceManager _graphics , int RightAngle)
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size_x , size_y);
            Color[] data = new Color[size_x * size_y];
            Color grey = new Color(97 ,97 ,97);
            Color black = new Color(0  ,0 , 0);
            Color  brown = new Color(130 ,85 ,0, 255);
            Color LightBrown = new Color(184,121,4,255);
            this.RightAngle = RightAngle;
            
            int dem= 0 ;
            for(int i = 0 ;  i< size_y; i++)
            {
                for(int j = 0 ; j < size_x ; j++)
                {
                    if(i <= Edgesize || j <= Edgesize || j >= size_x - Edgesize)
                    {
                        data[dem] = black;
                        dem++;
                        continue;
                    }
                    if(i >= size_y - Edgesize)
                    { 
                        data[dem] = black;
                        dem++;
                        continue;
                    }
                    data[dem] = brown;
                    dem++;
                }
            }
            this.BlackSquare   = SQUARE.CreateRightAngle(this.Edgesize ,  _graphics , Color.Black);
            this.GreySquare  = SQUARE.CreateRightAngle(this.Edgesize , _graphics , grey);
            this.BrownSquare = SQUARE.CreateRightAngle(this.Edgesize , _graphics , LightBrown);
            rect.SetData(data);
            return rect;
        }
        public int Draw_x; 
        public int Draw_y;
        public int End_x;
        public int End_y;
        public int size_x ; 
        public int size_y;
        List<Stuff> Stuffs = new List<Stuff>(); 

        public int StuffSize_x ;

        public int StuffSize_y;

        public int Width;

        public int Height;
        public Inventory(int Width , int Height ,int Edgesize, int size_y ,GraphicsDeviceManager _graphics)
        {
            this.size_y = size_y;
            this.Edgesize = Edgesize;
            this.size_x =Width -  Width / 3;
            this.End_y = Height - Edgesize - Edgesize ;
            this.End_x = Width - Edgesize - Edgesize ;
            this.Draw_x = End_x - size_x;
            this.Draw_y = End_y - size_y;

            this.Width = End_x - Edgesize *3  - (Draw_x +Edgesize* 3);
            this.Height = End_y - Edgesize * 3 -  (Draw_y + Edgesize   * 3); 
            Vector2 mid = new Vector2(Draw_x + (End_x - Draw_x)/2 , Draw_y + (End_y - Draw_y) / 2);
            int x = Draw_x + Edgesize*3 ;
            int y = Draw_y + Edgesize*3;

            int EndX = End_x - Edgesize*3;
            int EndY = End_y - Edgesize*3;
            StuffSize_x = (EndX - x)/8;      
            StuffSize_y  = (EndY - y) / 6;

            int pre_end_x = x  ;
            int pre_end_y = y;
            for(int temp_y = 0 ;  temp_y < 6 ; temp_y++)
            {
                pre_end_x  = x;
                for(int temp_x = 0 ; temp_x < 8 ; temp_x++)
                {
                    Stuff temp = new Stuff(pre_end_x , y , StuffSize_x,StuffSize_y , _graphics);
                    pre_end_x = temp.End_x;
                    pre_end_y = temp.End_y;
                    Stuffs.Add(temp);
                }
                y= pre_end_y;
            }



            Shape = CreateInventory(this.size_x, this.size_y , _graphics , Edgesize);
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(this.Shape, new Vector2(Draw_x , Draw_y) , Color.White);
            _spriteBatch.Draw(this.GreySquare , new Vector2(Draw_x , Draw_y) , Color.White);
            _spriteBatch.Draw(this.GreySquare , new Vector2(End_x -Edgesize , End_y -Edgesize), Color.White);
            _spriteBatch.Draw(this.GreySquare , new Vector2(Draw_x , End_y - Edgesize) ,Color.White);
            _spriteBatch.Draw(this.GreySquare , new Vector2(End_x - Edgesize , Draw_y) , Color.White);
            #region LeftSquareTop
            _spriteBatch.Draw(this.BlackSquare , new Vector2(Draw_x+Edgesize, Draw_y+Edgesize ) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(Draw_x +  Edgesize + Edgesize , Draw_y + Edgesize) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(Draw_x + Edgesize,Draw_y + Edgesize + Edgesize) , Color.White);
            #endregion
            
            
            #region  LeftSquareBot
            _spriteBatch.Draw(this.BlackSquare , new Vector2(Draw_x + Edgesize ,End_y - Edgesize*2) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(Draw_x + Edgesize*2 , End_y - Edgesize*2) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(Draw_x + Edgesize ,End_y - Edgesize*3 ),Color.White);
            #endregion
            
            #region RightSquareTop
            _spriteBatch.Draw(this.BlackSquare , new Vector2(End_x - Edgesize *2 ,Draw_y + Edgesize ) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(End_x - Edgesize *3 , Draw_y + Edgesize) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(End_x - Edgesize*2 , Draw_y + Edgesize*2) , Color.White);
            #endregion

            #region RightSquareBot
            _spriteBatch.Draw(this.BlackSquare , new Vector2(End_x - Edgesize *2 ,End_y - Edgesize*2 ) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(End_x - Edgesize *3 , End_y - Edgesize*2) , Color.White);
            _spriteBatch.Draw(this.BlackSquare , new Vector2(End_x - Edgesize*2 , End_y - Edgesize*3) , Color.White);
            #endregion
            

            #region Decoration
            int x = Draw_x +  Edgesize + Edgesize + Edgesize , y =  Draw_y + Edgesize;
            for(; x <= End_x - Edgesize * 3 ; x+=Edgesize)
            {
                _spriteBatch.Draw(this.BrownSquare , new Vector2(x , y) , Color.White);
                _spriteBatch.Draw(this.BrownSquare , new Vector2(x , End_y - Edgesize *2) , Color.White);
            }
            x = Draw_x + Edgesize + Edgesize + Edgesize;

            x = Draw_x + Edgesize;
            y = Draw_y + Edgesize*3;
            for(; y <= End_y - Edgesize * 4 ; y+=Edgesize)
            {
                _spriteBatch.Draw(this.BrownSquare , new Vector2( x , y) , Color.White);
                _spriteBatch.Draw(this.BrownSquare , new Vector2(End_x - Edgesize*2,y) , Color.White);
            }
            _spriteBatch.Draw(this.BrownSquare , new Vector2(x , End_y - Edgesize*4) , Color.White);
            _spriteBatch.Draw(this.BrownSquare , new Vector2(End_x - Edgesize*2 , End_y - Edgesize*4 ), Color.White);
            

            // dư
            _spriteBatch.Draw(this.BrownSquare , new Vector2(Draw_x + Edgesize *2 , End_y - Edgesize*3) , Color.White);
            _spriteBatch.Draw(this.BrownSquare , new Vector2(Draw_x + Edgesize *2 , Draw_y + Edgesize*2) , Color.White);
            _spriteBatch.Draw(this.BrownSquare , new Vector2(End_x - Edgesize*3 , End_y - Edgesize*3) , Color.White);
            _spriteBatch.Draw(this.BrownSquare , new Vector2(End_x - Edgesize*3 , Draw_y + Edgesize*2) , Color.White);

            #endregion

            foreach(var invent in Stuffs)
            {
                invent.Draw(_spriteBatch);
            }
        
        
        }
    }
    

    #region PLAYERDEMO
    public class PLAYERDEMO 
    {
        private int RightAngle;
        private int Edgesize;

        private Texture2D HeavyGrey; 

        private Texture2D LightGrey;
        public Texture2D CreateShape(int size_x , int size_y ,int RightAngle ,int Edgesize,GraphicsDeviceManager _graphics)
        {
            Texture2D rect = new Texture2D(_graphics.GraphicsDevice , size_x , size_y);
            Color[] data = new Color[size_x * size_y];

            Color grey = new Color(112,110,106,255);
            Color heavy_Grey = new Color(46,45,46);
            Color black = Color.Black;
            Color lightgrey = new Color(92 ,92 ,92);
            this.RightAngle = RightAngle;
            this.Edgesize = Edgesize;

            int dem= 0 ;
            for(int i = 0 ;  i< size_y; i++)
            {
                for(int j = 0 ; j < size_x ; j++)
                {
                    if(i <= Edgesize || j <= Edgesize || j >= size_x - Edgesize)
                    {
                        data[dem] = black;
                        dem++;
                        continue;
                    }
                    if(i >= size_y - Edgesize)
                    { 
                        data[dem] = black;
                        dem++;
                        continue;
                    }
                    data[dem] = grey;
                    dem++;
                }
            }
            HeavyGrey = SQUARE.CreateRightAngle(Edgesize , _graphics , heavy_Grey);
            LightGrey = SQUARE.CreateRightAngle(Edgesize , _graphics ,lightgrey );
            rect.SetData(data);
            return rect;
        }


        public Player player ;
        public int Draw_x ;

        public int Draw_y; 

        public int size_x;
        public int size_y;

        public int End_x ;
        public int End_y ;

        public Texture2D Shape;

        
        
        public virtual void Draw(SpriteBatch  _spriteBatch)
        {
            _spriteBatch.Draw(this.Shape , new Vector2(Draw_x, Draw_y) , Color.White);
            //_spriteBatch.Draw(this.HeavyGrey , new Vector2(Draw_x , Draw_y) , Color.White);
            //_spriteBatch.Draw(this.HeavyGrey , new Vector2(Draw_x , End_y - Edgesize )  , Color.White);
            //_spriteBatch.Draw(this.HeavyGrey , new Vector2(End_x - Edgesize , Draw_y) , Color.White);
            //_spriteBatch.Draw(this.HeavyGrey , new Vector2(End_x - Edgesize , End_y -Edgesize ) , Color.White);
            

            int x = Draw_x + Edgesize;
            int y = Draw_y + Edgesize;
            for( ; x <= End_x - Edgesize*2; x+= Edgesize)
            {
                _spriteBatch.Draw(this.LightGrey , new Vector2(x , y) , Color.White);
                _spriteBatch.Draw(this.LightGrey , new Vector2(x , End_y - Edgesize -Edgesize) , Color.White);
            }
            _spriteBatch.Draw(this.LightGrey , new Vector2(End_x - Edgesize*2 , End_y - Edgesize*2) , Color.White);
            _spriteBatch.Draw(this.LightGrey , new Vector2( End_x - Edgesize*2 , Draw_y + Edgesize) , Color.White);
            x = Draw_x + Edgesize;
            y = Draw_y + Edgesize;
            for(;y <= End_y - Edgesize *2 ; y+= Edgesize )
            {
                _spriteBatch.Draw(this.LightGrey , new Vector2(x , y) , Color.White);
                _spriteBatch.Draw(this.LightGrey , new Vector2(End_x - Edgesize*2 , y) , Color.White);
            }

            x = Draw_x + Edgesize;
            y = Draw_y + Edgesize;
            for(int i = 1 ; i <= 3 ; i++)
            {
                _spriteBatch.Draw(this.HeavyGrey , new Vector2(x +  Edgesize *(i-1) , y) , Color.White);
            }
            y += Edgesize;
            for(int i = 1 ; i <= 3 ; i++)
            {
                _spriteBatch.Draw(this.HeavyGrey , new Vector2(x  , y+ Edgesize *(i-1)) , Color.White);
            }
            _spriteBatch.Draw(this.LightGrey , new Vector2(Draw_x + Edgesize*2 , Draw_y+Edgesize *2) , Color.White);
            _spriteBatch.Draw(this.LightGrey , new Vector2(End_x - Edgesize *3 , End_y - Edgesize *3 ) , Color.White);
            
            x = End_x - Edgesize *2;
            y = End_y - Edgesize *2;
           // _spriteBatch.Draw(this.End_x - Edgesize -Edgesize ,this.End_y - Edgesize)
            for(int i = 1 ; i <= 3 ; i++)
            {
                _spriteBatch.Draw(this.HeavyGrey , new Vector2(x , y - Edgesize *(i-1)) , Color.White);
            }
            for(int i = 1 ; i <= 3 ; i++)
            {
                _spriteBatch.Draw(this.HeavyGrey , new Vector2(x - Edgesize*(i-1) , y) ,Color.White);
            }
            int mid = (End_x - Draw_x)/2;
            x  = Draw_x + Edgesize;
            y = Draw_y + Edgesize;
            x += mid/100;
            mid = (End_y - Draw_y)/2;
            y += mid/25;

            player.Draw(_spriteBatch , size_x ,size_y , x,  y);
        
        
        }


        public PLAYERDEMO(int Screen_Width, int Edgesize,int Screen_Height, Player player ,int MinWidth , int MinHeight , int MaxWidth , int MaxHeight , GraphicsDeviceManager _graphics)
        {
            size_x = Screen_Width/15;
            size_y = Screen_Height/5;
            
            int mid = MinWidth + (MaxWidth - MinHeight)/2;
            Draw_x = mid - size_x /2;
            mid = MinHeight +(MaxHeight - MinHeight)/2;
            Draw_y = mid + size_y /3;
            this.player = player;
            size_x =MaxWidth - (Draw_x -MinWidth + Edgesize) *2  ; 
            End_x = Draw_x + size_x;
            End_y = Draw_y + size_y;

            this.Shape = CreateShape(size_x , size_y , Edgesize/2 , Edgesize/2 , _graphics);
        }
    }

    #endregion

    




    

    
    #region InventoryStuff 
    
   public class Stuff
    {
        public int Draw_x;
        public int Draw_y ;

        public int size;

        public int End_x; 
    
        public int End_y ;
        private Texture2D Shape;
        
        private Color COLOR = new Color(130 , 85 , 0 , 255) ;

        private Color EdgeColor  = new Color(255,255,255,255);
        
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(this.Shape, new Vector2(Draw_x, Draw_y) , Color.White);
        }
        
        public int size_x ;
        
        public int size_y;

        public int Edgesize;

        public Stuff(int x , int y  , int size_x , int size_y, GraphicsDeviceManager _graphics )
        {
            Draw_x = x;
            Draw_y = y ;
            this.Edgesize = (int)size_x/ 100;
            this.size_x = size_x;
            this.size_y = size_y;
            this.End_x = Draw_x + size_x    ;
            this.End_y = Draw_y + size_y   ;
            
            this.Shape   = SQUARE.CreateStuffBoard(size_x , size_y,  this.Edgesize, _graphics , EdgeColor,COLOR);
        }
    }
    


 
    
    
    



    
    #endregion 
    public class InventoryBoard
    {
        private MAINRECTANGLE MainBoard;
        
        private STEPMAINBOARD StepSister;

        private Inventory INVENTORY;

        private PLAYERDEMO PlayerDemo;

        public  bool IsOpen = false;
        
        
        
        public InventoryBoard(int Width , int Height, GraphicsDeviceManager _graphics , Player player)
        {
            ChangeSettings(Width , Height , _graphics , player);
        }


        public virtual void  Open(SpriteBatch  _spriteBatch , GraphicsDeviceManager _graphics) 
        {
            if(IsOpen == false)return ;
            _spriteBatch.Begin();
            
            
            MainBoard.Draw(_spriteBatch);
            StepSister.Draw(_spriteBatch);
            INVENTORY.Draw(_spriteBatch);
            PlayerDemo.Draw(_spriteBatch);
            _spriteBatch.End();
            
        }

        public void ChangeSettings(int Width, int Height , GraphicsDeviceManager _graphics , Player player)
        {
            MainBoard = new MAINRECTANGLE(Width , Height , _graphics);
            StepSister = new STEPMAINBOARD(MainBoard.Draw_x , MainBoard.Draw_y , MainBoard.End_x , MainBoard.End_y , _graphics);
            INVENTORY = new Inventory(StepSister.End_x , StepSister.End_y , StepSister.Edgesize ,(StepSister.End_y - StepSister.Edgesize *2) - (StepSister.Draw_y + StepSister.Edgesize*2), _graphics);
            PlayerDemo = new PLAYERDEMO(Width, StepSister.Edgesize  , Height ,player , StepSister.Draw_x  , StepSister.Draw_y , INVENTORY.Draw_x , INVENTORY.Draw_y , _graphics);
        }
    }
}
