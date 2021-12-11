using EnterTheGuncave.Content;
using Microsoft.Xna.Framework;

namespace EnterTheGuncave.Entities.Projectile
{
    public class Bullet : Entity
    {
        private Vector2 target;

        private BulletStats stats;

        public Bullet(int targetX, int targetY, Vector2 position, BulletStats stats)
        {
            this.position = position;
            this.texture = AssetLoader.textures["bullet"];
            this.myWidth  = texture.Width  / EnterTheGuncave.scale;
            this.myHeight = texture.Height / EnterTheGuncave.scale;

            ( this.target.X, this.target.Y ) = ( targetX, targetY );
            this.stats = stats;
            
            goToPoint();
        }

        public override void update()
        {
            move();
        }

        private void goToPoint()
        {
            float dist = Util.calculateDistance(position, target);
            this.velocity.X = (target.X - position.X) / dist;
            this.velocity.Y = (target.Y - position.Y) / dist;
        }
        
        private void move()
        {
            position += velocity * stats.speed;
        }

    }
}