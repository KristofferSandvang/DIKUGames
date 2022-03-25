using NUnit.Framework;
using Galaga;
using DIKUArcade.Events;
using DIKUArcade.Math;
#pragma warning disable 8618



namespace galagaTests; 

    public class TestScore {
        private Score DummyScore;
        private Score ScoreTester;

        
        [SetUp]
        public void InitializeScores() {
            ScoreTester = new Score(new Vec2F(0.05f, 0.7f), new Vec2F(0.3f, 0.3f));;
            DummyScore = new Score(new Vec2F(0.05f, 0.7f), new Vec2F(0.3f, 0.3f));; 
            //bus = GalagaBus.GetBus();
            //bus.subscribe(ScoreEvent, tester);
        }

        [Test]
        public void NoScoreTest() {
            Assert.AreEqual(ScoreTester.GetScore, 0); 
        }
        [Test]
        public void AddScoreTest(){
            ScoreTester.AddPoints();
            Assert.AreEqual(ScoreTester.GetScore, DummyScore.GetScore+100); 
        }
        
        
        [Test]
        public void AddMoreScoreTest(){
            for (int i = 0; i < 100; i++) {
                ScoreTester.AddPoints();
                Assert.AreEqual(ScoreTester.GetScore, DummyScore.GetScore + 100 + i * 100); 
            }
        }
    }


    