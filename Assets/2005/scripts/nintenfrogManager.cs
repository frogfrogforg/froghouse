using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nintenfrogManager : MonoBehaviour
{
    public static nintenfrogManager instance;
    public List<FrogHop> frogs;

    public int calledFrogNum;

    private void Awake()
    {
        instance = this;
    }
}
