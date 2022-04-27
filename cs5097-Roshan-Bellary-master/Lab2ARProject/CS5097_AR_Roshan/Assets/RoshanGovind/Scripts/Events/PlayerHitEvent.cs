using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHitEvent : UnityEvent<int>
{
    public static PlayerHitEvent Instance = new PlayerHitEvent();
}
