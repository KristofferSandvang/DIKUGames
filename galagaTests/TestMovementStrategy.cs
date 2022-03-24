using NUnit.Framework;
using Galaga;
using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
using System.Collections.Generic;
using Galaga.MovementStrategy;
namespace galagaTests; 

[TestFixture]
public class TestMovementStrategy {
    private Enemy tester;
    private Enemy dummy;
    private IMovementStrategy noMove;
    private IMovementStrategy down;
    private IMovementStrategy zigZagDown;
    
    [SetUp]
public void InitializeEnemy() {
        Window.CreateOpenGLContext();
        tester = new Enemy(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png")))); 
        dummy = new Enemy(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png")))); 
        noMove = new NoMove();
        down = new Down();
        zigZagDown = new ZigZagDown();   
    }

    [Test]
    public void EnemyNoMoveXTest() {
        noMove.MoveEnemy(tester);
        Assert.AreEqual(tester.Shape.Position.X, dummy.Shape.Position.X); 
    }
    [Test]
    public void EnemyNoMoveYTest() {
        noMove.MoveEnemy(tester);
        Assert.AreEqual(tester.Shape.Position.Y, dummy.Shape.Position.Y);
    }

    [Test]
    public void DownTest() {
        down.MoveEnemy(tester);
        Assert.AreEqual(tester.Shape.Position.X, dummy.Shape.Position.X);
        Assert.Less(tester.Shape.Position.Y, dummy.Shape.Position.Y);
    }

    [Test]
    public void ZigZagDownXTest() {
            for(int i=0;i<200;i++){
            zigZagDown.MoveEnemy(tester);
            Assert.AreNotEqual(tester.Shape.Position.X,dummy.Shape.Position.X);
            }
    //Works because MoveEnemy moves the enemy in small distances, 
    //skipping the original x position
    }
    
    [Test]
    public void ZigZagDownYTest() {
        zigZagDown.MoveEnemy(tester);
        Assert.AreEqual(tester.Shape.Position.Y, dummy.Shape.Position.Y - tester.getSpeed());
    }
}
