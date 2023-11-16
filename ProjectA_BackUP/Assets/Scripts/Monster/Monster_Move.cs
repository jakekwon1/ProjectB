using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Move : MonoBehaviour
{
    public GameObject target;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate( target.transform.position * Time.deltaTime * speed);
        if(transform.position == target.transform.position)
        {
            speed = 0.0f;
        }
        else if(transform.position != target.transform.position)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.transform.localPosition, Time.deltaTime * speed);
            transform.LookAt(target.transform.localPosition);
        }
    }
}
