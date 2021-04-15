using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsBar : MonoBehaviour //панель запаса сюрикенов
{

    private Transform[] bullets = new Transform[5];
    private Character character;
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = transform.GetChild(i);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (i < character.Bullets) bullets[i].gameObject.SetActive(true);//если сюрикенов на панели больше, чем самих сюрикенов,
            else bullets[i].gameObject.SetActive(false);                     //убирается 1 сюрикен на панели.
        }
    }

}
