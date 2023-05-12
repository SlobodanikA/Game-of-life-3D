using UnityEngine;
using UnityEngine.EventSystems;


public class ProcessOnClick : MonoBehaviour, IPointerClickHandler
{
    private Renderer objectRenderer;
    public GameObject TargetObj;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //TargetObj.GetComponent<ObjectMovement>().MoveTo(new Vector3(10, 0, 10));
        TargetObj.GetComponent<OceanScripts>().startWork();
        objectRenderer = GetComponent<Renderer>();
        gameObject.SetActive(false);
    }
}

