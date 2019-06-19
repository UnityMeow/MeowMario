using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowMario
{
    //物体管理
    class CGameObjMgr<T>
    {
        T m_Tmp = default(T);
        //物体管理
        Dictionary<int, T> m_ObjList;
        public CGameObjMgr()
        {
            m_ObjList = new Dictionary<int, T>();
        }
        //加载物体
        public void LoadObj(int id, T obj)
        {
            //安全检测
            if (m_ObjList.ContainsKey(id))
                return;
            //将所需要加载的物体存入链表
            m_ObjList.Add(id, obj);
        }
        //修改物体
        public void SetObj(int id, T obj)
        {
            //安全检测
            if (!m_ObjList.ContainsKey(id))
                return;
            m_ObjList[id] = obj;
        }
        //删除物体
        public void EraseObj(int id)
        {
            //安全检测
            if (!m_ObjList.ContainsKey(id))
                return;
            //移除物体
            m_ObjList.Remove(id);
        }
        //获取物体
        public T GetObject(int id)
        {
            //安全检测
            if (!m_ObjList.ContainsKey(id))
                return m_Tmp;
            return m_ObjList[id];
        }
    }
}
