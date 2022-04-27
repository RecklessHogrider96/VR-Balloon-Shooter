using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameView : BaseUIView
{
    [SerializeField] private Button m_StartGameButton;

    public override void PopulateView()
    {
        m_StartGameButton.onClick.AddListener(OnStartGame);
    }

    private void OnStartGame()
    {
        StartGameEvent.Instance.Invoke();

        GUIStateModel.SetGUIState(GUIStateModel.GUIState.InGameScreen);
    }
}
