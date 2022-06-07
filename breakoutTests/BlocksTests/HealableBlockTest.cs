using NUnit.Framework;
using System.IO;

using DIKUArcade.GUI;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

using Breakout.Blocks; 
using Breakout;


namespace BreakoutTests.BlockTests;

public class HealableBlockTest {
private HealableBlock dummy;
private StandardBlock standardDummy; 
private HealableBlock tester;
private GameTime gameTime;
    public HealableBlockTest() {
        Window.CreateOpenGLContext();
        dummy = new HealableBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), true);
        tester = new HealableBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), true);
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        gameTime = new GameTime(300.0);
    }

    [SetUp]
    public void InitializeTests() {
        Window.CreateOpenGLContext();
        dummy = new HealableBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), true);
        tester = new HealableBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), true);
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine("Assets", "Images", "red-block.png"))), false);
        gameTime = new GameTime(300.0);
    }


    //Test that the HealableBlock is instaniziated at the full hp, 
    //And that the HealableBlock is not dead if no damage was taken
    [Test]
    public void NotHitTest() {
        Assert.AreEqual(tester.hitPoints, dummy.hitPoints);
        Assert.False(tester.IsDead());
    }


    //Test that the HealableBlock loses health after getting hit.
    [Test]
    public void HitOnceTest() {
        tester.Hit();
        Assert.Less(tester.hitPoints, dummy.hitPoints);
    }


    //Test that the HealableBlock Regenerates health.
    [Test]
    public void HealOverTimeTest() {
        tester.Hit();
        tester.Hit();
        var before = tester.hitPoints;
        System.Threading.Thread.Sleep(3000);
        tester.IterateHeal(gameTime);
        var after = tester.hitPoints;
        Assert.Greater(after, before);
    }

    //Test that the HealableBlock will not Regenerate past maxHealth.
    [Test]
    public void OverHealTest() {
        tester.Hit();
        tester.Hit();
        System.Threading.Thread.Sleep(2995);
        tester.IterateHeal(gameTime);

        Assert.AreEqual(tester.hitPoints, 10);
    }

    //Tests that the HealableBlock dies when hit enough times fast enough.
    [Test]
    public void IsDeadTest() {
        for (int i = 0; i <= 10; i++){
            tester.Hit();
        }
        Assert.True(tester.IsDead());
    }

    //Tests that the HealableBlock is given a value property as per the requirements
    [Test]
    public void HasValue() {
        Assert.NotNull(tester.value);
    }
    
    //Tests that the HealableBlock is an entity, by testing that it has a shape
    //Testing of Image is done by hand, when running the game
    [Test]
    public void IsEntity() {
        Assert.NotNull(tester.shape);
    }
}