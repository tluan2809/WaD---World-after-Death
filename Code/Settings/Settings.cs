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
using WaD___World_after_Death.Code;
namespace WaD___World_after_Death.Code.setting
{
    public  class Settings
    {
        public int Width ;
        public int Height ;

        public bool FullScreen = true;
        public Settings(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}