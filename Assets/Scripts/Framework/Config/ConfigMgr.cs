/*using System;
using System.Collections.Generic;
using cfg;
using SimpleJSON;
using UnityEngine;

namespace Framework.Config
{
    public class ConfigMgr : Singleton<ConfigMgr> 
    {
        private Dictionary<string, string> _tableTxtDic = new();
        public Tables Tables { get; private set; }
        public event Action<Tables> OnInitTables;
        private ConfigMgr()
        {
        }

        public void InitTables(string tableFolder)
        {
            //加载所有的配置表
            Tables = new Tables(
                file => JSON.Parse(
                    ReadAllText($"{tableFolder}/{file}")
                    )
                );
            OnInitTables?.Invoke(Tables);
        }



        string ReadAllText(string path)
        {
            //File.ReadAllText($"{tableFolder}/{file}.json")
            var textAsset = ResMgr.Instance.Load<TextAsset>(path);
            
            return textAsset.text;
        }
        
        
	
        /*public async UniTask InitTablesTask()
        {
            await LoadTables();
            Tables = new Tables(file => JSON.Parse(_tableTxtDic[file]));
            OnInitTables?.Invoke(Tables);
        }#1#
        
        /*
        private async UniTask LoadTables()
        {
            _tableTxtDic.Clear();
            //AssetBundle会自动读取同一个bundle下的所有文件
            AllAssetsHandle assetHandle = ResMgr.Instance.LoadAllAsync<TextAsset>("sample_tbitem");
            await UniTask.WaitUntil(()=> assetHandle.IsDone); 
            foreach (var obj in assetHandle.AllAssetObjects)
            {
                var text = obj as TextAsset;
                if (text!= null)
                {
                    //获取所有的文件名，和对应文件名中的文本
                    _tableTxtDic.Add(text.name,text.text);
                }
            }
        }#1#
    } 
}*/