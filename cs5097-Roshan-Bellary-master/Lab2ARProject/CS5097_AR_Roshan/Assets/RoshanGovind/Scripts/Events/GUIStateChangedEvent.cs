using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GUIStateChangedEvent : UnityEvent<GUIStateModel.GUIState>
{
    public static GUIStateChangedEvent Instance = new GUIStateChangedEvent();
}
