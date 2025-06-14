using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public class EnemyFactory : Factory
    {
        #region Singelton
        private static EnemyFactory instance;

        public static EnemyFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }

                return instance;
            }
        }

        #endregion

        #region Field

        #endregion

        #region Properties

        #endregion

        #region Constructor

        #endregion

        #region Method
        public override GameObject Create(Enum type)
        {
            return new Enemy(type);
        }
    }
        #endregion
}
