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

private Enemy dummy;
private Enemy tester;

[SetUp]
    public void InitializeEnemy() {
        Window.CreateOpenGLContext();
        dummy = new Enemy( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"))), false, false);
        tester = new Enemy(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"))), false, false);
        hardTester = new Enemy(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"))), true, false); 
        unbreakTester = new Enemy(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"))), false, true);  
    }
[Test]
    public void NotHitTest() {
        Assert.AreEqual(tester.getHP(), dummy.getHP());
        Assert.AreEqual(tester.getSpeed(),dummy.getSpeed());
        Assert.False(tester.isDead());
    }
[Test]
    public void HitOnceTest() {
        tester.isHit();
        Assert.AreEqual(tester.getHP(), dummy.getHP()-2);
        Assert.False(tester.isDead());
    }




}