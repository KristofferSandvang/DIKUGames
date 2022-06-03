using NUnit.Framework;
using System;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Utilities;
using Breakout;
using Breakout.Blocks; 
using Breakout.PowerUps;

namespace breakoutTests;

public class PowerUpTest {
private HardenedBlock dummy;
private StandardBlock standardDummy; 
private HardenedBlock tester;


[SetUp]
    public void InitializeBlocks() {
    }
    //Test that the HardenedBlock is instaniziated at the full hp, 
    //And that the HardenedBlock is not dead if no damage was taken
    [Test]
    public void MoveXD() {
       
    }
}
