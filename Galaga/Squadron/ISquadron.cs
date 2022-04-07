using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;
namespace Galaga.Squadron {
    public interface ISquadron {
        EntityContainer<Enemy> Enemies {get;}
        int MaxEnemies {get;}
        /// <summary> Create enemies into a squadron given list of images </summary>
        /// <param name='enemyStride'> 
        /// the list of enemies you are creating into the squadron
        /// </param>
        void CreateEnemies (List<Image> enemyStride);
    }
}