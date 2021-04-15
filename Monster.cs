using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit//неподвижный монстр
   
{
    private Animator animator;
    protected virtual void Awake() {
        animator = GetComponent<Animator>();
    }
    protected virtual void Start() { }

    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.GetComponent<Bullet>();
        if (bullet)
        {
            animator.SetTrigger("Die");//неподвижный монстр умирает от пули
            ReceiveDamage();
        }
    }
}
