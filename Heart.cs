using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour//объект пополнения запаса жизней
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>(); //если персонаж касается объекта пополнения жизней, 
        if (character)                                            //количество его жизней увеличивается на 1, а объект исчезает
        {
            character.Lives++;
            Destroy(gameObject);
        }
    }


}
