using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
namespace Galaga.Squadron {
    public class SquareFormation : ISquadron {
        public EntityContainer<Enemy> Enemies {get;}
        public int MaxEnemies {get;}
        
        public SquareFormation() {
            MaxEnemies = 18;
            Enemies = new EntityContainer<Enemy>(MaxEnemies);
        }
        /// <summary> Create enemies into a squadron given list of images </summary>
        /// <param name='enemyStride'> 
        /// the list of enemies you are creating into the squadron
        /// </param>
        public void CreateEnemies (List<Image> enemyStride) {
            for (int i = 0; i < MaxEnemies; i++) {
                if (i < 8) {
                    Enemies.AddEntity(new Enemy(
                        new DynamicShape(new Vec2F(0.1f + (float)i * 0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                        new ImageStride(80, enemyStride)));
                } else if (i == 8) {
                    Enemies.AddEntity(new Enemy(
                        new DynamicShape(new Vec2F(0.1f, 0.8f), new Vec2F(0.1f, 0.1f)),
                        new ImageStride(80, enemyStride)));
                } else if (i == 9) {
                    Enemies.AddEntity(new Enemy(
                        new DynamicShape(new Vec2F(0.8f, 0.8f), new Vec2F(0.1f, 0.1f)),
                        new ImageStride(80, enemyStride)));
                } else
                    Enemies.AddEntity(new Enemy(
                        new DynamicShape(new Vec2F(0.1f + (float)(i - 10) * 0.1f, 0.7f), new Vec2F(0.1f, 0.1f)),
                        new ImageStride(80, enemyStride)));
            }
        } 
    }
}
