namespace Happyu
{
    //懒汉式单例
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
        //构造函数私有化确保此类不能被其他类调用实例化
        protected  Singleton()
        {
            this.Init();
        }
        protected virtual void Init()
        {

        }
    }
}