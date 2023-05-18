using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableSettingsButton : MonoBehaviour, IPointerClickHandler
{
    public Canvas canvasToDisable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canvasToDisable != null)
        {
            canvasToDisable.enabled = false;
        }
        else
        {
            Debug.LogError("Canvas reference is not set!");
        }
    }
}
