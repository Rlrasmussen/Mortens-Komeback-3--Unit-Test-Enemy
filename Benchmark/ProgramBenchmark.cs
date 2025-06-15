using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Enemy_spawn;
using BenchmarkDotNet.Diagnosers;



namespace Benchmark
{
    [MemoryDiagnoser]
    public class PoolVsStandardInstantiate
    {
        private const int N = 3;

        private const int FirstPass = 1;

        private const int SecondPass = 10;

        private const int ThirdPass = 100;

        private const int FourthPass = 100_000;


        private List<Enemy_spawn.GameObject> enemiesStandard = new List<Enemy_spawn.GameObject>();
        private List<Enemy_spawn.GameObject> enemiesPool = new List<Enemy_spawn.GameObject>();


        public PoolVsStandardInstantiate()
        {

        }

        [Benchmark]
        public void StandardInstantiate()
        {
            Enemy_spawn.Player.Instance.IsAlive = false;

            for (int i = 0; i < N * FirstPass; i++)
            {
                GameObject enemy = new Enemy_spawn.Enemy(Enemy_spawn.EnemyType.WalkingGoose);
                enemiesStandard.Add(enemy);
            }
            Enemy_spawn.Program.PlayerDeadTwo(enemiesStandard);

            for (int i = 0; i < N * SecondPass; i++)
            {
                GameObject enemy = new Enemy_spawn.Enemy(Enemy_spawn.EnemyType.WalkingGoose);
                enemiesStandard.Add(enemy);
            }
            Enemy_spawn.Program.PlayerDeadTwo(enemiesStandard);


            for (int i = 0; i < N * ThirdPass; i++)
            {
                GameObject enemy = new Enemy_spawn.Enemy(Enemy_spawn.EnemyType.WalkingGoose);
                enemiesStandard.Add(enemy);
            }
            Enemy_spawn.Program.PlayerDeadTwo(enemiesStandard);


            for (int i = 0; i < N * FourthPass; i++)
            {
                GameObject enemy = new Enemy_spawn.Enemy(Enemy_spawn.EnemyType.WalkingGoose);
                enemiesStandard.Add(enemy);
            }
            Enemy_spawn.Program.PlayerDeadTwo(enemiesStandard);

        }

        [Benchmark]
        public void PoolInstantiate()
        {
            Enemy_spawn.Player.Instance.IsAlive = false;

            for (int i = 0; i < N * FirstPass; i++) //Spawn Enemy 
            {
                Enemy_spawn.Program.SpawnEnemy(enemiesPool, Enemy_spawn.EnemyType.WalkingGoose);
            }
            Enemy_spawn.Program.PlayerDead();

            for (int i = 0; i < N * SecondPass; i++) //Spawn Enemy
            {
                Enemy_spawn.Program.SpawnEnemy(enemiesPool, Enemy_spawn.EnemyType.WalkingGoose);
            }
            Enemy_spawn.Program.PlayerDead();

            for (int i = 0; i < N * ThirdPass; i++) //Spawn Enemy
            {
                Enemy_spawn.Program.SpawnEnemy(enemiesPool, Enemy_spawn.EnemyType.WalkingGoose);
            }
            Enemy_spawn.Program.PlayerDead();

            for (int i = 0; i < N * FourthPass; i++) //Spawn Enemy
            {
                Enemy_spawn.Program.SpawnEnemy(enemiesPool, Enemy_spawn.EnemyType.WalkingGoose);
            }
            Enemy_spawn.Program.PlayerDead();

        }



        public static void Main(string[] args)
        {
            var summery = BenchmarkRunner.Run<PoolVsStandardInstantiate>();
        }
    }
}

