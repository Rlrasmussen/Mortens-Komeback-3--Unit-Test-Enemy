using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemy_spawn
{
    public abstract class Factory
    {
        public abstract GameObject Create(Enum type);
    }
}
