using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : BaseUIController<GameOverView>
{
    protected override GUIStateModel.GUIState PanelState => GUIStateModel.GUIState.GameOverScreen;

    // Start is called before the first frame update
    protected override void EnablePanel()
    {
        // Populate View.
        View.PopulateView();

        // Raise Event for GameController.

    }

    // Update is called once per frame
    protected override void DisablePanel()
    {

    }
}
