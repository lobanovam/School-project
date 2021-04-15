using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit //главный персонаж
{
    [SerializeField]
    private int lives = 5;  //количество жизней
    public int Lives   //для панели жизней
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;
   

    [SerializeField]
    private int bullets= 5;//количетсов сюрикенов
    public int Bullets //для панели сюрикенов
    {
        get { return bullets; }
        set
        {
            if (value < 5) bullets = value;
            bulletsBar.Refresh();
        }
    }
    private BulletsBar bulletsBar;



    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 5.0F;

    private bool isGrounded = false;
    

    private Bullet bullet;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); } //для взаимодействия с аниматором Unity
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()      //подгрузка компонентов                   
    {
        bulletsBar = FindObjectOfType<BulletsBar>();
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
 
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()//отправная точка в специализированные методы, вызывается каждый кадр.
    {
        if (isGrounded)  State = CharState.Idle; 
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();
        if (Input.GetButtonDown("Fire1")) Shoot();

    
    }

    private void Run() //метод, в котором реализован бег
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);//непосредственно движение
        sprite.flipX = direction.x < 0.0F; //поворот персонажа (смотрит по направлению движения)
       if (isGrounded) State = CharState.Run;//CharState - переменная, работающая с анимацией персонажа. Здесь - анимация "бег".
     
    }
    private void Jump()//метод, в котором реализован прыжок
    {
        rigidbody.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
       
    }
    private void Shoot()//метод, в котором реализовано метание сюрикенов
    {
        if (Bullets > 0)
        {
            Vector3 position = transform.position; position.y += 0.2F;
            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet; //появление сюрикена посредине персонажа
            newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);//движение сюрикена по направлению движения персонажа
            newBullet.Parent = gameObject;
            Bullets--;
        }

    }

    public override void ReceiveDamage()// процедура получения урона
    {
      
        Lives--; 
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 5.0F,ForceMode2D.Impulse); //небольшое откидывание персонажа при получении урона
        Debug.Log(lives);
        if (Lives == 0)
        {
           
            Die(); //вызов метода, описанного в классе прародителе "Unit"
        }
        
    }
    private void CheckGround() //метод, проверяющий на земле (у стены) ли персонаж
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1F); //проверка коллайдеров в окружности опр. радиуса
        isGrounded = colliders.Length > 1; //если таких коллайдеров больше одного, значит персонаж стоит на земле (у стены).
        if(!isGrounded) State = CharState.Jump;//если персонаж в водухе, анимация - прыжок
    }

    private void OnTriggerEnter2D(Collider2D collider)//метод, отвечающий за вызов метода ReceiveDamage(),
                                                      //т.е.за начало процедуры получения урона
    { 
    
      Unit unit = collider.gameObject.GetComponent <Unit>();//если объектом, с которым соприкоснулся персонаж, является
        if (unit) { ReceiveDamage(); }                      //другой живой объект (т.е. монстр), нужно получить урон
    }
 }

public enum CharState //перечисление для взаимодействия с аниматором Unity
{
    Idle,
    Run,
    Jump,
}