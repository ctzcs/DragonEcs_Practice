using DCFApixels.DragonECS;

namespace Snake.Logic
{
    public class LogicModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            
            
        }
        
        
        //根据地图设计生成当前局部的墙壁(当前位置的九宫格)
        //根据地图设计生成食物
        //将蛇放在出生点
        //直到没有身体，游戏结束
        //蛇有一个速度，可以走半个格子（所以其实走完整个格子才会计算碰撞，但是直接每帧处理碰撞就好）
        
        
    }
}