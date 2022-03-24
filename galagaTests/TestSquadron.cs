using NUnit.Framework;
using Galaga;
using System;
using System.IO;
using Galaga.Squadron;
using DIKUArcade.Entities;
using System.Collections.Generic;
using DIKUArcade.Graphics;

namespace galagaTests;

[TestFixture]
public class TestSquadron {
    private ISquadron vFormation;
    private ISquadron squareFormation;
    private ISquadron rainFormation;

    [SetUp]
    public void InitializeSquadron() {
        Window.CreateOpenGLContext();
        vFormation = new VFormation();
        squareFormation = new SquareFormation();
        rainFormation = new RainFormation();
    }
    
    [Test]
    public void vFormationNumberOfEnemies() {
        vFormation.CreateEnemies();
        Assert.AreEqual(vFormation.Enemies.CountEntities(), vFormation.MaxEnemies);
    }
    [Test]
    public void squareFormationNumberOfEnemies() {
        vFormation.CreateEnemies();
        Assert.AreEqual(squareFormation.Enemies.CountEntities(), sq.MaxEnemies);
    }
    [Test]
    public void rainNumberOfEnemies() {
        rainFormation.CreateEnemies();
        Assert.AreEqual(rainFormation.Enemies.CountEntities(), rainFormation.MaxEnemies);
        
    }
/*
    [Test]
    public void squareFormation() {
     //   Assert.Less((), 1);
    }

    [Test]
    public void rainFormation1() {
        rainFormation.CreateEnemies();
        Assert.AreEqual(rainFormation.Enemies[0].startY, 1.0);
        Assert.AreEqual(rainFormation.Enemies[0].startX, 0.2f);
    }*/

}