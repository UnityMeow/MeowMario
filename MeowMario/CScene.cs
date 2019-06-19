using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowMario
{
    //场景类
    class CScene
    {
        public int GameState = 1;

        public virtual void Init()
        { }
        public virtual void Run()
        { }
        public virtual void End()
        { }
        public virtual int GetState()
        {
            return GameState;
        }
    }
}
