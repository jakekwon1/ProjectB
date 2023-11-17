using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LichMonster : MonoBehaviour
{
    public InstanceManager instanceManager;
    public byte hp;
    public Animator ani;
    public GameObject attackObj { get; set; }
    private float speed;
    public CapsuleCollider capsuleCollider { get; set; }
    public byte damage;

    private void Awake()
    {
        instanceManager = GameObject.Find("GameManager").GetComponent<InstanceManager>();
    }
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        ani = GetComponent<Animator>();
        speed = 3.0f;
        hp = 150;
        damage = 20;
    }
    public void MoveMonster()
    {
        float distance = Vector3.Distance(Village.instance.player.transform.position, transform.position);
        if (distance <= 8.0f)
        {
            ani.SetInteger("aniIndex", 1);
            speed = 0.0f;
        }
        else if (distance >= 8.0f)
        {
            ani.SetInteger("aniIndex", 0);
            speed = 3.0f;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Village.instance.player.transform.position, Time.deltaTime * speed);
            transform.LookAt(Village.instance.player.transform.position);
        }
        
    }
    public void AttackMonster()
    {
        Lich_Attack script = instanceManager.GetUsableThunderBolt(this.gameObject, "ThunderBolt_Small");
        if (!script.gameObject.activeSelf)
        {
            script.gameObject.SetActive(true);
            script.gameObject.transform.position = transform.GetChild(2).position;
        }
    }
    void Update()
    {
        MoveMonster(); 
    }
}
