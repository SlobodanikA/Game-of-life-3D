using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour, IPointerClickHandler
{

    private Renderer objectRenderer;
    public GameObject TargetObj;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //objectRenderer = TargetObj.GetComponent<Renderer>();
        //objectRenderer.enabled = true;
        TargetObj.SetActive(true);
    }
}