using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Galaga.Squadron {
    public class VFormation : ISquadron {
        public EntityContainer<Enemy> Enemies {get;}
        public int MaxEnemies {get;}
        
        public VFormation() {
            MaxEnemies = 7;
            Enemies = new EntityContainer<Enemy>(MaxEnemies);
        }
        public void CreateEnemies (List<Image> enemyStride) {
            for (int i = 0; i < MaxEnemies; i++) {
                if (i < 4) {
                    float x = 0.1f + (float)i * 0.1f;
                    float y = 0.9f - (float)i * 0.05f;
                    Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(x, y),
                    new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));
                } else if (i >= 4) {
                    float x = 0.4f + (float)(i-3) * 0.1f;
                    float y = 0.75f + (float)(i-3) * 0.05f;
                    Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(x, y),
                    new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));
                }
            }
        } 
    }
}
