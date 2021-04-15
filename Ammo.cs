using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour//объект пополнения запаса сюрикенов
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();//если персонаж касается объекта пополнения запаса сюрикенов,  
        if (character)                                           //его боезапас увеличивается на 1, а объект пополнения исчезает
        {
            character.Bullets++;
            Destroy(gameObject);
        }
    }
}
