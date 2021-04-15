using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour //панель запаса жизней
{
    private Transform[] hearts = new Transform[5];
    private Character character;
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for (int i=0; i< hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < character.Lives) hearts[i].gameObject.SetActive(true);//если жизней на панели больше, чем самих жизней,
            else hearts[i].gameObject.SetActive(false);                   //убирается 1 жизнь на панели
        }
    }
}
