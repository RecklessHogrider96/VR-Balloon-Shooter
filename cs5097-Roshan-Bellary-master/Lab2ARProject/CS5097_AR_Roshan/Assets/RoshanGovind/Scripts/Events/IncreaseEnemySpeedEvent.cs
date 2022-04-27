using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IncreaseEnemySpeedEvent : UnityEvent<float>
{
    public static IncreaseEnemySpeedEvent Instance = new IncreaseEnemySpeedEvent();
}
