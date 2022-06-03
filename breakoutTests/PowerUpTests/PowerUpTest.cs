using NUnit.Framework;
using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Utilities;
using Breakout;
using Breakout.Blocks; 
using Breakout.PowerUp;

namespace breakoutTests;

public class HardenedBlockTest {
private HardenedBlock dummy;
private StandardBlock standardDummy; 
private HardenedBlock tester;


[SetUp]
    public void InitializeBlocks() {
        PowerUp test = new PowerUp(
            new DynamicShape(new Vec2F(0.0f, 0.0f), new Vec2F(0.05f, 0.05f)),
            new Image(Path.Combine(FileIO.GetProjectPath(), "Assets", "Images", "LifePickUp.png")));
    }
    //Test that the HardenedBlock is instaniziated at the full hp, 
    //And that the HardenedBlock is not dead if no damage was taken
    [Test]
    public void MoveXD() {
        test.Move();
        Assert.AreEqual(test.GetHP(), dummy.GetHP());
        
    }
}
