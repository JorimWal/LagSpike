using System;


    class Block : SpriteGameObject
    {
        public Block(string assetname, int layer = 0, int id = 0, string type = "", int sheetIndex = 0)
            :base(assetname, layer, id, type, sheetIndex)
        {
        }
    }

