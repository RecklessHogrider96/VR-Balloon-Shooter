using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartAliveTimerEvent : UnityEvent
{
    public static StartAliveTimerEvent Instance = new StartAliveTimerEvent();
}
