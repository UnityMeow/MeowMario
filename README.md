# MeowMario

### 项目说明
- 入口脚本  
	主入口 -> Program.cs  
- 场景相关  
	场景基类 -> CScene.cs  
	开始场景 -> CStartScene.cs  
	游戏场景 -> CRunScene.cs  
	结束场景 -> COverScene.cs  
- 绘制相关  
	图片类 -> CBmp.cs  
	绘制类 -> CGameOutput.cs  
- 物体相关  
	物体类 -> CGameObject.cs  
	物体管理 -> CGameObjMgr.cs  
- 英雄相关  
	英雄类 -> CHero.cs  
- 公共类  
	公用静态类 -> CCommon.cs  
### 游戏说明  
- 操作相关  
	回车键确认选项  
	键盘'a' 'd'控制左右移动 'j'控制跳跃  
- 游戏规则  
	HP低于0游戏结束  
	到达终点游戏胜利  
	记得注意陷阱机关  
### Bug说明  
- 不要去选“选择关卡”这个选项，关卡没有做  
-  左右移动只能检测当前按下 持续按下会闪现  