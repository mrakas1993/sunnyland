using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Настройка движения")]
    public float speed = 5f; //Скорость бега
    public float jumpForce = 12f; //Сила прыжка
    [Header("Проверка земли")]
    public Transform groundCheck; //Точка под ногами персонажа
    private float groundCheckRadius = 0.2f; //Радиус круга сенсора
    public LayerMask groundLayer; // Слой земли
    
    private bool isGrounded; // Переменная для проверки земли
    private Rigidbody2D rb; // Подключаем физику
    private float horizontal_input; // Переменная для движения по оси X
    void Start()
    {
        //Находим компонент физики один раз при старте
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //Считываем нажатия клавиш ( по горизонтале то есть вправо и влево)
        horizontal_input = Input.GetAxisRaw("Horizontal");
        //Задаем движение персонажа с помощью физики по оси x, а по оси Y сохраняем
        rb.linearVelocity = new Vector2(horizontal_input * speed,rb.linearVelocity.y);
        //Разворачиваем персонажа
        Flip();
        //Проверяем стоим ли на земле
        if(groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
        //Прыгаем, только если нажат Пробел И персонаж на земле!
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    private void Flip()
    {
        if (horizontal_input > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal_input < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    } 

    //Рисуем красный шарик под ногами в окне Scene для настройки
    private void OnDrawGizmosSelected()
    {
        if(groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
        }
    }
}
