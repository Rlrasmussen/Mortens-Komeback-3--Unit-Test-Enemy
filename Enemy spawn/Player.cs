using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public class Player : GameObject
    {
        #region Singelton
        private static Player instance;


        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player(PlayerType.Morten);
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
        public Player(Enum type) : base(type)
        {
        }

        #endregion

        #region Method

        #endregion
    }
}
