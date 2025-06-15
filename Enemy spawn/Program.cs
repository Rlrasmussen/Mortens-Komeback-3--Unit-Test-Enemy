using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<GameObject> roomA = new List<GameObject>();
            List<GameObject> roomB = new List<GameObject>();

            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy(roomA, EnemyType.WalkingGoose);
            }

            Console.WriteLine("RoomA: ");
            foreach (GameObject item in roomA)
            {
                Console.WriteLine(item.Id + " + " + item.Type);
            }

            KillEnemy(roomA);

            Console.WriteLine("RoomA: ");
            foreach (GameObject item in roomA)
            {
                Console.WriteLine(item.Id + " + " + item.Type);
            }

            SpawnEnemy(roomB, EnemyType.Goosifer);

            Console.WriteLine("RoomB: ");
            foreach (GameObject item in roomB)
            {
                Console.WriteLine(item.Id + " + " + item.Type);
            }

            Player.Instance.IsAlive = false;
            PlayerDead();

            Console.WriteLine(EnemyPool.Instance.GetInactive().Count);

            Console.ReadKey();
        }

        /// <summary>
        /// Spawn Enemy in the room
        /// </summary>
        /// <param name="room">List of GameObjects</param>
        public static void SpawnEnemy(List<GameObject> room, Enum type)
        {
            room.Add(EnemyPool.Instance.GetObject(type));
        }

        /// <summary>
        /// If there is an Enemy in the room it will be removed from the room and the 
        /// active list and pushed to the inactive stack in ObjectPool 
        /// </summary>
        /// <param name="room">List of GameObjects</param>
        public static void KillEnemy(List<GameObject> room)
        {
            if (room.Count > 0)
            {
                EnemyPool.Instance.ReleaseObject(room[0]);
                room.Remove(room[0]);
            }
        }

        /// <summary>
        /// When the Player is dead (IsAlive == false) all the Enemies will be remove from 
        /// the active list and pushed to the inactive stack in ObjectPool
        /// </summary>
        public static void PlayerDead()
        {
            if (Player.Instance.IsAlive == false)
            {
                while (EnemyPool.Instance.GetActive().Count > 0)
                {
                    EnemyPool.Instance.ReleaseObject(EnemyPool.Instance.GetActive()[0]);
                }
            }
        }


        public static void PlayerDeadTwo(List<GameObject> gameObjects)
        {
            if (Player.Instance.IsAlive == false)
            {
                gameObjects.Clear();
            }
        }
    }
}
