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
#pragma warning disable 8618

namespace breakoutTests;

public class TestPlayer {

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


    //Tests if the player have moved to the right, 
    //from it's initial position, while moving right
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
    

    //Tests if the player will be stopped, 
    //when reaching right border, while moving right
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


    //Tests if the player will stay on the right side of left border, while moving right
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
    

    //Tests in the Player will move left from it's initial position
    //when moving left
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
    

    //Tests if the player will be on the left side of right border
    //when moving left
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


    //Tests if the player will be stopped, 
    //when reaching left border, while moving left
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


    //Tests if the player will be stay in the initial position, when no functions is called
    [Test]
    public void NoMoveTest(){
        Assert.AreEqual(dummy.XPosition(), tester.XPosition());
    }


}