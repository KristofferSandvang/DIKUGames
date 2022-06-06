using Breakout.Blocks;
using Breakout.Blocks.BlockFactories;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
using System.IO;
using NUnit.Framework;

namespace breakoutTests;
#pragma warning disable 8618

[TestFixture]
public class HealableBlockFactoryTest {
    private HealAbleBlockFactory factory;
    private HealableBlock exampleBlock;

    [SetUp]
    public void InitalizeFactory() {
        factory = new HealAbleBlockFactory();
        exampleBlock =  new HealableBlock(
            new DynamicShape(new Vec2F(1.0f, 1.0f),  new Vec2F(0.08333334f, 0.028f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            true);
    }
    //tests that the block created using the factory, has the same position as the example block
    [Test]
    public void TestCorrectPosition() {
        var newBlock = factory.CreateBlock("red-block.png", new Vec2F(1.0f, 1.0f), true);
        Assert.AreEqual(newBlock.shape.Position.Y, exampleBlock.shape.Position.Y);
        Assert.AreEqual(newBlock.shape.Position.X, exampleBlock.shape.Position.X);
    }
    //tests that the block created using the factory, has the same type as the example block
    [Test]
    public void TestCorrectBlockType() {
        var newBlock = factory.CreateBlock("red-block.png", new Vec2F(1.0f, 1.0f), true);
        Assert.AreEqual(newBlock.GetType(), exampleBlock.GetType());
    }
    //tests that the block created using the factory, has the same Hitpoints as the example block
    [Test]
    public void TestSameHitPoints() {
        var newBlock = factory.CreateBlock("red-block.png", new Vec2F(1.0f, 1.0f), true);
        Assert.AreEqual(newBlock.hitPoints, exampleBlock.hitPoints);
    }
    //tests that the block created using the factory, has the same value as the example block
    [Test]
    public void TestSameValue() {
        var newBlock = factory.CreateBlock("red-block.png", new Vec2F(1.0f, 1.0f), true);
        Assert.AreEqual(newBlock.value, exampleBlock.value);
    }
    //tests that the block created using the factory, has the same powerUp as the example block
    [Test]
    public void TestSamePowerUp() {
        var newBlock = factory.CreateBlock("red-block.png", new Vec2F(1.0f, 1.0f), true);
        Assert.AreEqual(newBlock.powerUp, exampleBlock.powerUp);
    }
}