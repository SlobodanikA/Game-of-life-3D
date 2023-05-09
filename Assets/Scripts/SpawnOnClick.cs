using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject TargetObj;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        TargetObj.GetComponent<OceanScripts>().spawn();
    }
}
