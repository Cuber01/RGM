﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EnterTheGuncave
{
    public class EnterTheGuncave : Game
    {
        
        private readonly List<Entity> entities = new List<Entity>();

        public const int roomWidth = 15;
        public const int roomHeight = 9;

        public const int tileSize = 16;
        private const int scale = 2;

        private const int windowWidth = roomWidth * tileSize * scale;
        private const int windowHeight = roomHeight * tileSize * scale;

        private readonly Matrix scaleMatrix = Matrix.CreateScale(scale, scale, 1.0f);
        private readonly GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public EnterTheGuncave()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth  = windowWidth;  
            graphics.PreferredBackBufferHeight = windowHeight; 
            graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetLoader assetLoader = new AssetLoader(Content);
            
            assetLoader.loadTextures();
            
            entities.Add(new Player(new Vector2(50, 50)));
            entities.Add(new WalkingEnemy(new Vector2(80, 80)));
        }

        protected override void Update(GameTime gameTime)
        {

            Input.updateKeyboardState();
            
            foreach( Entity entity in entities)
            {
                entity.update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix);
            
            foreach( Entity entity in entities )
            {
                entity.draw();
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}