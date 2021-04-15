using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour//наносящие урон шипы
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)//если персонаж коснулся шипов, он получает урон
        {
            unit.ReceiveDamage();
        }
    }
}
