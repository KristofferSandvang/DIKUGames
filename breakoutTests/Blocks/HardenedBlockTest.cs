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

namespace breakoutTests;

public class HardenedBlockTest {
private HardenedBlock dummy;
private StandardBlock standardDummy; 
private HardenedBlock tester;


[SetUp]
    public void InitializeBlocks() {
        Window.CreateOpenGLContext();
        dummy = new HardenedBlock( 
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")), 
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                      "red-block-damaged.png")));
        tester = new HardenedBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png")),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images",
                      "red-block-damaged.png")));
        standardDummy = new StandardBlock(
            new DynamicShape( new Vec2F(0.1f, 0.9f), new Vec2F(0.1f, 0.1f)),
            new ImageStride(80, ImageStride.CreateStrides(4,
            Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "red-block.png"))));
    }


    //Test that the HardenedBlock is instaniziated at the full hp, 
    //And that the HardenedBlock is not dead if no damage was taken
    [Test]
    public void NotHitTest() {
        Assert.AreEqual(tester.GetHP(), dummy.GetHP());
        Assert.False(tester.IsDead());
    }
    

    //Test that the HardenedBlock loses health after getting hit.
    [Test]
    public void HitOnceTest() {
        tester.Hit();
        Assert.True(tester.GetHP()<dummy.GetHP());
    }

    //Tests that the HardenedBlock takes less damage than the standard block type
    [Test]
    public void LessDamageTest() {
        Assert.AreEqual(tester.GetHP(),standardDummy.GetHP());
        tester.Hit();
        standardDummy.Hit(); 
        Assert.True(tester.GetHP()>standardDummy.GetHP());
    }

    //Tests that the HardenedBlock dies when hit enough times.
    [Test]
    public void IsDeadTest() {
        for (int i = 0; i <= 10000; i++){
            tester.Hit();
        }
        Assert.True(tester.IsDead());
    }
    

    //Tests that the HardenedBlock is given a value property as per the requirements
    [Test]
    public void HasValue() {
        Assert.True(tester.value != null);
    }
    
    
    //Tests that the HardenedBlock is an entity, by testing that it has a shape
    //Testing of Image is done by hand, when running the game
    [Test]
    public void IsEntity() {
        Assert.True(tester.shape != null);
    }
}
