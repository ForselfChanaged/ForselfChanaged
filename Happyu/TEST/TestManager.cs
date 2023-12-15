using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Happyu;

public class TestManager :MonoSingleton<TestManager>
{
    protected override void Init()
    {
        base.Init();
    }
    public void Func()
    {
        Debug.Log("monosingleton test");
    }
}
