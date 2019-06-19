using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowMario
{
    //物体类
    class CGameObject
    {
        int m_x;
        int m_y;
        int[] m_offxy;

        //初始化物体xy
        public CGameObject(int x, int y)
        {
            m_x = x;
            m_y = y;
            m_offxy = new int[2] { 0, 0 };
        }

        //物体移动 1上 2下 3左 4右
        public void Run(int dir)
        {
            if (dir > 4 || dir < 0)
                return;
            switch (dir)
            {
                case 1: m_offxy = new int[2] { 0, -1 }; break;
                case 2: m_offxy = new int[2] { 0, 1 }; break;
                case 3: m_offxy = new int[2] { -1, 0 }; break;
                case 4: m_offxy = new int[2] { 1, 0 }; break;
            }
            m_x += m_offxy[0];
            m_y += m_offxy[1];
        }

        //获取物体x
        public int GetX()
        {
            return m_x;
        }
        //获取物体y
        public int GetY()
        {
            return m_y;
        }
    }
}
