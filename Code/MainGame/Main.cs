﻿using System;
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
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Settings settings; 
        
        
        
        #region ALL ABOUT THE PLAYER 
        private string skin;
        private Player player;
        public void LoadPlayer()
        {
            skin = "Assets/Player/male_character";
            player = new Player(new Vector2(settings.Width / 2, settings.Height / 2), skin , settings.Width , settings.Height );
        }
        #endregion
        
        
        
        #region Settings
        private void GameStart() // function sẽ được gọi khi game bắt đầu nhằm init cửa sổ các thứ
        {
            int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            settings = new Settings(width, height);
            LoadPlayer();
        }

        private void LoadSettings()
        {
            if(settings.FullScreen)
            {
                _graphics.IsFullScreen = true;
            }
            _graphics.PreferredBackBufferWidth = settings.Width;
            _graphics.PreferredBackBufferHeight = settings.Height;
            _graphics.ApplyChanges();
        }

        #endregion



        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            GameStart();
        }

        protected override void Initialize()
        {

            LoadSettings();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime , _spriteBatch , _graphics);
            if(FixedUpdate.previousT == 0)
            {
                FixedUpdate.previousT =(float) gameTime.TotalGameTime.TotalMilliseconds;
            }

            float now = (float)gameTime.TotalGameTime.TotalMilliseconds;
            float frameTime = now - FixedUpdate.previousT;
            if(frameTime > FixedUpdate.maxFrameTime)
            {
                frameTime = FixedUpdate.maxFrameTime;
            }

            FixedUpdate.previousT = now;

            FixedUpdate.accumulator += frameTime;

            while(FixedUpdate.accumulator >=FixedUpdate.FixedUpdateDelta )
            {
                FixedUpdate.accumulator -=FixedUpdate.FixedUpdateDelta;
            }

            FixedUpdate.ALPHA = (FixedUpdate.accumulator/FixedUpdate.FixedUpdateDelta);
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            player.Draw(_spriteBatch);


            base.Draw(gameTime);
        }
    }

     
    #region JUST TO RUN THE PROGRAM , IT'S USELESS
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    
    }
    #endregion

}
