using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButtonClick : MonoBehaviour, IPointerClickHandler
{
    // ������� �� ������ �����

    // ����� ������ �� ������ �����
    GameObject otherObject;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        loadscene();
    }
    public void loadscene()
    {
  
       SceneManager.LoadScene("main");
    
    }
}
