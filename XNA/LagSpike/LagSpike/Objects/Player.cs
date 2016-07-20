using System;
using Microsoft.Xna.Framework;

    class Player : SpriteGameObject
    {
        public Player(string assetname = "", int layer = 0, int id = 0, int sheetIndex = 0)
            : base(assetname, layer, id, "player", sheetIndex)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }

