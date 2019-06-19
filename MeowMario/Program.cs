using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace MeowMario
{
    class Program
    {
        //入口函数
        static void Main(string[] args)
        {
            Console.WindowWidth = 25 * 2;
            Console.WindowHeight = 22;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            while (true)
            {
                if (CCommon.GameScene.GetState() == 1)
                {
                    CCommon.GameScene.Init();
                }
                if (CCommon.GameScene.GetState() == 2)
                {
                    CCommon.GameScene.Run();
                }
                if (CCommon.GameScene.GetState() == 3)
                {
                    CCommon.GameScene.End();
                }
                if (CCommon.GameScene.GetState() == -1)
                {
                    return;
                }
            }
        }
    }
}

