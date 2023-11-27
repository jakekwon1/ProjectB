using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    public float frontFootAttackTime;
    public float breathAttackTime;
    float distance;

    public Animator ani { get; set; }
    float speed;
    public static BossMonster instance;
    private CapsuleCollider BasicCapsuleCollider;
    private BoxCollider frontFootCollider;

    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();
        BasicCapsuleCollider = GameObject.Find("AttackPos").GetComponent<CapsuleCollider>();
        frontFootCollider = GameObject.Find("HandAttack").GetComponent<BoxCollider>();
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
        if (ani.GetBool("aniBool") == true)
        {
            frontFootAttackTime += Time.deltaTime;
            float frontTime = frontFootAttackTime;
            breathAttackTime += Time.deltaTime;
            float breathTime = breathAttackTime;
            distance = Vector3.Distance(Village.instance.player.transform.position, transform.position);
            if (distance <= 8.0f)
            {
                ani.SetInteger("aniIndex", 1);
                speed = 0.0f;
                transform.LookAt(Village.instance.player.transform.position);
            }
            else if (frontFootAttackTime >= 10.0f)
            {
                ani.SetInteger("aniIndex", 2);
                speed = 0.0f;
                transform.LookAt(Village.instance.player.transform.position);
                frontFootAttackTime -= frontTime;
            }
            else if (breathAttackTime >= 23.0f && distance >= 8.0f)
            {
                ani.SetInteger("aniIndex", 3);
                speed = 0.0f;
                transform.LookAt(Village.instance.player.transform.position);
                breathAttackTime -= breathTime;
            }
            else
            {
                ani.SetInteger("aniIndex", 0);
                speed = 3.0f;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Village.instance.player.transform.position, Time.deltaTime * speed);
                transform.LookAt(Village.instance.player.transform.position);
            }
        }
    }
    public void BasicAttack()
    {
        if (Village.instance.player.capsuleCollider.bounds.Intersects(BasicCapsuleCollider.bounds))
        {
            Village.instance.player.gameObject.SetActive(false);
        }
    }
    public void FrontFootAttack()
    {
        if (Village.instance.player.capsuleCollider.bounds.Intersects(frontFootCollider.bounds))
        {
            Village.instance.player.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        MoveBossMonster();
    }
}
