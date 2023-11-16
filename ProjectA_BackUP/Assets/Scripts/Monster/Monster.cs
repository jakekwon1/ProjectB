using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Character player { get; set; }
    //public NavMeshAgent navi { get; set; }
    public byte hp;
    public Animator ani;
    private float speed;
    public CapsuleCollider capsuleCollider { get; set; }

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        speed = 6.0f;
        hp = 100;
    }
    public void MoveMonster()
    {
        float distance = Vector3.Distance(Village.instance.player.transform.position, transform.position);
        if (distance <= 1.5f)
        {
            speed = 0.0f;
        }
        else if (distance >= 1.5f)
        {
            speed = 6.0f;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Village.instance.player.transform.position, Time.deltaTime * speed);
            transform.LookAt(Village.instance.player.transform.position);
        }
    }

    void Update()
    {
        MoveMonster();
    }
    private void LateUpdate()
    {

    }
}
