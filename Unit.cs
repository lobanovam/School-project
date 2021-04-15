using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Unit : MonoBehaviour//класс прародитель
{
    public virtual void ReceiveDamage()//смерть для монстра

    {
        Destroy(gameObject, 0.45F);
    }
    protected virtual void Die()//смерть для персонажа
    {
        Destroy(gameObject, 0.45F);
        SceneManager.LoadScene(1);//после смерти персонажа - главное меню

    }
}
