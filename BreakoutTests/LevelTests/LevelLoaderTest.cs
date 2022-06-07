using NUnit.Framework;
using DIKUArcade.GUI;
using Breakout.Levels;

namespace BreakoutTests.LevelTests;

public class LevelLoaderTest {
    private LevelLoader tester;
    private Level testLevel; 
    public LevelLoaderTest() {
        Window.CreateOpenGLContext();
        tester = new LevelLoader("level1.txt");
        testLevel = tester.CreateLevel();
    }

    //Makes a tester levelLoader from "level1.txt" 
    //and creates a variable testLevel from this using .CreateLevel()
    [SetUp]
    public void Setup() {
        Window.CreateOpenGLContext();
        tester = new LevelLoader("level1.txt");
        testLevel = tester.CreateLevel();
    }

    //Testing that the correct amount of entities has been instanizated 
    [Test]
    public void EntityCount() {
        Assert.AreEqual(testLevel.GetEC().CountEntities(),76);
    }
    
    //Testing that the correct time was read from the meta-data
    [Test]
    public void CorrectTime() {
        Assert.AreEqual(testLevel.GetTime(),300);
    }
    
    //Testing that the correct name was read from the meta-data
    [Test]
    public void CorrectName() {
        Assert.AreEqual(testLevel.GetName(),"LEVEL 1");
    }

    //Testing that the correct powerup symbol was read from the meta-data
    [Test]
    public void CorrectPowerUp() {
        Assert.AreEqual(testLevel.GetPowerUp(),'2');
    }
}
