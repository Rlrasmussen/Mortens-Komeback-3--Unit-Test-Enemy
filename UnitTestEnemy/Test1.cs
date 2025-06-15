using Enemy_spawn;
namespace Unit_Test_Enemy
{
    [TestClass]
    public sealed class Test1
    {
        /// <summary>
        /// Testing for at an Emeny when spawned will be added to the active list in ObjectPool
        /// Rikke
        /// </summary>
        [TestMethod]
        public void AddEnemyToEnemyPoolActive()
        {
            //Adding an Enemy to the room and therefor the active list in ObjectPool. The added Enemy will have id equal 1

            //ARRANGE//
            List<GameObject> room = new List<GameObject>();


            //ACT//
            //Adding an Enemy to the room
            Program.SpawnEnemy(room, EnemyType.WalkingGoose);
            //Reviecing the active list from EnemyPool
            List<GameObject> activeRoom = EnemyPool.Instance.GetActive();


            //ASSERT//
            //Is there added an object 
            Assert.AreEqual(1, activeRoom.Count);
            //Is the object an Enemy
            Assert.IsInstanceOfType(activeRoom[0], typeof(Enemy));
            //The Enemy id is 1
            Assert.AreEqual(1, activeRoom[0].Id);
        }

        /// <summary>
        /// Testing if an Enemy when dead is removed from the active list and popped to the inactive stack
        /// Rikke
        /// </summary>
        [TestMethod]
        public void RemoveEnemyFromActiveToInactive()
        {
            //Remove an Enemy from the active list in ObjectPool to inactive Stack

            //ARRANGE//
            List<GameObject> room = new List<GameObject>();


            //ACT//
            //Adding an Enemy to the room
            Program.SpawnEnemy(room, EnemyType.WalkingGoose);
            //The added Enemy
            GameObject enemyTest = room[0];
            //Remove an Enemy from the room
            Program.KillEnemy(room);

            //Reviecing the active list from EnemyPool
            List<GameObject> activeRoom = EnemyPool.Instance.GetActive();
            //Reviecing the inactive stack from EnemyPool
            Stack<GameObject> inactiveRoom = EnemyPool.Instance.GetInactive();


            //ASSERT//
            //The active list is empty and does not contain enemyTest
            Assert.AreEqual(0, activeRoom.Count);
            CollectionAssert.DoesNotContain(activeRoom, enemyTest);
            //The inactive stack has an object and contains enemyuTest
            Assert.AreEqual(1, inactiveRoom.Count);
            CollectionAssert.Contains(inactiveRoom, enemyTest);
        }


        /// <summary>
        /// Test if an object will be used again 
        /// </summary>
        [TestMethod]
        public void MakeARoom()
        {
            //ARRANGE//
            //Make a room have 3 enemies and kill them. Add a new room with 2 enemies. The ObjectPool will contain 3 enemies 
            List<GameObject> roomA = new List<GameObject>(); //3 enemies
            List<GameObject> roomB = new List<GameObject>(); //2 enemies


            //ACT//
            //Adding the enemies to roomA
            for (int i = 0; i < 3; i++)
            {
                Program.SpawnEnemy(roomA, EnemyType.WalkingGoose);
            }
            //The enemy1 has id=1
            GameObject enemy1 = roomA[0];

            //Kill enemies is roomA
            for (int i = 0; i < 3; i++)
            {
                Program.KillEnemy(roomA);
            }

            //Add enemies to roomB
            for (int i = 0; i < 2; i++)
            {
                Program.SpawnEnemy(roomB, EnemyType.WalkingGoose);
            }


            //ASSERT//
            //The is only 3 objects in the objectPool
            Assert.AreEqual(3, EnemyPool.Instance.GetActive().Count + EnemyPool.Instance.GetInactive().Count);
            //Enemy enemy1 (id=1) is in roomB and popped from the inactive stack
            Assert.AreEqual(1, enemy1.Id);
            Assert.AreEqual(EnemyPool.Instance.GetActive()[0].Id, enemy1.Id);
        }

