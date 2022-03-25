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
#pragma warning disable 8618
namespace galagaTests;

[TestFixture]
public class TestPlayer {

    private Player dummy;
    private Player tester;

    [SetUp]
    public void InitializePlayers() {
        Window.CreateOpenGLContext();
        
        dummy = new Player(
                    new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                    new Image(Path.Combine("Assets", "Images", "Player.png")));

        tester = new Player(
                    new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                    new Image(Path.Combine("Assets", "Images", "Player.png")));
        
    }

    [Test]
    public void RightMoveTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            } 
        );
        tester.move();
        Assert.Greater(tester.xPosition(), dummy.xPosition());
       
    } 
    [Test]
    public void RightMoveRightBoundTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            }
        );
        tester.move();
        Assert.Less(tester.xPosition(), 1);
    }
    [Test]
    public void RightMoveLeftBoundTest()  {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            }
        );
        tester.move();
        Assert.GreaterOrEqual(tester.xPosition(), 0);
    }
    
    [Test]
    public void LeftMoveTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            } 
        );
        tester.move();
        Assert.Less(tester.xPosition(), dummy.xPosition());
    }
    
    [Test]
    public void LeftMoveRightBoundTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            }
        );
        tester.move();
        Assert.Less(tester.xPosition(), 1);
    }
    [Test]
    public void LeftMoveLeftBoundTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            }
        );
        tester.move();
        Assert.Greater(tester.xPosition(), 0);
    }
    [Test]
    public void NoMoveTest(){
        Assert.AreEqual(dummy.xPosition(), tester.xPosition());
    }
}


