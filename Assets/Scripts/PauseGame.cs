using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                // Если игра уже на паузе, снимаем паузу
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                // Если игра не на паузе, ставим ее на паузу
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }
}