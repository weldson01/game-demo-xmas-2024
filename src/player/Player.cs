
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameAssets
{
    class Player
    {
        public string Name { get; set; }
        private Vector2 Position;
        private Vector2 Velocity = new Vector2(0, 0);
        private float Speed = 5f;
        private Texture2D Texture;
        private List<Rectangle> Animation;
        private int AnimationStep = 0;
        private int AnimationCount = 0;
        private SpriteEffects AnimationEffects = SpriteEffects.None;
        private int SpriteCount;
        private int SpriteWidth;
        private int SpriteHeight;
        private int ValidSprits;
        public Player(Vector2 position, Texture2D texture, int spriteCount, int spriteWidth, int spriteHeight)
        {
            this.Position = position;
            this.Texture = texture;
            this.SpriteCount = spriteCount;
            this.SpriteWidth = spriteWidth;
            this.SpriteHeight = spriteHeight;
            this.AnimationCount = spriteCount;
            this.ValidSprits = spriteCount;
            SetAnimation();
        }
        public Player(Vector2 position, Texture2D texture, int spriteCount, int spriteWidth, int spriteHeight, int validSprits) : this(position, texture, spriteCount, spriteWidth, spriteHeight)
        {
            this.ValidSprits = validSprits;
        }

        private void SetAnimation()
        {
            Animation = new List<Rectangle>();
            for (int i = 0; i < AnimationCount; i++)
            {
                Animation.Add(new Rectangle(i * SpriteWidth, 0, SpriteWidth, SpriteHeight));
            }
        }
        private void SetAnimationStep()
        {
            AnimationStep = AnimationStep < ValidSprits - 1 ? AnimationStep + 1 : 0;
        }

        private void SetAnimationEffects()
        {
            if (Velocity.X < 0) AnimationEffects = SpriteEffects.FlipHorizontally;
            if (Velocity.X > 0) AnimationEffects = SpriteEffects.None;
        }

        public void Update(KeyboardState keyboard, SpriteBatch spriteBatch)
        {
            Inputs(keyboard);
            SetAnimationEffects();
            Position = Velocity * Speed + Position;
            Draw(spriteBatch);
        }

        public void Inputs(KeyboardState keyboard)
        {
            Velocity = new Vector2(0, 0);
            if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A)) Velocity.X -= 1;
            if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D)) Velocity.X = 1;
            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up)) Velocity.Y -= 1;
            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down)) Velocity.Y = 1;
            if (Velocity != new Vector2(0, 0)) SetAnimationStep();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Animation[AnimationStep], Color.White, 0f, new Vector2(0, 0), 1, AnimationEffects, 0f);
            spriteBatch.End();
        }
    }
}