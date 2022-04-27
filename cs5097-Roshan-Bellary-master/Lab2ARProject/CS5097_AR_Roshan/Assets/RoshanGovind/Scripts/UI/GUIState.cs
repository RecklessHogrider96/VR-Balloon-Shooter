using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GUIStateModel
{
    public enum GUIState
    {
        TitleScreen,
        InGameScreen,
        GameOverScreen,
    }

    public static GUIState CurrentState { get; private set; } = GUIState.TitleScreen;

    //Sets the current state and sends out an event that the state has changed.
    public static void SetGUIState(GUIState newState)
    {
        CurrentState = newState;
        GUIStateChangedEvent.Instance.Invoke(CurrentState);
    }
}
