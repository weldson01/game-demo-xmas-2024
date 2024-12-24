

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameAssets
{
    class Background
    {
        private Texture2D Texture;
        private Vector2 Position;
        private List<Rectangle> Animation;
        private int AnimationStep = 0;
        private int AnimationCount = 0;
        private int SpriteWidth;
        private int SpriteHeight;

        public Background(Vector2 position, Texture2D texture, int spriteCount, int spriteWidth, int spriteHeight)
        {
            this.Position = position;
            this.Texture = texture;
            this.SpriteWidth = spriteWidth;
            this.SpriteHeight = spriteHeight;
            this.AnimationCount = spriteCount;
            SetAnimation();
        }

        public void Update()
        {

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
            AnimationStep = AnimationStep < AnimationCount - 1 ? AnimationStep + 1 : 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Animation[AnimationStep], Color.White);
            spriteBatch.End();
        }
    }
}