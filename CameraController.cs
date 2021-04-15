using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour//скрипт камеры
{
    [SerializeField]
    private float speed = 2.0F;
    [SerializeField]
    private Transform target;
    

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;//камера ищет на сцене персонажа
    }

    private void Update()
    {
        Vector3 position = target.position;        position.z = -8.0F;                           //камера плавно следует за персонажем
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime); //со смещением по оси z 
    }


}

