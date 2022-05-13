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
using DIKUArcade.Utilities;
using Breakout;
using Breakout.Blocks; 
#pragma warning disable 8618

namespace breakoutTests;

public class ScoreTest {

    private Score tester;
    private StandardBlock block;
    private HardenedBlock hardenedBlock;
    [SetUp]
        public void InitializeScore() {
            tester = new Score(new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.15f));
            block = new StandardBlock( 
                new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
                new ImageStride(80, ImageStride.CreateStrides(4,
                Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png"))));
            hardenedBlock = new HardenedBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                      "red-block-damaged.png")));
        }
    
    //Tests that the score is initially 0
    [Test]
    public void ZeroPointsTest() {
        Assert.AreEqual(tester.GetScore(), 0); 
    }
    
    
    //Tests that the score is able to recieve points at all, the basis of all other tests
    [Test]
    public void RecievePointsTest() {
        Score.AddScore(100);
        Assert.True(tester.GetScore() > 0); 
    }
    
    //Tests that the score can never be negative
    [Test]
    public void NonNegativeTest() {
        Score.AddScore(-100);
        Assert.True(tester.GetScore() >= 0); 
    }
    
    
    //Tests that a destroyed block will give points, by first having it be hit
    //and then calling IsDead which is what actually gives the points (assuming it is dead)
    //The block is hit an excessive amount of time in case of changing hp values. Just needs to be dead
    [Test]
    public void DestroyBlockTest() {
        for (int i = 0;i<10000;i++) {
            block.Hit(); 
        }
        block.IsDead(); 
        Assert.True(tester.GetScore() > 0); 
    }
    
    //Same as prior, just that each block does not give the same value
    //Though this is more confirmable by reading the code or by playtesting
    [Test]
    public void DifferentValues() {
        for (int i = 0;i<10000;i++) {
            block.Hit();
            hardenedBlock.Hit(); 
        }
        block.IsDead(); 
        var blockValue = tester.GetScore(); 
        hardenedBlock.IsDead(); 
        var hardenedBlockValue = (tester.GetScore()-blockValue); 
        Assert.AreNotEqual(hardenedBlockValue, blockValue); 

    }

    
    //Tests that the ResetScore function works, not a specificaiton 
    [Test]
    public void ResetScore() {
        for (int i = 0;i<10000;i++) {
            block.Hit(); 
        }
        block.IsDead(); 
        //Assert.True(tester.score>0);
        Score.ResetScore();
        Assert.AreEqual(tester.GetScore(),0); 
    }
}
