using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public class EnemyPool : ObjectPool
    {
        #region Singelton
        private static EnemyPool instance;

        public static EnemyPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyPool();
                }

                return instance;
            }
        }
        #endregion

        #region Field

        #endregion

        #region Porperties

        #endregion

        #region Constructor

        #endregion

        #region Method
        public override GameObject Create(Enum type)
        {
            return EnemyFactory.Instance.Create(type);
        }

        #endregion
    }
}
