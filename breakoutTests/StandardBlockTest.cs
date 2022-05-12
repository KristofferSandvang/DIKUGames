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

private StandardBlock dummy;
private StandardBlock tester;


[SetUp]
    public void InitializeEnemy() {
        Window.CreateOpenGLContext();
        dummy = new StandardBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))));
        tester = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))));
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

}