using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeowMario
{
    //游戏场景
    class CRunScene : CScene
    {
        public struct _MAP
        {
            public string id;
            public int x;
            public int y;
            public int w;
            public int h;
        };
        _MAP Ground;
        _MAP Men;
        _MAP Ground2;
        _MAP XianJing;
        _MAP XianJing1;
        _MAP Xin;
        _MAP[] GuaiShou;
        //水管
        _MAP[] Pipe;
        //金币
        _MAP[] Coin;
        //恶搞
        _MAP[] Spoof;
        //隐形
        _MAP[] Stealth;
        //空白
        _MAP[] Empty;
        #region 世界窗口宽高
        //世界地图的宽/高
        const int W = 105;
        const int H = 20;
        //窗口的宽/高/总面积
        const int Client_W = 25;
        const int Client_H = 20;
        const int Client_S = Client_W * Client_H;
        #endregion
        //马里奥
        CHero Mario;
        //窗口的位置
        int Client_X;
        int Client_Y;
        //创建画布
        CGameOutput go;

        bool Fenb = false;
        bool xxx = false;
        bool sbb = false;
        bool sbbb = false;
        int coinb = 0;
        bool xinb = false;
        bool ShuaFen = false;
        bool xianb = false;
        int Ming = 3;
        int dirg1 = -1;
        int dirg2 = -1;
        bool Collide(int hx, int hy, int zx, int zy, int zw, int zh)
        {
            if (hx - Client_X >= zx - Client_X && hx - Client_X <= zx + zw - 1 - Client_X
                        && hy - Client_Y >= zy - Client_Y && hy - Client_Y <= zy + zh - 1 - Client_Y)
                return true;
            else
                return false;
        }
        public override void Init()
        {
            CCommon.Score = 0;
            CCommon.win = false;
            Mario = new CHero(4, 16, "马里奥");
            //Client = new int[Client_S];
            Client_X = 0;
            Client_Y = 0;
            go = new CGameOutput(25, 20);
            //初始化地面
            Ground = new _MAP();
            Ground.x = 0;
            Ground.y = 17;
            Ground.w = 80;
            Ground.h = 2;
            Ground.id = "地面";
            //初始化地面2
            Ground2 = new _MAP();
            Ground2.x = 88;
            Ground2.y = 17;
            Ground2.w = 15;
            Ground2.h = 2;
            Ground2.id = "地面2";
            //陷阱
            XianJing = new _MAP();
            XianJing.x = -10;
            XianJing.y = -10;
            XianJing.w = 2;
            XianJing.h = 1;
            XianJing.id = "陷阱";
            //陷阱
            XianJing1 = new _MAP();
            XianJing1.x = 81;
            XianJing1.y = 13;
            XianJing1.w = 6;
            XianJing1.h = 2;
            XianJing1.id = "陷阱1";
            //初始化地面
            Men = new _MAP();
            Men.x = 100;
            Men.y = 14;
            Men.w = 3;
            Men.h = 3;
            Men.id = "门";

            Xin = new _MAP();
            Xin.x = -10;
            Xin.y = -10;
            Xin.id = "心";

            #region 怪兽
            //怪兽
            GuaiShou = new _MAP[3];
            GuaiShou[0].x = 29;
            GuaiShou[0].y = 16;
            GuaiShou[0].id = "怪兽0";
            GuaiShou[1].x = 51;
            GuaiShou[1].y = 16;
            GuaiShou[1].id = "怪兽1";
            GuaiShou[2].x = 61;
            GuaiShou[2].y = 16;
            GuaiShou[2].id = "怪兽2";
            #endregion

            #region 水管
            //初始化水管
            Pipe = new _MAP[5];
            Pipe[0].x = 30;
            Pipe[0].y = 15;
            Pipe[0].w = 2;
            Pipe[0].h = 2;
            Pipe[0].id = "水管0";
            Pipe[1].x = 42;
            Pipe[1].y = 14;
            Pipe[1].w = 2;
            Pipe[1].h = 3;
            Pipe[1].id = "水管1";
            Pipe[2].x = 52;
            Pipe[2].y = 13;
            Pipe[2].w = 2;
            Pipe[2].h = 4;
            Pipe[2].id = "水管2";
            Pipe[3].x = 62;
            Pipe[3].y = 13;
            Pipe[3].w = 2;
            Pipe[3].h = 4;
            Pipe[3].id = "水管3";
            Pipe[4].x = -10;
            Pipe[4].y = -10;
            Pipe[4].w = 2;
            Pipe[4].h = 2;
            Pipe[4].id = "水管4";
            #endregion

            #region 金币砖
            //初始化金币
            Coin = new _MAP[3];
            Coin[0].x = 24;
            Coin[0].y = 12;
            Coin[0].w = 1;
            Coin[0].h = 1;
            Coin[0].id = "金币0";
            Coin[1].x = 23;
            Coin[1].y = 7;
            Coin[1].w = 1;
            Coin[1].h = 1;
            Coin[1].id = "金币1";
            Coin[2].x = 52;
            Coin[2].y = 13;
            Coin[2].w = 2;
            Coin[2].h = 4;
            Coin[2].id = "金币2";
            #endregion

            #region 恶搞砖
            //初始化恶搞
            Spoof = new _MAP[3];
            Spoof[0].x = 16;
            Spoof[0].y = 12;
            Spoof[0].w = 1;
            Spoof[0].h = 1;
            Spoof[0].id = "恶搞0";
            Spoof[1].x = 22;
            Spoof[1].y = 12;
            Spoof[1].w = 1;
            Spoof[1].h = 1;
            Spoof[1].id = "恶搞1";
            Spoof[2].x = 74;
            Spoof[2].y = 11;
            Spoof[2].w = 1;
            Spoof[2].h = 1;
            Spoof[2].id = "恶搞2";
            #endregion

            #region 空白砖
            //初始化空白
            Empty = new _MAP[3];
            Empty[0].x = 21;
            Empty[0].y = 12;
            Empty[0].w = 1;
            Empty[0].h = 1;
            Empty[0].id = "空白0";
            Empty[1].x = 23;
            Empty[1].y = 12;
            Empty[1].w = 1;
            Empty[1].h = 1;
            Empty[1].id = "空白1";
            Empty[2].x = 25;
            Empty[2].y = 12;
            Empty[2].w = 1;
            Empty[2].h = 1;
            Empty[2].id = "空白2";
            #endregion

            //==========================================================================================
            //设置图素
            go.SetPixel("　■●★⊕▲▼◆");
            //创建图片
            CBmp bmp1 = new CBmp();
            CBmp bmp2 = new CBmp();
            CBmp bmp3 = new CBmp();
            CBmp bmp4 = new CBmp();
            CBmp bmp5 = new CBmp();
            CBmp bmp6 = new CBmp();
            CBmp bmp7 = new CBmp();
            CBmp bmp8 = new CBmp();
            CBmp bmp9 = new CBmp();
            CBmp bmp10 = new CBmp();
            CBmp bmp11 = new CBmp();
            CBmp bmp12 = new CBmp();
            CBmp bmp13 = new CBmp();
            CBmp bmp14 = new CBmp();
            CBmp bmp15 = new CBmp();
            #region 图片属性
            //设置图片数据
            bmp1.SetBmpData(Ground.w, Ground.h, 1);
            bmp2.SetBmpData(1, 1, 2);
            bmp3.SetBmpData(Pipe[0].w, Pipe[0].h, 1);
            bmp4.SetBmpData(Pipe[1].w, Pipe[1].h, 1);
            bmp5.SetBmpData(Pipe[2].w, Pipe[2].h, 1);
            bmp6.SetBmpData(Pipe[3].w, Pipe[3].h, 1);
            bmp7.SetBmpData(Pipe[4].w, Pipe[4].h, 1);
            bmp8.SetBmpData(Spoof[0].w, Spoof[0].h, 1);
            bmp9.SetBmpData(Empty[0].w, Empty[0].h, 1);
            bmp10.SetBmpData(Ground2.w, Ground2.h, 1);
            bmp11.SetBmpData(1, 1, 3);
            bmp12.SetBmpData(1, 1, 4);
            bmp13.SetBmpData(2, 1, 5);
            bmp14.SetBmpData(XianJing1.w, XianJing1.h, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6);
            bmp15.SetBmpData(3, 3, 7, 7, 7, 7, 0, 7, 7, 0, 7);
            //设置图片颜色
            bmp1.SetBmpBackColocr(ConsoleColor.White);
            bmp2.SetBmpBackColocr(ConsoleColor.DarkBlue);
            bmp3.SetBmpBackColocr(ConsoleColor.Green);
            bmp4.SetBmpBackColocr(ConsoleColor.Green);
            bmp5.SetBmpBackColocr(ConsoleColor.Green);
            bmp6.SetBmpBackColocr(ConsoleColor.Green);
            bmp7.SetBmpBackColocr(ConsoleColor.Green);
            bmp8.SetBmpBackColocr(ConsoleColor.White);
            bmp9.SetBmpBackColocr(ConsoleColor.White);
            bmp10.SetBmpBackColocr(ConsoleColor.White);
            bmp11.SetBmpBackColocr(ConsoleColor.DarkBlue);
            bmp12.SetBmpBackColocr(ConsoleColor.DarkBlue);
            bmp13.SetBmpBackColocr(ConsoleColor.DarkBlue);
            bmp14.SetBmpBackColocr(ConsoleColor.DarkBlue);
            bmp15.SetBmpBackColocr(ConsoleColor.DarkBlue);

            bmp1.SetBmpForeColocr(ConsoleColor.DarkRed);
            bmp2.SetBmpForeColocr(ConsoleColor.Red);
            bmp3.SetBmpForeColocr(ConsoleColor.Green);
            bmp4.SetBmpForeColocr(ConsoleColor.Green);
            bmp5.SetBmpForeColocr(ConsoleColor.Green);
            bmp6.SetBmpForeColocr(ConsoleColor.Green);
            bmp7.SetBmpForeColocr(ConsoleColor.Green);
            bmp8.SetBmpForeColocr(ConsoleColor.DarkYellow);
            bmp9.SetBmpForeColocr(ConsoleColor.DarkRed);
            bmp10.SetBmpForeColocr(ConsoleColor.DarkRed);
            bmp11.SetBmpForeColocr(ConsoleColor.Yellow);
            bmp12.SetBmpForeColocr(ConsoleColor.Red);
            bmp13.SetBmpForeColocr(ConsoleColor.Black);
            bmp14.SetBmpForeColocr(ConsoleColor.Black);
            bmp15.SetBmpForeColocr(ConsoleColor.Cyan);
            //加载图片
            go.LoadBmp(Ground.id, bmp1);
            go.LoadBmp(Mario.GetName(), bmp2);
            go.LoadBmp(Pipe[0].id, bmp3);
            go.LoadBmp(Pipe[1].id, bmp4);
            go.LoadBmp(Pipe[2].id, bmp5);
            go.LoadBmp(Pipe[3].id, bmp6);
            go.LoadBmp(Pipe[4].id, bmp7);
            go.LoadBmp(Spoof[0].id, bmp8);
            go.LoadBmp(Spoof[1].id, bmp8);
            go.LoadBmp(Spoof[2].id, bmp8);
            go.LoadBmp(Coin[0].id, bmp8);
            go.LoadBmp(Coin[1].id, bmp8);
            go.LoadBmp(Empty[0].id, bmp9);
            go.LoadBmp(Empty[1].id, bmp9);
            go.LoadBmp(Empty[2].id, bmp9);
            go.LoadBmp(Ground2.id, bmp10);
            go.LoadBmp(GuaiShou[0].id, bmp11);
            go.LoadBmp(GuaiShou[1].id, bmp11);
            go.LoadBmp(GuaiShou[2].id, bmp11);
            go.LoadBmp(Xin.id, bmp12);
            go.LoadBmp(XianJing.id, bmp13);
            go.LoadBmp(XianJing1.id, bmp14);
            go.LoadBmp(Men.id, bmp15);
            #endregion
            //==========================================================================================================
            //游戏运行
            GameState = 2;
        }
        public override void Run()
        {

            go.Begin(0, ConsoleColor.DarkBlue, ConsoleColor.DarkBlue);
            go.DrawBmp(Ground.id, Ground.x - Client_X, Ground.y - Client_Y);
            go.DrawBmp(Ground2.id, Ground2.x - Client_X, Ground2.y - Client_Y);
            go.DrawBmp(Spoof[0].id, Spoof[0].x - Client_X, Spoof[0].y - Client_Y);
            if (ShuaFen)
                go.DrawBmp(Spoof[2].id, Spoof[2].x - Client_X, Spoof[2].y - Client_Y);
            if (coinb < 3)
                go.DrawBmp(Coin[0].id, Coin[0].x - Client_X, Coin[0].y - Client_Y);
            go.DrawBmp(Coin[1].id, Coin[1].x - Client_X, Coin[1].y - Client_Y);
            go.DrawBmp(Xin.id, Xin.x - Client_X, Xin.y - Client_Y);
            for (int i = 0; i < Pipe.Length; i++)
            {
                go.DrawBmp(Pipe[i].id, Pipe[i].x - Client_X, Pipe[i].y - Client_Y);
            }
            for (int i = 0; i < Empty.Length; i++)
            {
                go.DrawBmp(Empty[i].id, Empty[i].x - Client_X, Empty[i].y - Client_Y);
            }
            go.DrawBmp(Men.id, Men.x - Client_X, Men.y - Client_Y);
            go.DrawBmp(Mario.GetName(), Mario.x - Client_X, Mario.y - Client_Y);
            for (int i = 0; i < GuaiShou.Length; i++)
            {
                go.DrawBmp(GuaiShou[i].id, GuaiShou[i].x - Client_X, GuaiShou[i].y - Client_Y);
            }
            go.DrawBmp(Spoof[1].id, Spoof[1].x - Client_X, Spoof[1].y - Client_Y);
            go.DrawBmp(XianJing.id, XianJing.x - Client_X, XianJing.y - Client_Y);
            if (xianb)
                go.DrawBmp(XianJing1.id, XianJing1.x - Client_X, XianJing1.y - Client_Y);
            go.End();
            if (Ming < 1)
            {
                CCommon.win = false;
                GameState = 3;
            }
            if (Mario.x == 101 && Mario.y == 16)
            {
                CCommon.win = true;
                GameState = 3;
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2 * 2, 20);
            Console.Write("Score:\t{0}", CCommon.Score);
            Console.SetCursorPosition(12 * 2, 20);
            Console.Write("HP:\t{0}", Ming);
            //x键
            if (xxx)
            {

                Mario.x++;
                for (int i = 0; i < Pipe.Length; i++)
                {
                    if (Collide(Mario.x, Mario.y, Pipe[i].x, Pipe[i].y, Pipe[i].w, Pipe[i].h))
                    {
                        Mario.x--;
                    }
                }
            }
            //心
            if (xinb)
            {
                if (Xin.y == Coin[1].y - 1 && Xin.x == Coin[1].x || Xin.y == Coin[1].y && Xin.x == Coin[1].x + 1
                    || Xin.y == Empty[2].y - 1 && Xin.x == Empty[2].x)
                    Xin.x++;
                if (Xin.y < Ground.y - 1)
                    Xin.y++;
                if (Xin.y == Ground.y - 1 && Xin.x < Pipe[0].x - 1)
                    Xin.x++;
            }
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
                        }
                        break;
                    case 'j':
                        {
                            //如果此时是在地面上
                            if (Mario.GetCurrentJump() == -1)
                                //则将跳跃力赋值给当前跳跃力
                                Mario.SetCurrentJump(Mario.GetJump());
                        }
                        break;
                    case 'x':
                        {
                            xxx = !xxx;
                        }
                        break;
                    case 'a':
                        {
                            if (Mario.x > 0 && Mario.x > Client_X)
                                Mario.x--;
                            for (int i = 0; i < Pipe.Length; i++)
                            {
                                if (Collide(Mario.x, Mario.y, Pipe[i].x, Pipe[i].y, Pipe[i].w, Pipe[i].h))
                                {
                                    Mario.x++;
                                }
                            }

                        }
                        break;
                    case 'd':
                        {
                            Mario.x++;
                            for (int i = 0; i < Pipe.Length; i++)
                            {
                                if (Collide(Mario.x, Mario.y, Pipe[i].x, Pipe[i].y, Pipe[i].w, Pipe[i].h))
                                {
                                    Mario.x--;
                                }
                            }
                            if (Mario.x > Client_X + (Client_W / 2))
                            {
                                Client_X = Mario.x - (Client_W / 2);
                                Client_Y = Mario.y - (Client_H / 2);
                            }


                        }
                        break;
                }
            }


            //根据马里奥的位置判断窗口地图在世界地图上的位置

            //窗口地图越界判定
            if (Client_X < 0)
                Client_X = 0;
            if (Client_Y < 0)
                Client_Y = 0;
            if (Client_X > W - Client_W)
                Client_X = W - Client_W;
            if (Client_Y > H - Client_H)
                Client_Y = H - Client_H;
            #region 跳跃
            //执行跳跃
            if (Mario.GetCurrentJump() > 0)
            {
                //每次移动一格 判断是否跳跃被阻挡
                for (int i = 0; i < Mario.GetCurrentJump(); ++i)
                {
                    //马里奥的Y坐标减一
                    Mario.y -= 1;
                    //如果此时马里奥的位置为障碍物 
                    if (Collide(Mario.x, Mario.y, Spoof[0].x, Spoof[0].y, Spoof[0].w, Spoof[0].h))
                    {
                        Spoof[0].y -= 2;
                        //则马里奥的Y坐标回退1
                        Mario.y += 1;
                        //此时的跳跃力改为0s
                        Mario.SetCurrentJump(0);
                    }
                    if (Collide(Mario.x, Mario.y, Spoof[1].x, Spoof[1].y, Spoof[1].w, Spoof[1].h))
                    {
                        sbb = true;
                        //此时的跳跃力改为0s
                        Mario.SetCurrentJump(0);
                    }
                    if (Collide(Mario.x, Mario.y, Spoof[2].x, Spoof[2].y, Spoof[2].w, Spoof[2].h))
                    {
                        ShuaFen = true;
                        CCommon.Score += 20;
                        //此时的跳跃力改为0s
                        Mario.SetCurrentJump(0);
                    }
                    //如果此时马里奥的位置为可顶砖块
                    if (Collide(Mario.x, Mario.y, Coin[0].x, Coin[0].y, Coin[0].w, Coin[0].h) && coinb < 3)
                    {
                        Fenb = true;
                        coinb++;
                        //此时的跳跃力改为0
                        Mario.SetCurrentJump(0);
                    }
                    //如果此时马里奥的位置为可顶砖块
                    if (Collide(Mario.x, Mario.y, Coin[1].x, Coin[1].y, Coin[1].w, Coin[1].h))
                    {
                        if (!xinb)
                        {
                            CCommon.Score += 50;
                            Xin.x = Coin[1].x;
                            Xin.y = Coin[1].y - 1;
                            xinb = true;
                        }
                        //此时的跳跃力改为0
                        Mario.SetCurrentJump(0);
                    }
                    for (int j = 0; j < Empty.Length; j++)
                    {
                        if (Collide(Mario.x, Mario.y, Empty[j].x, Empty[j].y, Empty[j].w, Empty[j].h))
                        {
                            //则马里奥的Y坐标回退1
                            Mario.y += 1;
                            Mario.SetCurrentJump(0);
                        }
                    }
                }
                //如果此时的跳跃力不为0
                if (Mario.GetCurrentJump() != 0)
                    //则跳跃力重新赋值为-1
                    Mario.SetCurrentJump(Mario.GetCurrentJump() - 1);
            }
            //执行重力
            else if (Mario.GetCurrentJump() <= 0 && Mario.y < H - 1)
            {
                //当此时的跳跃力为0时
                Mario.SetCurrentJump(0);
                //马里奥增加重力 自动下落
                Mario.y += Mario.GetGravity();
                for (int j = 0; j < Pipe.Length; j++)
                {
                    if (Collide(Mario.x, Mario.y, Pipe[j].x, Pipe[j].y, Pipe[j].w, Pipe[j].h))
                    {
                        //马里奥的Y坐标回退1
                        Mario.y -= 1;
                        //此时的跳跃力赋值为-1 马里奥停止自动下落
                        Mario.SetCurrentJump(-1);
                    }
                }
                for (int j = 0; j < Empty.Length; j++)
                {
                    if (Collide(Mario.x, Mario.y, Empty[j].x, Empty[j].y, Empty[j].w, Empty[j].h))
                    {
                        //马里奥的Y坐标回退1
                        Mario.y -= 1;
                        //此时的跳跃力赋值为-1 马里奥停止自动下落
                        Mario.SetCurrentJump(-1);
                    }
                }
                for (int i = 0; i < GuaiShou.Length; i++)
                {
                    if (Mario.x == GuaiShou[i].x && Mario.y == GuaiShou[i].y)
                    {
                        GuaiShou[i].x = -10;
                        GuaiShou[i].y = -10;
                        Ming += 1;
                    }

                }
                //当马里奥下落的位置为障碍物时
                if ((Mario.y - Client_Y) >= Ground.y && Mario.x - Client_X <= Ground.x - Client_X + Ground.w - 1)
                {
                    //马里奥的Y坐标回退1
                    Mario.y -= 1;
                    //此时的跳跃力赋值为-1 马里奥停止自动下落
                    Mario.SetCurrentJump(-1);
                }
                if ((Mario.y - Client_Y) >= Ground2.y && Mario.x - Client_X <= Ground2.x - Client_X + Ground2.w - 1)
                {
                    //马里奥的Y坐标回退1
                    Mario.y -= 1;
                    //此时的跳跃力赋值为-1 马里奥停止自动下落
                    Mario.SetCurrentJump(-1);
                }
            }
            #endregion
            if (GuaiShou[0].x > -1)
                GuaiShou[0].x--;
            if (GuaiShou[2].x < 55 && GuaiShou[2].y == 16)
            {
                dirg2 = 1;
            }
            else if (GuaiShou[2].x > 60 && GuaiShou[2].y == 16)
            {
                dirg2 = -1;
            }
            if (GuaiShou[2].x == -10)
                dirg2 = 0;
            GuaiShou[2].x += dirg2;
            if (GuaiShou[1].x < 45 && GuaiShou[1].y == 16)
            {
                dirg1 = 1;
            }
            else if (GuaiShou[1].x > 50 && GuaiShou[1].y == 16)
            {
                dirg1 = -1;
            }
            if (GuaiShou[1].x == -10)
                dirg1 = 0;
            GuaiShou[1].x += dirg1;
            for (int i = 0; i < GuaiShou.Length; i++)
            {
                if (Mario.x == GuaiShou[i].x && Mario.y == GuaiShou[i].y)
                    Ming -= 1;
            }
            if (Mario.x > 38)
            {
                XianJing.x = 40;
                XianJing.y = 17;
            }
            else
            {
                XianJing.x = -10;
                XianJing.y = -10;
            }
            if (Mario.x > 75)
            {
                xianb = true;
            }
            if (Collide(Mario.x, Mario.y, XianJing1.x, XianJing1.y, XianJing1.w, XianJing1.h))
            {
                Ming -= 3;
            }
            if ((Mario.x == 40 && Mario.y == 16) || (Mario.x == 41 && Mario.y == 16))
            {
                Ming -= 3;
            }
            if (Fenb)
            {
                CCommon.Score += 20;
                Fenb = false;
            }
            if (sbb && Mario.y == Spoof[1].y + 3)
            {
                sbbb = true;
            }
            if (sbb && sbbb)
            {
                Spoof[1].y++;
            }
            if (Spoof[1].y - 1 == Mario.y && Spoof[1].x == Mario.x)
            {
                Ming -= 3;
            }
            if (Mario.x == Xin.x && Mario.y == Xin.y)
            {
                Xin.x = -10;
                Xin.y = -10;
                xinb = false;
                Ming -= 2;
            }


            ////游戏结束
            //GameState = 3;

            Thread.Sleep(60);
        }
        public override void End()
        {
            CCommon.GameScene = new COverScene();
        }

    }
}
