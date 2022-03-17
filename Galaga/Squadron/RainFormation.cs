using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Galaga.Squadron {
    public class RainFormation : ISquadron {
        public EntityContainer<Enemy> Enemies {get;}
        public int MaxEnemies {get;}
        
        public RainFormation() {
            MaxEnemies = 20;
            Enemies = new EntityContainer<Enemy>(MaxEnemies);
        }
        public void  CreateEnemies (List<Image> enemyStride) {
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.2f, 1.0f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.8f, 1.0f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride))); 

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.3f, 1.1f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));  

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.7f, 1.1f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride))); 

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.4f, 1.2f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride))); 

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.6f, 1.2f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));  

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.45f, 1.3f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.55f, 1.3f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.3f, 1.4f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));  
             
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.7f, 1.4f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.6f, 1.5f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.4f, 1.5f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.3f, 1.6f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.7f, 1.6f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.25f, 1.7f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.75f, 1.7f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.35f, 1.8f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.65f, 1.8f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   

            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.40f, 1.9f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));   
            
            Enemies.AddEntity(new Enemy(new DynamicShape(new Vec2F(0.60f, 1.9f),
            new Vec2F(0.1f, 0.1f)), new ImageStride(80, enemyStride)));
        } 
    }
}
