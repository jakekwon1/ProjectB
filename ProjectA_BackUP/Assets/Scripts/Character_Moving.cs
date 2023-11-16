using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Moving : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 1.5f;
    }


    void Update()
    {
        Vector3 tmp = transform.position;
        tmp.x += JoyStick2.Instance.dir.normalized.x * Time.deltaTime * speed;
        tmp.z += JoyStick2.Instance.dir.normalized.y * Time.deltaTime * speed;
        transform.position = tmp;
    }
}
