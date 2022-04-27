using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : BaseUIController<InGameView>
{
    protected override GUIStateModel.GUIState PanelState => GUIStateModel.GUIState.InGameScreen;

    protected override void EnablePanel()
    {
        UpdateCountdownEvent.Instance.AddListener(UpdateCountdown);
        StartAliveTimerEvent.Instance.AddListener(StartUIUpdate);
        View.PopulateView();
    }

    private void StartUIUpdate()
    {
        StartCoroutine(UIUpdate());
    }

    IEnumerator UIUpdate()
    {
        for (;;)
        {
            View.UpdatePlayerHealth();
            View.UpdateAliveTimer();

            yield return new WaitForEndOfFrame();
        }
    }

    private void UpdateCountdown(string countdownValue)
    {
        View.UpdateCountdown(countdownValue);
    }

    protected override void DisablePanel()
    {
        StopCoroutine(UIUpdate());
    }
}
