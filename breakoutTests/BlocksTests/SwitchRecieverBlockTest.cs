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
using Breakout.Blocks; 

#pragma warning disable 0472
#pragma warning disable 8618

namespace breakoutTests;

public class SwitchRecieverBlockTest {

private SwitchRecieverBlock dummy;
private StandardBlock standardDummy; 
private SwitchRecieverBlock tester;


    [SetUp]
    public void InitializeBlocks() {
        Window.CreateOpenGLContext();
        dummy = new SwitchRecieverBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        tester = new SwitchRecieverBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
    }

    //Test that the SwitchRecieverBlock is instaniziated at the full hp, 
    //And that the SwitchRecieverBlock is not detected as dead at this point.
    [Test]
    public void InitialHPTest() {
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
        Assert.False(tester.IsDead());
    }

    //Test that the SwitchRecieverBlock loses no health after getting hit as it can only die after switch.
    [Test]
    public void NoDamageTest() {
        tester.Hit();
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
    }

    //Tests that the SwitchRecieverBlock takes less damage than a normal block (as it should take none)
    [Test]
    public void LessDamageTest() {
        Assert.AreEqual(tester.hitPoints, standardDummy.hitPoints);
        tester.Hit();
        standardDummy.Hit();
        Assert.Greater(tester.hitPoints, standardDummy.hitPoints);
    }

    //Tests that the UnbreakableBlock never dies and has taken no damage
    [Test]
    public void NotDeadTest() {
        for (int i = 0; i <= 10000; i++){
            tester.Hit();
        }
        Assert.False(tester.IsDead());
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);; 
    }
    
    //Tests that the SwitchRecieverBlock is given a value property as per the requirements
    [Test]
    public void HasValue() {
        Assert.True(tester.value != null);
    }
    
    
    //Tests that the SwitchRecievreBlock is an entity, by testing that it has a shape
    //Testing of Image is done by hand, when running the game
    [Test]
    public void IsEntity() {
        Assert.True(tester.shape != null);
    }
}