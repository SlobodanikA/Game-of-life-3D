/*using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DisableSettingsButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject TargetObj;
    public Slider slider;

    public void OnPointerClick(PointerEventData eventData)
    {
        SetPrey(sliders[0].value);
        TargetObj.SetActive(false);
        
    }
}*/
using UnityEngine;
using UnityEngine.UI;
using static GameData;

public class DisableSettingsButton : MonoBehaviour
{
    public GameObject TargetObj;
    public Slider slider1;
    public Slider slider2;
    // Добавьте слайдеры, которые вы хотите использовать

    public void SetVariables()
    {
        Debug.Log("click");
        // Проверяем наличие ссылок на слайдеры
        if (slider1 != null && slider2 != null)
        {
            
            // Получаем значения из слайдеров
            int value1 =(int)slider1.value;
            int value2 =(int)slider2.value;
            // Получите значения из других слайдеров по аналогии

            // Устанавливаем значения в статические переменные вашего статического класса
            GameData.SetPrey(value1);
            GameData.SetPredator(value2);
            // Установите значения в другие статические переменные по аналогии
            TargetObj.SetActive(false);
        }
        else
        {
            Debug.LogError("Slider references are not set!");
        }
    }
}