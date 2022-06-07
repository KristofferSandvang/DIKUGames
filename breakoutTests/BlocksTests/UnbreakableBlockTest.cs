using NUnit.Framework;
using System.IO;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using Breakout.Blocks; 

namespace BreakoutTests.BlockTests;

public class UnbreakableBlockTest {

private UnbreakableBlock dummy;
private StandardBlock standardDummy; 
private UnbreakableBlock tester;
    public UnbreakableBlockTest() {
        Window.CreateOpenGLContext();
        dummy = new UnbreakableBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        tester = new UnbreakableBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
    }

    [SetUp]
    public void InitializeBlocks() {
        Window.CreateOpenGLContext();
        dummy = new UnbreakableBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        tester = new UnbreakableBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
    }

    //Test that the UnbreakableBlock is instaniziated at the full hp, 
    //And that the UnbreakableBlock is not detected as dead at this point.
    [Test]
    public void InitialHPTest() {
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
        Assert.False(tester.IsDead());
    }

    //Test that the UnbreakableBlock loses no health after getting hit.
    [Test]
    public void NoDamageTest() {
        tester.Hit();
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
    }

    //Tests that the UnbreakableBlock takes less damage (as it should take none)
    //But the standard block does take damage
    [Test]
    public void LessDamageTest() {
        Assert.AreEqual(tester.hitPoints, standardDummy.hitPoints);
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
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);; 
    }
    
    //Tests that the UnbreakableBlock is given a value property as per the requirements
    [Test]
    public void HasValue() {
        Assert.NotNull(tester.value);
    }
    
    
    //Tests that the UnbreakableBlock is an entity, by testing that it has a shape
    //Testing of Image is done by playtesting, when running the game
    [Test]
    public void IsEntity() {
        Assert.NotNull(tester.shape);
    }
}
