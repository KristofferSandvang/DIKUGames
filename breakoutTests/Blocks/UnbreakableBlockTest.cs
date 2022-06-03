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
#pragma warning disable 8618
#pragma warning disable 0472
namespace breakoutTests;

public class UnbreakableBlockTest {

private UnbreakableBlock dummy;
private StandardBlock standardDummy; 
private UnbreakableBlock tester;


    [SetUp]
    public void InitializeBlocks() {
        Window.CreateOpenGLContext();
        dummy = new UnbreakableBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))));
        tester = new UnbreakableBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))));
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))));
    }

    //Test that the UnbreakableBlock is instaniziated at the full hp, 
    //And that the UnbreakableBlock is not detected as dead at this point.
    [Test]
    public void InitialHPTest() {
        Assert.AreEqual(tester.GetHP(), dummy.GetHP());
        Assert.False(tester.IsDead());
    }

    //Test that the UnbreakableBlock loses no health after getting hit.
    [Test]
    public void NoDamageTest() {
        tester.Hit();
        Assert.AreEqual(tester.GetHP(),dummy.GetHP());
    }

    //Tests that the UnbreakableBlock takes less damage (as it should take none)
    //But the standard block does take damage
    [Test]
    public void LessDamageTest() {
        Assert.AreEqual(tester.GetHP(),standardDummy.GetHP());
        tester.Hit();
        standardDummy.Hit();
        Assert.Greater(tester.hitPoints, standardDummy.hitPoints);
    }

    //Tests that the UnbreakableBlock never dies and has taken no damage
    [Test]
    public void IsNotDeadTest() {
        for (int i = 0; i <= 10000; i++){
            tester.Hit();
        }
        Assert.False(tester.IsDead());
        Assert.AreEqual(tester.GetHP(), dummy.GetHP());; 
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
