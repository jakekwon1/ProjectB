using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    public Animator ani { get; set; }
    float speed;
    public static BossMonster instance;

    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();
    }
    void Start()
    {
    }

    public void BossMonsterAni(int check)
    {
        if( check == 1)
        {
            ani.SetBool("aniBool", true);
        }
    }

    public void MoveBossMonster()
    {
        if(ani.GetBool("aniBool") == true)
        {
            float distance = Vector3.Distance(Village.instance.player.transform.position, transform.position);
            if (distance <= 8.0f)
            {
                ani.SetInteger("aniIndex", 1);
                speed = 0.0f;
                transform.LookAt(Village.instance.player.transform.position);
            }
            else if (distance >= 8.0f)
            {
                ani.SetInteger("aniIndex", 0);
                speed = 3.0f;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Village.instance.player.transform.position, Time.deltaTime * speed);
                transform.LookAt(Village.instance.player.transform.position);
            }
        }
    }

    void Update()
    {
        MoveBossMonster();
    }
}
