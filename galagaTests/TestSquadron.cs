using NUnit.Framework;
using Galaga;
using System;
using System.IO;
using Galaga.Squadron;
using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;
using DIKUArcade;
#pragma warning disable 8618

namespace galagaTests;

[TestFixture]
public class TestSquadron {
    private ISquadron vFormation;
    private ISquadron squareFormation;
    private ISquadron rainFormation;
    private List<Image> enemyImage;

    [SetUp]
    public void InitializeSquadron() {
        vFormation = new VFormation();
        squareFormation = new SquareFormation();
        rainFormation = new RainFormation();
        enemyImage = ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"));
    }
    
    [Test]
    public void vFormationNumberOfEnemies() {
        vFormation.CreateEnemies(enemyImage);
        Assert.AreEqual(vFormation.Enemies.CountEntities(), vFormation.MaxEnemies);
    }
    [Test]
    public void squareFormationNumberOfEnemies() {
        squareFormation.CreateEnemies(enemyImage);
        Assert.AreEqual(squareFormation.Enemies.CountEntities(), squareFormation.MaxEnemies);
    }
    [Test]
    public void rainNumberOfEnemies() {
        rainFormation.CreateEnemies(enemyImage);
        Assert.AreEqual(rainFormation.Enemies.CountEntities(), rainFormation.MaxEnemies);
        
    }
}

