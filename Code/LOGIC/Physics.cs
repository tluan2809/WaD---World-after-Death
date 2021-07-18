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


namespace WaD___World_after_Death.Code.LOGIC
{
    public class Physical
    {
        // generated static variable for physic
        public static float gravity = 10f ;

    }
    public class PlayerPhysic  
    {

        protected Vector2 position ;
        
        protected Vector2 oldPosition  =  Vector2.Zero;
        protected Vector2 Velocity = Vector2.Zero;
        public PlayerPhysic(Vector2 position)
        {
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }
        
    }
}