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
    }
}
