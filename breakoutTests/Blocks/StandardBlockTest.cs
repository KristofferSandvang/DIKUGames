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

namespace breakoutTests;

#pragma warning disable 0472
#pragma warning disable 8618

public class StandardBlockTest {

private StandardBlock dummy;
private StandardBlock tester;


    [SetUp]
    public void InitializeBlocks() {
        Window.CreateOpenGLContext();
        dummy = new StandardBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        tester = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
    }


    //Test that the StandardBlock is instaniziated at the full hp, 
    //And that the StandardBlock is not dead if no damage was taken
    [Test]
    public void NotHitTest() {
        Assert.AreEqual(tester.GetHP(), dummy.GetHP());
        Assert.False(tester.IsDead());
    }
    

    //Test that the StandardBlock has lost health after getting hit.
    [Test]
    public void HitOnceTest() {
        tester.Hit();
        Assert.True(tester.GetHP()<dummy.GetHP());
    }
    
    
    //Tests that the StandardBlock dies when hit enough times.
    [Test]
    public void IsDeadTest() {
        for (int i = 0; i <= 10000; i++){
            tester.Hit();
        }
        Assert.True(tester.IsDead());
    }
    

    //Tests that the StandardBlock is given a value property as per the requirements
    [Test]
    public void HasValue() {
        Assert.True(tester.value != null);
    }
    
    
    //Tests that the StandardBlock is an entity, by testing that it has a shape
    //Testing of Image is done by hand, when running the game
    [Test]
    public void IsEntity() {
        Assert.True(tester.shape != null);
    }
    
}