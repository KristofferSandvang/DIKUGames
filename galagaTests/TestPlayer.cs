using NUnit.Framework;
using Galaga;
using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Events;
using System.Collections.Generic;

namespace galagaTests;

[TestFixture]
public class TestPlayer {

    private Player dummy;
    private Player tester;
    private GameEventBus bus;

    [SetUp]
    public void InitializePlayers() {
        Window.CreateOpenGLContext();

        bus = GalagaBus.GetBus();
        
        dummy = new Player(
                    new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                    new Image(Path.Combine("Assets", "Images", "Player.png")));

        tester = new Player(
                    new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                    new Image(Path.Combine("Assets", "Images", "Player.png")));
        
        bus.Subscribe(GameEventType.PlayerEvent, tester);
    }

    /*[Test]
    public void RightMoveTest() {
        bus.RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            } 
        );
        bus.RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "stopMoveRight",
            } 
        );
        Assert.Greater(tester.xPosition(), dummy.xPosition());
       
    } */
    [Test]
    public void RightMoveRightBoundTest() {
        bus.RegisterEvent (
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            }
        );
        bus.ProcessEventsSequentially();
        Assert.Less(tester.xPosition(), 1);
    }
    [Test]
    public void RightMoveLeftBoundTest()  {

        bus.RegisterEvent (
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            }
        );
        bus.ProcessEventsSequentially();
        Assert.GreaterOrEqual(tester.xPosition(), 0);
    }
    /*
    [Test]
    public void LeftMoveTest() {
        bus.RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.PlayerEvent,
                    Message = "moveLeft",
                }
            );
        bus.RegisterEvent(
                new GameEvent {
                    EventType = GameEventType.PlayerEvent,
                    Message = "stopMoveLeft",
                }
            );
        bus.ProcessEventsSequentially();

        
        Assert.Less(tester.xPosition(), dummy.xPosition());
    }*/
    [Test]
    public void LeftMoveRightBoundTest() {
        bus.RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            }
        );
        bus.ProcessEventsSequentially();
        Assert.Less(tester.xPosition(), 1);
    }
    [Test]
    public void LeftMoveLeftBoundTest() {
        bus.RegisterEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            }
        );
        bus.ProcessEventsSequentially();
        Assert.Greater(tester.xPosition(), 0);
    }
    [Test]
    public void NoMoveTest(){
        Assert.AreEqual(dummy.xPosition(), tester.xPosition());
    }
}


