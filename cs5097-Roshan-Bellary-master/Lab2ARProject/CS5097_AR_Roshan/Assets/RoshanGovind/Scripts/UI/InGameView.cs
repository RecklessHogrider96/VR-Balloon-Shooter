using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameView : BaseUIView
{
    [SerializeField] private Button m_ExitButton;
    [SerializeField] private TextMeshProUGUI m_CountdownText;
    [SerializeField] private TextMeshProUGUI m_AliveTimerText;
    [SerializeField] private TextMeshProUGUI m_EnemyCountText;

    float m_Timer;
    int m_Seconds;

    public override void PopulateView()
    {
        m_ExitButton.onClick.AddListener(OnExitGame);

        m_Timer = 0.0f;
        m_Seconds = 0;
    }

    public void UpdateAliveTimer()
    {
        m_Timer += Time.deltaTime;
        m_Seconds = (int)(m_Timer % 60);
        GameLogic.Instance.AliveTime = m_Seconds;
        m_AliveTimerText.text = GameLogic.Instance.AliveTime.ToString();
    }

    public void UpdatePlayerHealth()
    {
        m_EnemyCountText.text = GameLogic.Instance.Player.Health.ToString() + " / " + GameLogic.Instance.EnemiesCount.ToString();
    }

    public void UpdateCountdown(string countdownValueString)
    {
        int countdownValue = -2;
        if (countdownValueString.Length > 2)
        {

            m_CountdownText.gameObject.SetActive(true);
            m_CountdownText.text = countdownValueString.ToString();
        }
        else
        {
            int.TryParse(countdownValueString, out countdownValue);
        }

        if (countdownValue == 0)
        {
            m_CountdownText.text = "Begin!";
        }
        else if (countdownValue == -1)
        {
            m_CountdownText.gameObject.SetActive(false);
        }
        else if (countdownValue > 0)
        {
            // TODO: Will be called multiple times. RF it.
            m_CountdownText.gameObject.SetActive(true);
            m_CountdownText.text = countdownValue.ToString();
        }
    }

    private void OnExitGame()
    {
        GUIStateModel.SetGUIState(GUIStateModel.GUIState.TitleScreen);
    }
}
