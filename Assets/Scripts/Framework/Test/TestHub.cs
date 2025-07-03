using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;


namespace Framework
{
#if UNITY_EDITOR
    public class TestHub : Sirenix.OdinInspector.Editor.OdinEditorWindow
    {
        #region 字段
        [BoxGroup("Module",showLabel:false,order:1)]
        [ShowInInspector,LabelText("模块列表")]
        private static List<IEditorTest> module = new();
        #endregion
     
        #region 生命周期
        protected override void OnEnable()
        {
            base.OnEnable();
            UnityEditor.Compilation.CompilationPipeline.compilationFinished += OnCompilationFinished;
            
        }
        

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UnityEditor.Compilation.CompilationPipeline.compilationFinished -= OnCompilationFinished;
            
        }
        

        #endregion
        

        #region Private
        
        void OpenWindowHandler()
        {
            if (module.Count<=0)
            {
                RefreshModule();
            }
        }

       

        [ButtonGroup("Header",order:0),Button("刷新模块",ButtonSizes.Small),GUIColor(0.3f,0.7f,0)]
        void RefreshModule()
        {
            ClearModulesHandler();
            var interfaceType = typeof(IEditorTest);
            var editorAsm = interfaceType.Assembly;
            module = editorAsm.GetTypes()
                .Where(type => interfaceType.IsAssignableFrom(type) && !type.IsAbstract
                && !type.IsDefined(typeof(IgnoreAttribute),true))
                .Select(type => type.GetConstructors().First().Invoke(null))
                .Cast<IEditorTest>()
                .ToList();
            AddModulesHandler();
            
            
        }
        
        /// <summary>
        /// 添加模块时，添加监听
        /// </summary>
        void AddModulesHandler()
        {
            AddSubModuleListener();
        }

        /// <summary>
        /// 移除模块时，移除监听
        /// </summary>
        void ClearModulesHandler()
        {
            RemoveSubModuleListener();
            module.Clear();
        }

        #endregion
        
        #region Static
        [UnityEditor.MenuItem("Tools/测试工具")]
        public static void OpenWindow()
        {
            var window = GetWindow<TestHub>();
            window.OpenWindowHandler();
        }
        

        #endregion
        
        #region 监听

        void AddSubModuleListener()
        {
            foreach (var test in module)
            {
                test.AddListener();
            }
        }

        void RemoveSubModuleListener()
        {
            foreach (var test in module)
            {
                test.RemoveListener();
            }
        }


        void OnCompilationFinished(object obj)
        {
            RefreshModule();
        }
        

        #endregion
    }
    
#endif  
}
