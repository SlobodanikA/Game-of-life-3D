using System.Collections;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Vector3 targetPosition; // Координати, куди переміщується об'єкт
    public float speed = 10f; // Швидкість переміщення
    public float rotationTime = 0.5f; // Час на поворот (у секундах)

    private bool isMoving = false; // Прапорець, що вказує, чи переміщується об'єкт в даний момент

    private IEnumerator StartMovement()
    {
        // Визначаємо вектор напрямку до цільової позиції
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Поворот об'єкта у напрямку руху по осі Y
        Quaternion targetRotation = Quaternion.Euler(0f, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0f);

        // Плавний поворот до цільового повороту
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < rotationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationTime);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        // Затримка на пів секунди
        yield return new WaitForSeconds(0.5f);

        // Визначаємо відстань між поточною позицією та цільовою позицією
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Переміщення об'єкта до цільової позиції
        while (distance > 0.1f)
        {
            // Повторно визначаємо напрямок перед кожним кадром
            direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            distance = Vector3.Distance(transform.position, targetPosition);
            yield return null;
        }

        // Завершення переміщення
        isMoving = false;
    }

    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
        StartCoroutine(StartMovement());
    }

    public void MoveTo(Vector3 position, float newSpeed)
    {
        speed = newSpeed;
        MoveTo(position);
    }
}
