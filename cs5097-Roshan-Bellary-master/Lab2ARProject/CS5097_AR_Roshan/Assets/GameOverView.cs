using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : BaseUIView
{
    [SerializeField] private Button m_ExitButton;
    [SerializeField] private TextMeshProUGUI m_AliveTimeText;

    public override void PopulateView()
    {
        m_ExitButton.onClick.AddListener(OnExitGame);
        m_AliveTimeText.text = "Alive for " + GameLogic.Instance.AliveTime.ToString() + " seconds!";
    }

    private void OnExitGame()
    {
        GUIStateModel.SetGUIState(GUIStateModel.GUIState.TitleScreen);
    }
}
