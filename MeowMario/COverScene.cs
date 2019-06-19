using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeowMario
{
    //结束场景
    class COverScene : CScene
    {
        int m_icon = 1;
        public override void Init()
        {
            GameState = 2;
        }
        public override void Run()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2 * 2, 20);
            Console.Write("                                       ");
            if (CCommon.win)
            {
                Console.SetCursorPosition(8 * 2, 3);
                Console.Write("Y o u   W i n !");
            }
            else
            {
                Console.SetCursorPosition(7 * 2, 3);
                Console.Write("G a m e   O v e r !");
            }

            Console.SetCursorPosition(9 * 2, 5);
            Console.Write("总积分:{0}分", CCommon.Score);
            if (m_icon == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.SetCursorPosition(9 * 2, 8);
            Console.Write(" 重新开始 ");
            if (m_icon == 2)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.SetCursorPosition(9 * 2, 9);
            Console.Write(" 返回主页 ");
            if (m_icon == 3)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.SetCursorPosition(9 * 2, 10);
            Console.Write(" 退出游戏 ");

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
                                m_icon = 1;
                            else if (m_icon == 3)
                                m_icon = 2;
                        }
                        break;
                    case 's':
                        {
                            if (m_icon == 1)
                                m_icon = 2;
                            else if (m_icon == 2)
                                m_icon = 3;
                        }
                        break;
                    case ' ':
                        {
                            GameState = 3;
                        }
                        break;
                }

            }
            Thread.Sleep(100);

        }
        public override void End()
        {
            switch (m_icon)
            {
                case 1: CCommon.GameScene = new CRunScene(); break;
                case 2: CCommon.GameScene = new CStartScene(); break;
                case 3: GameState = -1; return;
            }
        }
    }
}
