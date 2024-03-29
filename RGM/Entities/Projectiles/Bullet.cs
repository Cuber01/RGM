using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RGM.General.Collision;
using RGM.General.ContentHandling.Assets;

namespace RGM.Entities.Projectiles
{
    public class Bullet : Entity
    {
        private readonly List<Entity> alreadyHit = new List<Entity>();
        private readonly Vector2 target;
        private new BulletStats stats;

        public Bullet(Vector2 targetPos, Vector2 position, BulletStats stats, dTextureKeys textureKey)
        {
            this.position = position;
            this.texture = AssetLoader.textures[textureKey];
            this.myWidth  = texture.Width;
            this.myHeight = texture.Height;

            this.target = targetPos;
            this.stats = stats;
            
            this.collider = new Hitbox(position, myWidth, myHeight);
            goToPoint();
        }

        public override void update()
        {
            handleLifetime();
            
            move();
            
            checkCollision();
            adjustColliderPosition(position);
        }

        private void goToPoint()
        {
            float dist = Util.calculateDistance(position, target);
            this.velocity.X = (target.X - position.X) / dist;
            this.velocity.Y = (target.Y - position.Y) / dist;
        }

        private void handleLifetime()
        {
            stats.lifetime--;

            if (stats.lifetime <= 0)
            {
                dead = true;
            }
        }
        
        protected override void checkCollision()
        {
            foreach (Entity entity in RGM.entities)
            {
                if (collider.checkCollision(entity) == null) continue;
                if (entity.team == stats.team || entity is Bullet) continue;
                if (alreadyHit.Contains(entity)) continue;
                
                entity.takeDamage(stats.damage);
                alreadyHit.Add(entity);

                stats.penetration--;

                if (stats.penetration <= 0)
                {
                    dead = true;    
                }
                
            }
        }
        
        private void move()
        {
            position += velocity * stats.speed;
        }

    }
}