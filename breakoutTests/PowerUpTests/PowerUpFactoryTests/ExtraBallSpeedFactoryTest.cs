using Breakout.PowerUps;
using Breakout.PowerUps.PowerUpFactories;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Utilities;
using System.IO;
using NUnit.Framework;

namespace BreakoutTests.PowerUpTests.PowerUpFactoriesTest;

[TestFixture]
public class ExtraBallSpeedFactoryTest {
    private ExtraBallSpeedFactory factory;
    private ExtraBallSpeed examplePowerUp;

    public ExtraBallSpeedFactoryTest() {
        factory = new ExtraBallSpeedFactory();
        examplePowerUp =  new ExtraBallSpeed(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.05f, 0.05f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", 
                "BallSpeedier.png"))
        );
    }
    
    [SetUp]
    public void InitalizeFactory() {
        factory = new ExtraBallSpeedFactory();
        examplePowerUp =  new ExtraBallSpeed(
            new DynamicShape(new Vec2F(1.0f, 1.0f), new Vec2F(0.05f, 0.05f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", 
                "BallSpeedier.png"))
        );
    }
    //tests that the PowerUp created using the factory, has the same position as examplePowerUp
    [Test]
    public void TestCorrectPosition() {
        var newPowerUp = factory.CreatePowerUp(new Vec2F(1.0f, 1.0f));
        Assert.AreEqual(newPowerUp.GetShape().Position.Y, examplePowerUp.GetShape().Position.Y);
        Assert.AreEqual(newPowerUp.GetShape().Position.X, examplePowerUp.GetShape().Position.X);
    }
    //tests that the PowerUp created using the factory, has the same type as the examplePowerUp
    [Test]
    public void TestCorrectBlockType() {
        var newPowerUp = factory.CreatePowerUp(new Vec2F(1.0f, 1.0f));
        Assert.AreEqual(newPowerUp.GetType(), examplePowerUp.GetType());
    }
}