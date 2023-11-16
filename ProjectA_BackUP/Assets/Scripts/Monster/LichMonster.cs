using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LichMonster : MonoBehaviour
{
    //public Character player { get; set; }
    public InstanceManager instanceManager;
    public byte hp;
    public Animator ani;
    public GameObject attackObj { get; set; }
    List<Lich_Attack> thunderBoltList;
    private float speed;
    private float attacSpeed;
    public CapsuleCollider capsuleCollider { get; set; }

    private void Awake()
    {
        thunderBoltList = new List<Lich_Attack>();
        instanceManager = GameObject.Find("GameManager").GetComponent<InstanceManager>();
    }
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        ani = GetComponent<Animator>();
        //attackObj.SetActive(false);
        //attackObj.transform.parent = null;
        speed = 3.0f;
        //attacSpeed = 6.0f;
        hp = 150;
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
        //CreateBullet();
        Lich_Attack script = instanceManager.GetUsableThunderBolt(this.gameObject, "ThunderBolt_Small");
        if (!script.gameObject.activeSelf)
        {
            script.gameObject.SetActive(true);
            script.gameObject.transform.position = transform.GetChild(2).position;
        }
    }
    public void CreateBullet()
    {
        //for (int i = 0; i < thunderBoltList.Count; i++)
        //{
        //    if (thunderBoltList[i].gameObject.activeSelf == false && thunderBoltList[i].gameObject.name == name)
        //    {
        //         = thunderBoltList[i];
        //    }
        //}
        //GameObject reThundeBolt = ResourceManager.instance.GetThunderBoltRc("ThunderBolt_Small");
        //GameObject createdObj = GameObject.Instantiate<GameObject>(reThundeBolt);
        //createdObj.name = "ThunderBolt";
        //createdObj.SetActive(false);
        //createdObj.AddComponent<Lich_Attack>();
        //createdObj.transform.localPosition = this.transform.GetChild(2).position;




        //Lich_Attack addedScript = createdObj.AddComponent<Lich_Attack>();
        //Village.instance.lichAttack = addedScript as Lich_Attack;
        //thunderBoltList.Add(addedScript);
        //return addedScript;
        //thunderBolt.gameObject.SetActive(true);
    }
    void Update()
    {
        MoveMonster(); 
    }
}
