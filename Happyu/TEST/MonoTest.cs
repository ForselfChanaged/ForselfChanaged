using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Happyu;

public class MonoTest : MonoBehaviour
{
    private void Start()
    {
        TestManager.Instance.Func();
       // MonoTools.Instance.AddLoop(Func2);
        Messenger.Instance.Start();
    }
    private void Func2()
    {
        Debug.Log(Time.time);
    }
    private void OnDisable()
    {
     
    }
}
