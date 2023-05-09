using UnityEngine;
using UnityEngine.EventSystems;


public class ProcessOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject TargetObj;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //TargetObj.GetComponent<ObjectMovement>().MoveTo(new Vector3(10, 0, 10));
        StartCoroutine(TargetObj.GetComponent<OceanScripts>().work());
    }
}

