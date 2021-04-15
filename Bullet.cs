using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour//сюрикен
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    
    private float speed = 10.0F;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }
    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Destroy(gameObject, 0.4F);//сюрикен уничтожается через некоторое время
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);//движение
    }

    private void OnTriggerEnter2D(Collider2D collider)//если коснулся какого-то "живого" объекта                                         
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit&&unit.gameObject != parent )//если объект - не персонаж, который выпустил сюрикен
        {
            Destroy(gameObject);//разрушает объект (монстра)
        }
    }
}
