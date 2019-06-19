using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowMario
{
    //图片类
    class CBmp
    {
        int m_w;    //图片宽
        int m_h;    //图片高
        int[] m_index;  //图片数据
        ConsoleColor[] m_BackColor; //图片颜色数据
        ConsoleColor[] m_ForeColor; //图片颜色数据
        int m_len;      //数据长度

        //设置图片宽高数据
        public void SetBmpData(int w, int h, params int[] data)
        {
            //安全检测
            if (w < 0 || h < 0)
                return;
            //设置图片宽高
            m_w = w;
            m_h = h;
            //设置图片数据长度
            m_len = m_w * m_h;
            m_index = new int[m_len];
            if (data.Length < m_len)
            {
                for (int i = 0; i < m_len; ++i)
                {
                    m_index[i] = data[0];
                }
            }
            else
            {
                //设置图片数据
                for (int i = 0; i < m_len; ++i)
                {
                    m_index[i] = data[i];
                }
            }
        }
        //=================================
        public void SetBmpBackColocr(params ConsoleColor[] color)
        {
            m_BackColor = new ConsoleColor[m_len];
            if (color.Length < m_len)
            {
                for (int i = 0; i < m_len; ++i)
                {
                    m_BackColor[i] = color[0];
                }
            }
            else
            {
                //设置图片颜色数据
                for (int i = 0; i < m_len; ++i)
                {
                    m_BackColor[i] = color[i];
                }
            }
        }
        public ConsoleColor[] GetBmpBackColocr()
        {
            return m_BackColor;
        }
        public void SetBmpForeColocr(params ConsoleColor[] color)
        {
            m_ForeColor = new ConsoleColor[m_len];
            if (color.Length < m_len)
            {
                for (int i = 0; i < m_len; ++i)
                {
                    m_ForeColor[i] = color[0];
                }
            }
            else
            {
                //设置图片颜色数据
                for (int i = 0; i < m_len; ++i)
                {
                    m_ForeColor[i] = color[i];
                }
            }
        }
        public ConsoleColor[] GetBmpForeColocr()
        {
            return m_ForeColor;
        }
        //=================================

        //获取图片宽
        public int GetW()
        {
            return m_w;
        }
        //获取图片高
        public int GetH()
        {
            return m_h;
        }
        //获取图片数据
        public int[] GetIndex()
        {
            return m_index;
        }
    }
}
