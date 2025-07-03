using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Framework
{
    public class ResMgr : Singleton<ResMgr>
    {
        private ResMgr(){}
        //同步加载资源 需要返回
        public T Load<T>(string name) where T : Object
        {
            T res = Resources.Load<T>(name);
            if (res is GameObject)
            {
                //如果是游戏对象，直接实例化返回出去
                return Object.Instantiate(res);
            }
            else //如果是别的格式 直接返回
            {
                return res;
            }
        }

        /*//异步加载资源
        public async void LoadAsync<T>(string name, UnityAction<T> callBack) where T : Object
        {
            MonoMgr.I.StartCoroutine(ReallyLoadAsync<T>(name, callBack));
            //await ReallyLoadAsync(name, callBack).ToUniTask(PlayerLoopTiming.FixedUpdate);
        }
        
        private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callBack) where T : Object
        {
            ResourceRequest rq = Resources.LoadAsync<T>(name);
            yield return rq;//相当于挂起，只有rq被赋值之后才走下一步

            //到时候使用的时候会在callback这里填上一个使用该资源的函数，就叫回调
            if (rq.asset is GameObject)
            {
                callBack(Object.Instantiate(rq.asset) as T);
            }
            else callBack(rq.asset as T);
        }*/


        //异步资源加载
        public async UniTask<T> LoadTask<T>(string name) where T : Object
        {
            ResourceRequest rq = Resources.LoadAsync<T>(name);
            await rq;//相当于挂起，只有rq被赋值之后才走下一步

            //到时候使用的时候会在callback这里填上一个使用该资源的函数，就叫回调
            if (rq.asset is GameObject)
            {
                return Object.Instantiate(rq.asset) as T;
            }
            else
            {
                return rq.asset as T;
            }
        }
        
    }
}
