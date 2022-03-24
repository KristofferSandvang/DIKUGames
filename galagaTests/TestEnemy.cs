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

namespace galagaTests;

public class TestEnemy {
    private Enemy dummy;
    private Enemy tester;

    [SetUp]
    public void InitializeEnemy() {
        Window.CreateOpenGLContext();
        dummy = new Enemy( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png"))));
        tester = new Enemy(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "BlueMonster.png")))); 
    }


    [Test]
    public void NotHitTest() {
        Assert.AreEqual(tester.getHP(), 10);
        Assert.AreEqual(tester.getSpeed(),dummy.getSpeed());
        Assert.False(tester.isDead());
    }


    [Test]
    public void HitOnceTest() {
        tester.isHit();
        Assert.AreEqual(tester.getHP(), 8);
        Assert.AreEqual(tester.getSpeed(),dummy.getSpeed());
        Assert.False(tester.isDead());
    }

    [Test]
    public void HitThriceTest() {
        tester.isHit();
        tester.isHit();
        tester.isHit();
        Assert.AreEqual(tester.getHP(), 4);
        Assert.Greater(tester.getSpeed(),dummy.getSpeed());
        Assert.False(tester.isDead());
    }

    [Test]
    public void IsDeadTest() {
        for (int i = 0; i <= 4; i++){
            tester.isHit();
        }
        Assert.True(tester.isDead());

    }
}