using System.IO;
using Sirenix.Serialization;

namespace Framework
{
    /// <summary>
    /// 序列化世界的静态类
    /// </summary>
    public class WorldSerialization
    {
        /// <summary>
        /// 保存世界，注意，只会保存public变量
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        /// <param name="folderPath"></param>
        /// <typeparam name="T"></typeparam>
        public static void Save<T>(string folderPath,string fileName, T data) where T:World
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string path = $"{folderPath}/{fileName}";
            byte[] bytes = SerializationUtility.SerializeValue(data,DataFormat.Binary);
            
            File.WriteAllBytes(path,bytes);
            data.OnSave();
            MyLog.Log($"{typeof(T).Name} World==>Saving!");
        }

        /// <summary>
        /// 加载世界
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Load<T>(string folderPath,string fileName) where T:World
        {
            string path = $"{folderPath}/{fileName}";
            if (!File.Exists(path)) return default;
            byte[] bytes = File.ReadAllBytes(path);
            MyLog.Log($"{typeof(T).Name} World==>Loading!");
            return SerializationUtility.DeserializeValue<T>(bytes, DataFormat.JSON);
        }
    }
}