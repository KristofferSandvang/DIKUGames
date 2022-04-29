using NUnit.Framework;
using System;
using System.IO;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Physics;
using System.Security.Principal;
using System.Collections.Generic;
using DIKUArcade.Events;
using DIKUArcade.State;
using Breakout;

namespace breakoutTests;

public class PlayerTest
{
    private Player dummy;
    private Player tester;
    [SetUp]
    public void Setup() {
        Window.CreateOpenGLContext();
        dummy = new Player(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f)),
        new Image(Path.Combine("Assets", "Images", "player.png")));

        tester = new Player(
        new DynamicShape(new Vec2F(0.425f, 0.1f), new Vec2F(0.15f, 0.03f)),
        new Image(Path.Combine("Assets", "Images", "player.png")));
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    [Test]
    public void RightMoveTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            } 
        );
        tester.Move();
        Assert.Greater(tester.XPosition(), dummy.XPosition());
       
    } 
    [Test]
    public void RightMoveRightBoundTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            }
        );
        tester.Move();
        Assert.Less(tester.XPosition(), 1);
    }
    [Test]
    public void RightMoveLeftBoundTest()  {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveRight",
            }
        );
        tester.Move();
        Assert.GreaterOrEqual(tester.XPosition(), 0);
    }
    
    [Test]
    public void LeftMoveTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            } 
        );
        tester.Move();
        Assert.Less(tester.XPosition(), dummy.XPosition());
    }
    
    [Test]
    public void LeftMoveRightBoundTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            }
        );
        tester.Move();
        Assert.Less(tester.XPosition(), 1);
    }
    [Test]
    public void LeftMoveLeftBoundTest() {
        tester.ProcessEvent(
            new GameEvent {
                EventType = GameEventType.PlayerEvent,
                Message = "moveLeft",
            }
        );
        tester.Move();
        Assert.Greater(tester.XPosition(), 0);
    }
    [Test]
    public void NoMoveTest(){
        Assert.AreEqual(dummy.XPosition(), tester.XPosition());
    }
}