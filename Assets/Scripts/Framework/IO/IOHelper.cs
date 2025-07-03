using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Framework.IO
{
    public class IOHelper
    {
        public static async UniTask<string> ReadTxtFileTask(string path)
        {
            UnityWebRequest req = UnityWebRequest.Get(path);
            await req.SendWebRequest();
            if(req.result != UnityWebRequest.Result.Success)
            {
                MyLog.Error("ReadTxtFile failed: " + req.error);
                return string.Empty;
            }
            string text = req.downloadHandler.text;
            return text;
        }
        
    }
}