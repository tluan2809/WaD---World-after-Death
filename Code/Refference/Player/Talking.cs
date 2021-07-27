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

namespace  WaD___World_after_Death.Code
{
    public class CreateTalk
    {
        private string text;

        public  int Draw_x = 0;

        public  int Draw_y ;
        
        public  int size_x;

        public  int size_y;
        public  int End_x ;

        public  int End_y; 
        private SpriteFont font;

        private Color color;

        private Texture2D rect;
        public CreateTalk(string text,int Screen_Width , int Screen_Height , Color color , GraphicsDeviceManager _graphics , ContentManager Content)
        {
            size_x = Screen_Width;
            Draw_x = 0 ;
            this.text = text;
            End_x = Draw_x + Screen_Width;
            Draw_y =  Screen_Height/2 + Screen_Height/4;
            End_y = Screen_Height;
            size_y = End_y  - Draw_y;
            this.rect = SQUARE.CreateStuffBoard(size_x , size_y , size_x / 150 , _graphics , Color.White , Color.Black);
            font = Content.Load<SpriteFont>("Font/File");
            this.color  = color;
        }

        

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            int x = Draw_x + size_x / 150*2; // size_x / 150 là khoảng cách viền
            int y = Draw_y + size_x/150 *2;
            _spriteBatch.Draw(rect , new Vector2(Draw_x , Draw_y ) , Color.White);
            if (this.font != null)
            {
                _spriteBatch.DrawString(this.font, this.text, new Vector2(x , y),color);
            }
            _spriteBatch.End();
        }
    }
}