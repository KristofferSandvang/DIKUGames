using NUnit.Framework;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.Utilities;
using Breakout;
using Breakout.Blocks; 
#pragma warning disable 8618

namespace breakoutTests;

[TestFixture]
public class ScoreTest {

    private Score tester;
    private StandardBlock block;
    private HardenedBlock hardenedBlock;

    [OneTimeSetUp]
    public void InitalizeBreakoutBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.StatusEvent } );
    }
    [OneTimeTearDown]
    public void ResetBreakoutBus() {
        BreakoutBus.ResetBus();
    }

    [SetUp]
    public void InitializeScore() {
        tester = new Score(new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.15f));
        BreakoutBus.GetBus().Unsubscribe(GameEventType.StatusEvent, tester);
        block = new StandardBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png"))),
            false);
        hardenedBlock = new HardenedBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                      "red-block-damaged.png")),
            false);
        BreakoutBus.GetBus().Subscribe(GameEventType.StatusEvent, tester);
    }
    [TearDown]
    public void ResetTester() {
        tester.ResetScore();
    }
    //Tests that the score is initially 0
    [Test]
    public void TestZeroPoints() {
        Assert.AreEqual(tester.GetScore(), 0); 
    }
    
    
    //Tests that the score is able to recieve points at all, the basis of all other tests
    [Test]
    public void TestRecievePoints() {
        BreakoutBus.GetBus().RegisterEvent(new GameEvent{
                        EventType = GameEventType.StatusEvent,
                        Message = "AddPoints",
                        IntArg1 = 100,
                    }
        );
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(tester.GetScore(), 0); 
    }
    
    //Tests that the score can never be negative
    [Test]
    public void TestNonNegative() {
        BreakoutBus.GetBus().RegisterEvent(new GameEvent{
                        EventType = GameEventType.StatusEvent,
                        Message = "AddPoints",
                        IntArg1 = (-10),
                    }
        );
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.AreEqual(0, tester.GetScore()); 
    }
    
    
    //Tests that a destroyed block will give points, by first having it be hit
    //and then calling IsDead which is what actually gives the points (assuming it is dead)
    //The block is hit an excessive amount of time in case of changing hp values. Just needs to be dead
    [Test]
    public void TestDestroyBlockScore() {
        block.Hit(); 
        block.IsDead(); 
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(tester.GetScore(), 0); 
    }
    
    //Tests that the ResetScore function works, not a specificaiton 
    [Test]
    public void TestResetScore() {
        for (int i = 0;i<10000;i++) {
            block.Hit(); 
        }
        block.IsDead(); 
        //Assert.True(tester.score>0);
        tester.ResetScore();
        Assert.AreEqual(tester.GetScore(),0); 
    }
}
