using System.Data;
using Microsoft.Xna.Framework;

namespace EnterTheGuncave.Entities.Projectiles
{
    public class Shooter
    {
        protected ShooterStats stats;

        protected Vector2 gunPosition;
        protected Vector2 targetPosition;
        
        protected int currentReloadTime;
        
        public void update(Vector2 gunPos, Vector2 targetPos)
        {
            this.gunPosition = gunPos;
            this.targetPosition = targetPos;
            
            // Can we shoot?
            if (reload())
            {
                // Yes we can!
                shoot();
            }
        }
        
        // Returns whether we're ready to shoot or not. Not a very nice name but I couldn't find a better one.
        private bool reload()
        {
            currentReloadTime--;

            if (currentReloadTime <= 0)
            {
                currentReloadTime = stats.reloadTime;
                return true;
            }

            return false;

        }
        
        protected virtual void shoot() {}
    }
    
    public class PistolShooter : Shooter
    {
        public PistolShooter(ShooterStats shooterStats)
        {
            this.stats = shooterStats;
            this.currentReloadTime = shooterStats.reloadTime;
        }

        protected override void shoot()
        {
            EnterTheGuncave.entitiesToBeSpawned.Add(new Bullet(targetPosition, gunPosition, stats.bulletStats));
        }
        
    }
}