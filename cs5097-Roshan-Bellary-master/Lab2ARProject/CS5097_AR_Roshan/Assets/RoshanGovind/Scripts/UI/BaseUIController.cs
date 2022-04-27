using UnityEngine;

public abstract class BaseUIController<T> : MonoBehaviour where T : BaseUIView
{
    [SerializeField]
    protected T View;

    //What state this panel should be shown in
    protected abstract GUIStateModel.GUIState PanelState { get; }

    protected bool active = false;

    protected virtual void Awake()
    {
        GUIStateChangedEvent.Instance.AddListener(OnGUIStateChanged);
    }

    protected virtual void OnDestroy()
    {
        GUIStateChangedEvent.Instance.RemoveListener(OnGUIStateChanged);
    }

    protected void OnGUIStateChanged(GUIStateModel.GUIState newState)
    {
        bool newActive = (newState == PanelState);

        if (newActive == active)
        {
            //New state already matches current state. Nothing needs to be done.
            return;
        }

        active = newActive;
        if (active)
        {
            EnablePanel();
        }
        else
        {
            DisablePanel();
        }

        View.gameObject.SetActive(newState == PanelState);
    }

    /// <summary>
    /// Enable panel is called whenever a panel becomes the main active screen.
    /// This should be used for adding event listeners and setting up the controller/view
    /// </summary>
    protected abstract void EnablePanel();

    /// <summary>
    /// Called whenever a panel is disabled.
    /// This should be used for removing event listeners and clearing the controller/view
    /// </summary>
    protected abstract void DisablePanel();

}