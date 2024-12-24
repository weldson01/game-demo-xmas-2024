using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameAssets;
using System.Collections.Generic;
using System;

namespace XmasProject;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player player;
    private Texture2D merryChristmas;
    private Vector2 windowCenter;
    private List<Background> backgrounds = new List<Background>();
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
        windowCenter.X = GraphicsDevice.Viewport.Width / 2 - 180;
        windowCenter.Y = GraphicsDevice.Viewport.Height / 2 - 200;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        player = new Player(new Vector2(0, 0), Content.Load<Texture2D>("Cat_Run"), 14, 32, 32, 7);
        Texture2D tree = Content.Load<Texture2D>("Christmas Green Tree");
        merryChristmas = Content.Load<Texture2D>("Merry Christmas");
        Random random = new Random();
        for (int i = 0; i < 100; i++)
        {
            int axisX = random.Next(0, 1001);
            int axisY = random.Next(0, 1001);
            backgrounds.Add(new Background(new Vector2(axisX, axisY), tree, 41, 74, 123));
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update(Keyboard.GetState(), _spriteBatch);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        // TODO: Add your drawing code here
        backgrounds.ForEach(bg => bg.Draw(_spriteBatch));
        _spriteBatch.Begin();
        _spriteBatch.Draw(merryChristmas, windowCenter, Color.White);
        _spriteBatch.End();
        player.Draw(_spriteBatch);
        base.Draw(gameTime);
    }
}
