using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public abstract class GameObject
    {
        #region Field
        private bool isAlive = true;
        private int id;
        private Enum type;

        protected GameObject(Enum type)
        {
            this.Type = type;
        }

        #endregion

        #region Properties
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public int Id { get => id; set => id = value; }
        public Enum Type { get => type; set => type = value; }

        #endregion

        #region Constructor

        #endregion

        #region Method

        #endregion
    }
}
