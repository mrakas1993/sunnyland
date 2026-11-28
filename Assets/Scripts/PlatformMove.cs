using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform startPoint; //Пустой объект Старт
    public Transform finishPoint;//Пустой объект Финиш
    public float speed = 3f; // Скорость платформы

    private Vector3 targetPos; //Адрес в навигаторе (то есть к какой точке двигаться)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ставим платформу ровно на старт и отправляем к финишу
        transform.position = startPoint.position;
        targetPos = finishPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);

        //Если доехали до цели - меняем направление
        if(transform.position == targetPos)
        {
            if(targetPos == finishPoint.position)
            {
                targetPos = startPoint.position;
            }
            else
            {
                targetPos = finishPoint.position;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPoint.position, finishPoint.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
