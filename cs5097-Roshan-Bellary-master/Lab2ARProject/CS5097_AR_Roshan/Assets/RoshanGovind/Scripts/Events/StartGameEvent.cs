using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartGameEvent : UnityEvent    
{
    public static StartGameEvent Instance = new StartGameEvent();
}
