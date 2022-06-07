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
using Breakout.Blocks.BlockFactories;

namespace breakoutTests;

#pragma warning disable 0472
#pragma warning disable 8618

public class SwitchBlockTest {

private SwitchBlock dummy;
private SwitchBlock tester; 
private SwitchRecieverBlock switchReciever; 

    [SetUp]
    public void InitializeBlocks() {
        Window.CreateOpenGLContext();
        dummy = new SwitchBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        tester = new SwitchBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
    }

    //Test that the SwitchBlock is instaniziated at the full hp, 
    //And that the SwitchBlock is not detected as dead at this point.
    [Test]
    public void InitialHPTest() {
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
        Assert.False(tester.IsDead());
    }

    //Test that the SwitchBlock takes damage after getting hit.
    [Test]
    public void TakesDamageTest() {
        tester.Hit();
        Assert.Less(tester.hitPoints, dummy.hitPoints);
    }

    //Test that the SwitchBlock is able to die after getting hit enough times
    [Test]
    public void IsDeadTest() {
        for (int i = 0; i <= 10000; i++){
            tester.Hit();
        }
        Assert.True(tester.IsDead());
    }

    //Tests that the SwitchBlock is given a value property as per the specificiations
    [Test]
    public void HasValue() {
        Assert.True(tester.value != null);
    }
    
    //Tests that the SwitchBlock is an entity, by testing that it has a shape
    //Testing of Image is done by playtesting, when running the game
    [Test]
    public void IsEntity() {
        Assert.True(tester.shape != null);
    }

    //Tests that the SwitchRecieverBlock is deleted from the entitycontainer
    //When SwitchBlock gets hit
    [Test]
    public void SendsDeleteSignal() {
        switchReciever = new SwitchRecieverBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        var beforeCount = SwitchBlock.switchRecieverList.CountEntities(); 
        tester.Hit(); 
        Assert.AreNotEqual(beforeCount, 0);
        Assert.AreEqual(SwitchBlock.switchRecieverList.CountEntities(), 0);
        
    }

}