        /// <summary>
        /// Test if the player dies all the ojects return to thee inactive stack
        /// </summary>
        [TestMethod]
        public void PlayerDeadReleaseGameObject()
        {
            //If the player dies alle the enemis need to return to the inactive stack

            //ARRANGE//
            //Room with enemies
            List<GameObject> room = new List<GameObject>();
            //The Player is dead - IsAlive == false
            Player.Instance.IsAlive = false;


            //ACT//
            //Adding the enemies to room
            for (int i = 0; i < 3; i++)
            {
                Program.SpawnEnemy(room, EnemyType.WalkingGoose);
            }

            //Calling the method PlayerDead()
            Program.PlayerDead();


            //ASSERT//
            //Player is dead - IsAlive == false
            Assert.AreEqual(false, Player.Instance.IsAlive);
            //active list is empty
            Assert.AreEqual(0, EnemyPool.Instance.GetActive().Count);
            //inactive stack has 3 GameObjects
            Assert.AreEqual(3, EnemyPool.Instance.GetInactive().Count);
        }

        /// <summary>
        /// When a GameObject is getting reused from the Objectpool the type is changed
        /// </summary>
        [TestMethod]
        public void EnemyChangeTypeInNewRoom()
        {
            //When an Enemy is respawned in a new room, it can changes the type. If the id is still the samme, it will be the same Object 

            //ARRANGE//
            //roomA and roomB with enemies
            List<GameObject> roomA = new List<GameObject>();
            List<GameObject> roomB = new List<GameObject>();


            //ACT 1//
            //Add 3 Enemy of WalkingGoose to the room
            for (int i = 0; i < 3; i++)
            {
                Program.SpawnEnemy(roomA, EnemyType.WalkingGoose);
            }
            //Enemy with id = 1       
            GameObject enemy1 = roomA[0];

            //ASSERT 1//
            //enemy1 has id=1 and type is WalkingGoose
            Assert.AreEqual(enemy1.Id, 1);
            Assert.AreEqual(EnemyType.WalkingGoose, enemy1.Type);

            //ACT 2//
            //Kill one Enemy
            Program.KillEnemy(roomA);
            //Spawn one Enemy in roomB
            Program.SpawnEnemy(roomB, EnemyType.AggroGoose);
            //enemy2 is the first Enemy in roomB
            GameObject enemy2 = roomB[0];

            //ASSERT//
            //enemy1 and enemy2 has samme id which is 1
            Assert.AreEqual(enemy1.Id, enemy2.Id);
            //enemy1 has changed type to AggroGoose
            Assert.AreEqual(EnemyType.AggroGoose, enemy1.Type);
        }

        [TestMethod]
        public void AllEnemy()
        {
            //There should be 16 Enemy's in the ObjectPool if the game is won

            //ARRANGE//
            //4 rooms of Enemy's
            List<GameObject> roomA = new List<GameObject>(3);
            List<GameObject> roomB = new List<GameObject>(4);
            List<GameObject> roomC = new List<GameObject>(7);
            List<GameObject> roomD = new List<GameObject>(1 + 15); //Bossfigth with Goosifer and wave of 15 Enemy


            //ACT//
            //Adding and killing enemies
            //roomA
            for (int i = 0; i < 3; i++)
            {
                Program.SpawnEnemy(roomA, EnemyType.WalkingGoose);
            }
            for (int i = 0; i < 3; i++)
            {
                Program.KillEnemy(roomA);
            }
            //roomB
            for (int i = 0; i < 4; i++)
            {
                Program.SpawnEnemy(roomB, EnemyType.AggroGoose);
            }
            for (int i = 0; i < 4; i++)
            {
                Program.KillEnemy(roomB);
            }
            //roomC
            for (int i = 0; i < 7; i++)
            {
                Program.SpawnEnemy(roomC, EnemyType.WalkingGoose);
            }
            for (int i = 0; i < 7; i++)
            {
                Program.KillEnemy(roomC);
            }
            //roomD
            Program.SpawnEnemy(roomD, EnemyType.Goosifer);
            for (int i = 0; i < 15; i++)
            {
                Program.SpawnEnemy(roomD, EnemyType.AggroGoose);
            }

            //Player win and ISAlive is sat to false and all the objects is back in the ObjectPool
            Player.Instance.IsAlive = false;
            Program.PlayerDead();


            //ASSERT//
            Assert.IsFalse(Player.Instance.IsAlive);
            Assert.AreEqual(16, EnemyPool.Instance.GetInactive().Count);
        }
    }
}
