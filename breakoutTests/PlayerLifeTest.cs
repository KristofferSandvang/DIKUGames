using NUnit.Framework;
using DIKUArcade.GUI;
using System.Collections.Generic;
using DIKUArcade.Events;
using Breakout;

namespace BreakoutTests;

public class PlayerLifeTest {
    private PlayerLife dummy; 
    private PlayerLife tester;
    public PlayerLifeTest() {
        Window.CreateOpenGLContext();
        dummy = new PlayerLife();
        tester = new PlayerLife();
    }
    
    [OneTimeSetUp]
    public void InitalizeBreakoutBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { GameEventType.PlayerEvent } );
    }

    [OneTimeTearDown]
    public void ResetBreakoutBus() {
        BreakoutBus.ResetBus();
    }

    [SetUp]
    public void Initalise() {
        Window.CreateOpenGLContext();
        dummy = new PlayerLife();
        tester = new PlayerLife();
        BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, tester);
    }

    //Tests that you can lose a life
    [Test]
    public void TestLoseLife() {
        BreakoutBus.GetBus().RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "LoseLife",
            }
        );
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Less(tester.LivesLeft(), dummy.LivesLeft());
    }

    //Tests that you can never have negative lives.
    [Test]
    public void TestNoNegativeLives() {
        for (int i = 0; i < 5; i++) {
           BreakoutBus.GetBus().RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "LoseLife",
            }); 
        }
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.GreaterOrEqual(tester.LivesLeft(), 0);
    }

    //Tests that you can gain a life
    [Test]
    public void TestGainLife() {
        BreakoutBus.GetBus().RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "GainLife",
        }); 
        BreakoutBus.GetBus().ProcessEventsSequentially();
        Assert.Greater(tester.LivesLeft(), dummy.LivesLeft());
    }
}
