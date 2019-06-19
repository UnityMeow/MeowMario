using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowMario
{
    //英雄类
    class CHero
    {
        public int x;
        public int y;
        //英雄dir
        int m_dir;
        string m_name;
        //跳跃力
        int m_Jump;
        //当前跳跃力
        int m_CurrentJump;
        //重力
        int m_Gravity;
        //初始化英雄数据
        public CHero(int x1, int y1, string name)
        {
            m_Gravity = 1;
            m_dir = 0;
            m_Jump = 3;
            m_CurrentJump = 0;
            m_name = name;
            this.x = x1;
            this.y = y1;
        }
        ////获取英雄x
        //public int GetX()
        //{
        //    return m_x;
        //}
        ////获取英雄y
        //public int GetY()
        //{
        //    return m_y;
        //}
        ////设置英雄x
        //public void SetX(int x)
        //{
        //    m_x = x;
        //}
        ////设置英雄y
        //public void SetY(int y)
        //{
        //    m_y = y;
        //}
        //获取英雄方向
        public int GetDir()
        {
            return m_dir;
        }
        //设置英雄方向
        public void SetDir(int dir)
        {
            m_dir = dir;
        }
        //设置英雄当前跳跃力
        public void SetCurrentJump(int curjump)
        {
            m_CurrentJump = curjump;
        }
        //设置英雄跳跃力
        public void SetJump(int jump)
        {
            m_Jump = jump;
        }
        //获取英雄当前跳跃力
        public int GetCurrentJump()
        {
            return m_CurrentJump;
        }
        //获取英雄跳跃力
        public int GetJump()
        {
            return m_Jump;
        }
        //获取英雄重力
        public int GetGravity()
        {
            return m_Gravity;
        }
        //获取英雄姓名
        public string GetName()
        {
            return m_name;
        }
    }
}
