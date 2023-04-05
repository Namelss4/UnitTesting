namespace Sumas__TheGame
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void PlayerStartsOnAllyTower()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();

            Assert.IsTrue(tower1.Type.ToString() == Character.type.main.ToString()); //Starts on own tower
            Assert.Less(tower1.FloorList.Count, 3); //few floors on character's tower
        }

        [Test]
        public void TowerCreatesFloors()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();

            Assert.IsTrue(tower1.FloorList.Count > 0); 

            Tower tower2 = GameManager.TowerGenerator(2, 4);

            Assert.IsTrue(tower2.FloorList.Count > 0); 

        }

        [Test]
        public void TowerCreatesCharacters()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();

            if (tower1.FloorList[0].CharactersList.Count > 0)
            {
                Assert.IsTrue(tower1.FloorList[0].CharactersList.Count > 0);
            }
            else if (tower1.FloorList[1].CharactersList.Count > 0)
            {
                Assert.IsTrue(tower1.FloorList[1].CharactersList.Count > 0);
            }

            Tower tower2 = GameManager.TowerGenerator(2, 4);

            Assert.IsNotNull(tower2.FloorList[0].CharactersList[0]); 

        }

        [Test]
        public void PlayerStartsOnRandomFloor()
        {
            int listCount0 = 0;
            int listCount1 = 0;

            for (int i = 0; i < 10000; i++)
            {
                Tower tower1 = GameManager.TowerCharacterGenerator();

                if (tower1.FloorList[0].CharactersList.Count > 0)
                {
                    listCount0++;
                }
                else if (tower1.FloorList[1].CharactersList.Count > 0)
                {
                    listCount1++;
                }

                tower1 = null;
            }

            Assert.IsTrue(listCount0 < 5500 && listCount0 > 4500);
            Assert.IsTrue(listCount1 < 5500 && listCount1 > 4500);

        }

        [Test]
        public void CharactersHaveALevel()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();
            Tower enemyTower = GameManager.TowerGenerator(3, 2);
            

            if (tower1.FloorList[0].CharactersList.Count > 0)
            {
                Assert.IsTrue(tower1.FloorList[0].CharactersList[0].Level != 0);
            }
            else if (tower1.FloorList[1].CharactersList.Count > 0)
            {
                Assert.IsTrue(tower1.FloorList[1].CharactersList[0].Level != 0);
            }

            Assert.IsTrue(enemyTower.FloorList[0].CharactersList[0].Level != 0);
                 
        }

        [Test]
        public void HigherLevelWins()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();
            Tower enemyTower = GameManager.TowerGenerator(2, 1);

            if (tower1.FloorList[0].CharactersList.Count > 0)
            {
                GameManager.MoveAndFight(tower1.FloorList[0].CharactersList[0], tower1.FloorList[0], enemyTower.FloorList[0]);

                Assert.AreEqual(enemyTower.FloorList[0].CharactersList.Count, 1);
            }
            else if (tower1.FloorList[1].CharactersList.Count > 0)
            {
                GameManager.MoveAndFight(tower1.FloorList[1].CharactersList[0], tower1.FloorList[1], enemyTower.FloorList[0]);

                Assert.AreEqual(enemyTower.FloorList[0].CharactersList.Count, 1);
            }

        }

        [Test]
        public void CharacterDiesIfSameLevel()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();
            Tower enemyTower = GameManager.TowerGenerator(2, 1);
            enemyTower.FloorList[0].CharactersList[0].Level = 7;

            if (tower1.FloorList[0].CharactersList.Count > 0)
            {
                GameManager.MoveAndFight(tower1.FloorList[0].CharactersList[0], tower1.FloorList[0], enemyTower.FloorList[0]);

                Assert.AreEqual(enemyTower.FloorList[0].CharactersList.Count, 1);
                Assert.IsTrue(enemyTower.FloorList[0].CharactersList[0].ChType == Character.type.evil);
            }
            else if (tower1.FloorList[1].CharactersList.Count > 0)
            {
                GameManager.MoveAndFight(tower1.FloorList[1].CharactersList[0], tower1.FloorList[1], enemyTower.FloorList[0]);

                Assert.AreEqual(enemyTower.FloorList[0].CharactersList.Count, 1);
                Assert.IsTrue(enemyTower.FloorList[0].CharactersList[0].ChType == Character.type.evil);
            }

        }

        [Test]
        public void HigherLevelAddsLesserLevel()
        {
            Tower tower1 = GameManager.TowerCharacterGenerator();
            Tower enemyTower = GameManager.TowerGenerator(2, 1);

            if (tower1.FloorList[0].CharactersList.Count > 0)
            {
                GameManager.MoveAndFight(tower1.FloorList[0].CharactersList[0], tower1.FloorList[0], enemyTower.FloorList[0]);

                Assert.AreEqual(enemyTower.FloorList[0].CharactersList[0].Level, 11);
            }
            else if (tower1.FloorList[1].CharactersList.Count > 0)
            {
                GameManager.MoveAndFight(tower1.FloorList[1].CharactersList[0], tower1.FloorList[1], enemyTower.FloorList[0]);

                Assert.AreEqual(enemyTower.FloorList[0].CharactersList[0].Level, 11);
            }

        }


    }
}