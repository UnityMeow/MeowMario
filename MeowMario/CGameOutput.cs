using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowMario
{
    //绘制类
    class CGameOutput
    {
        string m_Pixel;   //图素
        int m_PixelLen;     //图素长度
                            //图片管理
        Dictionary<string, CBmp> m_BmpList;
        //绘图区域
        int[] m_Map;
        ConsoleColor[] m_MapBackColor; //颜色数据
        ConsoleColor[] m_MapForeColor; //颜色数据
        int m_W;
        int m_H;
        int m_S;

        //初始化绘图区域宽高
        public CGameOutput(int w, int h)
        {
            //安全检测
            if (w < 1)
                w = 1;
            if (h < 1)
                h = 1;
            //初始化画布宽
            m_W = w;
            //初始化画布高
            m_H = h;
            //初始化画布面积
            m_S = m_W * m_H;
            //初始化绘图区域
            m_Map = new int[m_S];
            m_MapBackColor = new ConsoleColor[m_S];
            m_MapForeColor = new ConsoleColor[m_S];
            //初始化图片链表
            m_BmpList = new Dictionary<string, CBmp>();
        }
        //加载图片
        public void LoadBmp(string id, CBmp bmp)
        {
            //安全检测
            if (m_BmpList.ContainsKey(id))
                return;
            //将所需要加载的图片存入链表
            m_BmpList.Add(id, bmp);
        }
        //设置图素
        public void SetPixel(string pixel)
        {
            //设置图素
            m_Pixel = pixel;
            //获取图素个数
            m_PixelLen = m_Pixel.Length;
        }

        //初始化画布
        public void Begin(int style, ConsoleColor Back, ConsoleColor Fore)
        {
            //初始化绘图区域
            if (style == 0)
            {
                for (int i = 0; i < m_S; ++i)
                {
                    m_Map[i] = 0;
                    m_MapBackColor[i] = Back;
                    m_MapForeColor[i] = Fore;
                }
            }
            if (style == 1)
            {
                for (int i = 0; i < m_S; ++i)
                {
                    m_Map[i] = 0;
                    m_MapBackColor[i] = Back;
                    m_MapForeColor[i] = Fore;
                    if (i % m_W == 0 || i % m_W == m_W - 1 || i / m_W == 0 || i / m_W == m_H - 1)
                        m_Map[i] = 1;

                }
            }
        }
        //图片数据导入画布
        public void DrawBmp(string id, int x, int y)
        {
            //越界检测
            if (y >= m_H || x >= m_W)
                return;
            if (!m_BmpList.ContainsKey(id))
                return;
            //获取图片数据
            CBmp bTmp;
            m_BmpList.TryGetValue(id, out bTmp);
            int pos = x + y * m_W;
            for (int i = 0; i < bTmp.GetW() * bTmp.GetH(); ++i)
            {
                //图片数据导入画布
                if (x >= 0 && x < m_W && y >= 0 && y < m_H)
                {
                    m_Map[pos] = bTmp.GetIndex()[i];
                    m_MapBackColor[pos] = bTmp.GetBmpBackColocr()[i];
                    m_MapForeColor[pos] = bTmp.GetBmpForeColocr()[i];
                }
                pos += 1;
                x += 1;
                //图片数据换行
                if (i % bTmp.GetW() == bTmp.GetW() - 1)
                {
                    y++;
                    x -= bTmp.GetW();
                    pos = x + y * m_W;
                }
            }
        }
        //绘制画布
        public void End()
        {
            //清空
            Console.SetCursorPosition(0, 0);
            //绘制画布
            for (int i = 0; i < m_S; ++i)
            {
                Console.BackgroundColor = m_MapBackColor[i];
                Console.ForegroundColor = m_MapForeColor[i];
                Console.Write(m_Pixel[m_Map[i]]);
                if (i % m_W == m_W - 1)
                    Console.WriteLine();
            }

        }

        //获取图素长度
        public int GetPixelLen()
        {
            return m_PixelLen;
        }
        //获取画布宽
        public int GetClientW()
        {
            return m_W;
        }
        //获取画布高
        public int GetClientH()
        {
            return m_H;
        }

    }
}
