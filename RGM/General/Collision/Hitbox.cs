using Microsoft.Xna.Framework;
using RGM.Entities;
using RGM.General.Graphics;

namespace RGM.General.Collision
{
    public class Hitbox
    {
        public Vector2      position;
        public readonly int width;
        public readonly int height;


        public Hitbox(Vector2 position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public Entity checkCollision(Entity otherEntity)
        {
            if(otherEntity.collider == this)
            {
                return null;
            }
            
            Hitbox otherHitbox = otherEntity.collider;
            
            if (position.X < otherHitbox.position.X + otherHitbox.width  &&
                position.X + width > otherHitbox.position.X              &&
                position.Y < otherHitbox.position.Y + otherHitbox.height &&
                height + position.Y > otherHitbox.position.Y)
            {
                return otherEntity;
            } 

            return null;
            
        }

        // TODO either drawing the hitbox or setting hitbox pos is too late
        public void draw(DrawUtils draw)
        {
            draw.drawRectangle(new Rectangle((int)position.X, (int)position.Y, width, height), Color.Red,false);
        }
    }
}