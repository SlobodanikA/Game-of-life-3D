using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Vector3 targetPosition; // Координаты, к которым перемещается объект
    public float speed = 10f; // Скорость перемещения

    private bool isMoving = false; // Флаг, указывающий, перемещается ли объект в данный момент

    void Update()
    {
        if (isMoving)
        {
            // Вычисляем вектор направления к целевой позиции
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Вычисляем расстояние между текущей позицией и целевой позицией
            float distance = Vector3.Distance(transform.position, targetPosition);

            // Если объект еще не достиг целевой позиции, перемещаем его
            if (distance > 0.1f)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                // Если объект достиг целевой позиции, останавливаем его перемещение
                isMoving = false;
            }
        }
    }

    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }
    public void MoveTo(Vector3 position, float newSpeed)
    {
        speed = newSpeed;
        targetPosition = position;
        isMoving = true;
    }
}
