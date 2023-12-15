
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Happyu
{
    public class Messenger:Singleton<Messenger>
    {
        private GUIStyle style;
        private Stack<LogInfo> mLogPool;
        private Queue<LogInfo> mLogs;

        protected override void Init()
        {
            base.Init();
            MonoTools.Instance.OnGuiCallback += OnGUI;
            mLogPool = new Stack<LogInfo>();
            mLogs = new Queue<LogInfo>();
            style = new GUIStyle() { fontSize = 30};
        }
        private void OnGUI()
        {
          
        }
        public void Start()
        {

        }
        private class BaseMessage
        {
            public string text;
            public Vector2 curPos;
        }
        private class DelayMsg : BaseMessage
        {
            public float alpha;
            protected E_State state;
            public bool Finished => state == E_State.Finished;
            public virtual void Init()
            {
                alpha = 0;
                state = E_State.Wait;
            }
            public async void Timer(int millisecondsDelay)
            {
                await Task.Delay(millisecondsDelay);
                state = E_State.Start;
            }
            public virtual void Update()
            {
                switch (state)
                {
                    case E_State.Start:
                        if (alpha <= 0) state = E_State.Finished;
                        else alpha -= Time.deltaTime;
                        break;
                    case E_State.Wait:
                        if (alpha >= 1) alpha = 1;
                        else alpha += 2 * Time.deltaTime;
                        break;
                    default:
                        break;
                }
            }
        }
        private class LogInfo : DelayMsg//¸¡¶¯ÈÕÖ¾
        {
            public float targetPosY;
            public byte EnterNum;
            public bool CanSplit => EnterNum == 0;
            public override void Init()
            {
                base .Init();
                EnterNum = 0;
            }
            public override void Update()
            {
                base.Update();
                curPos.y = Mathf.Lerp(curPos.y, targetPosY, 10 * Time.deltaTime);
            }
        }
    }
    public enum E_State : byte
    {
        Start,
        Finished,
        Wait
    }

}

