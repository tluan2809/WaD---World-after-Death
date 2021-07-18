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
namespace WaD___World_after_Death.Code.LOGIC
{
    public class FixedUpdate
    {
        public static float FixedUpdateDelta = (int)(1000 / (float)30);
    
        public static float previousT = 0;
        public static float accumulator = 0.0f;
        public static float maxFrameTime = 250;

        public static float ALPHA = 0; 

    }
}
