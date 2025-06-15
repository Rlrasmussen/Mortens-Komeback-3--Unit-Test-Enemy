using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public abstract class ObjectPool
    {
        #region Field
        private List<GameObject> active = new List<GameObject>();
        private Stack<GameObject> inactive = new Stack<GameObject>();
        private int id = 1;

        #endregion

        #region Properties

        #endregion

        #region Construction

        #endregion

        #region Method
        public GameObject GetObject(Enum type)
        {
            GameObject gameObject;

            if (inactive.Count == 0)
            {
                gameObject = Create(type);

                gameObject.Id = id;
                id++;
            }
            else
            {
                gameObject = inactive.Pop();
                gameObject.Type = type;
            }

            active.Add(gameObject);

            return gameObject;
        }

        public void ReleaseObject(GameObject gameObject)
        {
            active.Remove(gameObject);

            inactive.Push(gameObject);
        }

        public abstract GameObject Create(Enum type);

        public List<GameObject> GetActive()
        {
            return active;
        }

        public Stack<GameObject> GetInactive()
        {
            return inactive;
        }
        #endregion
    }
}
