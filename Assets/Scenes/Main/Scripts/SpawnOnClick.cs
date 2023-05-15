using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnOnClick : MonoBehaviour, IPointerClickHandler
{
    private Renderer objectRenderer;
    public GameObject TargetObj;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        objectRenderer = GetComponent<Renderer>();
        TargetObj.GetComponent<OceanScripts>().spawn();
        gameObject.SetActive(false);
        objectRenderer.enabled = false;
    }
}
