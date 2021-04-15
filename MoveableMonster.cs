using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster//движущийся между объектами монстр
{
    [SerializeField]
    private float speed = 2.0F;

    private Vector3 direction;

    private Animator animator;

    private Bullet bullet;

    private SpriteRenderer sprite;
   
    protected override void Awake()

    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
        animator = GetComponent<Animator>();
    }

    protected override void Start()
    {
        direction = transform.right;
    }

    protected override void Update()
    {
        Move();
    }
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            animator.SetTrigger("Die");//движущийся монстр умирает от попадания сюрикена, анимация - смерть
            ReceiveDamage();
        }
    }
    private void Move()//монстр должен разворачиваться, только если перед ним стена. Если персонаж - не должен.
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.4F, 0.1F);
        if (colliders.Length > 0 && colliders.All (x=> !x.GetComponent<Character>()) ) direction *= -1.0F;//встретившийся объект - не персонаж
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;
    }
}




