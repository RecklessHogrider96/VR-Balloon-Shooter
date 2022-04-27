using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateCountdownEvent : UnityEvent<string>
{
    public static UpdateCountdownEvent Instance = new UpdateCountdownEvent();
}
