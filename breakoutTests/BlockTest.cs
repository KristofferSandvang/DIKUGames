using NUnit.Framework;
using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.State;
using Breakout;

namespace breakoutTests;

public class PlayerTest {

private Block dummy;
private Block tester;
private Block hardTester;
private Block unbreakTester;

[SetUp]
    public void InitializeEnemy() {
        Window.CreateOpenGLContext();
        dummy = new Block( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false, false);
        tester = new Block(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false, false);
        hardTester = new Block(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), true, false); 
        unbreakTester = new Block(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false, true);  
    }
[Test]
    public void NotHitTest() {
        Assert.AreEqual(tester.GetHP(), dummy.GetHP());
        Assert.False(tester.IsDead());
    }
[Test]
    public void HitOnceTest() {
        tester.Hit();
        Assert.AreEqual(tester.GetHP(), dummy.GetHP()-2);
        Assert.False(tester.IsDead());
    }
[Test]
    public void IsDeadTest() {
        for (int i = 0; i <= 4; i++){
            tester.Hit();
        }
        Assert.True(tester.IsDead());
    }
[Test]
    public void HardenedTest() {
        hardTester.Hit();
        dummy.Hit();
        Assert.Greater(hardTester.GetHP(),dummy.GetHP());
    }
[Test]
    public void UnbreakTest() {
        unbreakTester.Hit();
        Assert.AreEqual(unbreakTester.GetHP(),dummy.GetHP());
    }

}