using NUnit.Framework;
using System.IO;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using Breakout.Blocks; 

namespace BreakoutTests.BlockTests;


public class StandardBlockTest {

    private StandardBlock dummy;
    private StandardBlock tester;

    public StandardBlockTest() {
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
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
        Assert.False(tester.IsDead());
    }
    

    //Test that the StandardBlock has lost health after getting hit.
    [Test]
    public void HitOnceTest() {
        tester.Hit();
        Assert.Less(tester.hitPoints, dummy.hitPoints);
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
        Assert.NotNull(tester.value);
    }
    
    
    //Tests that the StandardBlock is an entity, by testing that it has a shape
    //Testing of Image is done by hand, when running the game
    [Test]
    public void IsEntity() {
        Assert.NotNull(tester.shape);
    }
    
}