using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeowMario
{
    //开始场景
    class CStartScene : CScene
    {
        CGameOutput go;
        int m_x1;
        int m_x2;
        int m_y1;
        int m_y2;
        int m_mmx;
        int m_mmdir;
        int m_icon;
        public override void Init()
        {
            m_x1 = 10;
            m_x2 = 11;
            m_y1 = 9;
            m_y2 = 11;
            m_icon = 1;
            m_mmx = 4;
            m_mmdir = 1;
            go = new CGameOutput(25, 20);
            //设置图素
            go.SetPixel("　喵版马里奥开始游戏选择关卡■●");
            //创建图片
            CBmp bmp1 = new CBmp();
            CBmp bmp2 = new CBmp();
            CBmp bmp3 = new CBmp();
            CBmp bmp4 = new CBmp();
            CBmp bmp5 = new CBmp();
            CBmp bmp6 = new CBmp();
            CBmp bmp7 = new CBmp();
            CBmp bmp8 = new CBmp();
            //设置图片数据
            bmp1.SetBmpData(9, 1, 1, 0, 2, 0, 3, 0, 4, 0, 5);
            bmp2.SetBmpData(4, 1, 6, 7, 8, 9);
            bmp3.SetBmpData(4, 1, 10, 11, 12, 13);
            bmp4.SetBmpData(25, 2, 14);
            bmp5.SetBmpData(2, 3, 14);
            bmp6.SetBmpData(4, 1, 6, 7, 8, 9);
            bmp7.SetBmpData(4, 1, 10, 11, 12, 13);
            bmp8.SetBmpData(1, 1, 15);
            //设置图片颜色
            bmp1.SetBmpBackColocr(ConsoleColor.Red, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.DarkBlue, ConsoleColor.Red);
            bmp2.SetBmpBackColocr(ConsoleColor.Yellow);
            bmp3.SetBmpBackColocr(ConsoleColor.Yellow);
            bmp4.SetBmpBackColocr(ConsoleColor.White);
            bmp5.SetBmpBackColocr(ConsoleColor.Green);
            bmp6.SetBmpBackColocr(ConsoleColor.Yellow);
            bmp7.SetBmpBackColocr(ConsoleColor.Yellow);
            bmp8.SetBmpBackColocr(ConsoleColor.DarkBlue);

            bmp1.SetBmpForeColocr(ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.White, ConsoleColor.DarkBlue, ConsoleColor.White);
            bmp2.SetBmpForeColocr(ConsoleColor.Black);
            bmp3.SetBmpForeColocr(ConsoleColor.Black);
            bmp4.SetBmpForeColocr(ConsoleColor.DarkRed);
            bmp5.SetBmpForeColocr(ConsoleColor.Green);
            bmp6.SetBmpForeColocr(ConsoleColor.White);
            bmp7.SetBmpForeColocr(ConsoleColor.White);
            bmp8.SetBmpForeColocr(ConsoleColor.Red);
            //加载图片
            go.LoadBmp("标题", bmp1);
            go.LoadBmp("开始", bmp2);
            go.LoadBmp("选择", bmp3);
            go.LoadBmp("砖块", bmp4);
            go.LoadBmp("水管", bmp5);
            go.LoadBmp("开始1", bmp6);
            go.LoadBmp("选择1", bmp7);
            go.LoadBmp("喵", bmp8);
            GameState = 2;
        }
        public override void Run()
        {
            go.Begin(0, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
            go.DrawBmp("标题", 8, 5);
            go.DrawBmp("砖块", 0, 17);
            go.DrawBmp("水管", 19, 14);
            go.DrawBmp("喵", m_mmx, 16);
            if (m_icon == 1)
            {
                go.DrawBmp("开始", m_x1, m_y1);
                go.DrawBmp("选择1", m_x2, m_y2);
            }
            else
            {
                go.DrawBmp("开始1", m_x1, m_y1);
                go.DrawBmp("选择", m_x2, m_y2);
            }
            go.End();

            if (m_mmx > 12)
                m_mmdir = -1;
            else if (m_mmx < 4)
                m_mmdir = 1;
            m_mmx += m_mmdir;

            while (Console.KeyAvailable)
            {
                //按键
                char input = new char();
                ConsoleKeyInfo c = Console.ReadKey(true);
                input = c.KeyChar;
                switch (input)
                {
                    case 'w':
                        {
                            if (m_icon == 2)
                            {
                                m_x1 = 10;
                                m_x2 = 11;
                                m_y1 = 9;
                                m_y2 = 11;
                                m_icon = 1;
                            }
                        }
                        break;
                    case 's':
                        {
                            if (m_icon == 1)
                            {
                                m_x1 = 11;
                                m_x2 = 10;
                                m_y1 = 9;
                                m_y2 = 11;
                                m_icon = 2;
                            }
                        }
                        break;
                    case ' ':
                        {
                            GameState = 3;
                        }
                        break;
                }
            }
            Thread.Sleep(32);
        }
        public override void End()
        {
            if (m_icon == 1)
                CCommon.GameScene = new CRunScene();
            if (m_icon == 2) ;
            //GameScene = new CRankScene();
        }
    }
}
