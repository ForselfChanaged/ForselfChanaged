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
                    instance = FindObjectOfType<T>();//�ڳ�����Ѱ�ҹ���Mono����
                    if (instance == null)
                    {
                        GameObject o = new GameObject("MonoSingleton of "+typeof(T));//������û���򴴽���������ص����ű�
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
        protected virtual void Init()//��ʼ������
        {
            Debug.Log(typeof(T) + "��ʼ��ʼ��");
            DontDestroyOnLoad(this);
        }

      
    }
}

