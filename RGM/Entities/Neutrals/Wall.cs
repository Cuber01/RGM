using Microsoft.Xna.Framework;
using RGM.Entities.Projectiles;
using RGM.General.Collision;
using RGM.General.ContentHandling.Assets;
using RGM.General.ContentHandling.Rooms;

// Static imports. ono.
using static RGM.RGM;

namespace RGM.Entities.Neutrals
{
    public class Wall : Entity
    {
        private readonly dTileDirection direction;
        
        // TODO this will initialize only once, right?
        private static readonly Rectangle[] spritesheetPositions =
        {
            // walls
            new Rectangle(tileSize,     tileSize * 2, tileSize, tileSize),   // up
            new Rectangle(tileSize,     0,            tileSize, tileSize),   // down
            new Rectangle(0,            tileSize,     tileSize, tileSize),   // right
            new Rectangle(tileSize * 2, tileSize,     tileSize, tileSize),   // et cetera, see tileDirection.cs for details 
            
            // corners
            new Rectangle(tileSize * 2, 0, tileSize, tileSize),
            new Rectangle(0, 0, tileSize, tileSize),
            new Rectangle(tileSize * 2, tileSize * 2, tileSize, tileSize),
            new Rectangle(0, tileSize * 2, tileSize, tileSize),
        };

        public Wall(Vector2 position, dTileDirection direction)
        {
            this.position = position;
            this.direction = direction;
            this.texture  = AssetLoader.textures[dTextureKeys.tiles1];

            this.myHeight = RGM.tileSize;
            this.myWidth = RGM.tileSize;

            if (direction == dTileDirection.up)
            {
                
                this.collider = new Hitbox(new Vector2(position.X, position.Y + 2), myWidth, myHeight + 2);
                
            } else if (direction == dTileDirection.down)
            {
                
                this.collider = new Hitbox(position, myWidth, myHeight - 2);
                
            }
            if ((int)direction >= 4)
            {
                this.myWidth  = RGM.tileSize; 
                this.myHeight = RGM.tileSize;
            }
            
            
            this.tilePosition = Util.pixelPositionToTilePosition(position, myWidth, myHeight);

            this.team = dTeam.neutrals;
            this.collider = new Hitbox(position, myWidth, myHeight);
        }

        public override void draw()
        {
            RGM.spriteBatch.Draw(texture, position, spritesheetPositions[(int)direction], Color.White);
        }
    }
}