namespace Galaga{
    [TestFixture]
    public class TestPlayer{
    private Player dummy;
    
    [Setup]
    public void Setup()
    {
        dummy = Game.player;
    }
    [Test]
    public void RightTest(){

    }
    public void LeftTest(){
        
    }
    public void NoMoveTest(){
        TestPlayer = Game.player;
        Assert.AreEqual(dummy.shotPosition()==TestPlayer.shotPosition());
        
    }

    }
}

