namespace Happyu
{
    //����ʽ����
    public class Singleton<T> where T : new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
        //���캯��˽�л�ȷ�����಻�ܱ����������ʵ����
        protected  Singleton()
        {
            this.Init();
        }
        protected virtual void Init()
        {

        }
    }
}