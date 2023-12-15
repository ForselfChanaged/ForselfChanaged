using UnityEngine;

namespace Happyu
{

    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();//在场景中寻找挂载Mono单例
                    if (instance == null)
                    {
                        GameObject o = new GameObject("MonoSingleton of "+typeof(T));//若场景没有则创建空物体挂载单例脚本
                        instance = o.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        private void Awake()
        {
          if(instance == null)
            {
                instance = this as T;
                this.Init();
            }
        }
        protected virtual void Init()//初始化函数
        {
            Debug.Log(typeof(T) + "开始初始化");
            DontDestroyOnLoad(this);
        }

      
    }
}

