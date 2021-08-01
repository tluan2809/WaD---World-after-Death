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
//using WaD___World_after_Death.Code.LOGIC; // thư viện logic của tôi
using WaD___World_after_Death.Code.setting;

namespace WaD___World_after_Death.Code.LOGIC
{
    public class Input
    {
        public static  Keys Up  = Keys.W ;

        
        public static Keys Down = Keys.D ;

        public static  Keys Left = Keys.Left;

        public static Keys Right = Keys.Right;

        public static Keys OPEN_SETTINGS = Keys.Escape;
    
        public static Keys Sub_Up = Keys.Up;
        
        public static Keys Sub_Left = Keys.Left;

        public static  Keys Sub_Right = Keys.Right;

        public static Keys Sub_Down = Keys.Down;

        public static Keys OPENINVENTORY  = Keys.E;

        public static Keys Run = Keys.LeftShift;

        public static Keys OpenSettings = Keys.Escape;
    }
}