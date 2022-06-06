using Breakout;
using DIKUArcade.GUI;
using DIKUArcade.Events;
using System.Collections.Generic;
using NUnit.Framework;


#pragma warning disable 8618

namespace breakoutTests;
public class GameTimeTest {

        private GameTime dummy;
        private GameTime tester;

    [OneTimeSetUp]
    public void InitializeEventBus() {
        BreakoutBus.GetBus().InitializeEventBus(new List<GameEventType> { 
            GameEventType.ControlEvent } );
    }
    [OneTimeTearDown]
    public void ResetEventbus() {
        BreakoutBus.ResetBus();
    }
        
    [SetUp]
    public void InitalizeTests() {
        Window.CreateOpenGLContext();

        dummy = new GameTime(0.0);
        tester = new GameTime(0.0);
        BreakoutBus.GetBus().Subscribe(GameEventType.ControlEvent, tester);
        
    }
    // Tests that the time never does not go negative. 
    [Test]
    public void TestNegativeValues() {
        System.Threading.Thread.Sleep(1000);
        Assert.GreaterOrEqual(tester.GetTime(), 0.0);
    }
    
    // Tests that 10 seconds can be added to the timer. 
    public void TestAddTime() {
        BreakoutBus.GetBus().RegisterEvent(
            new GameEvent {
                EventType = GameEventType.ControlEvent,
                Message = "MoreTime",
            }
        );
        Assert.Greater(tester.GetTime(), dummy.GetTime());
    }
}