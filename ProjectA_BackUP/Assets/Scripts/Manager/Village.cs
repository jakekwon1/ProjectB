using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Village : MonoBehaviour
{
    public static Village instance;
    public InstanceManager instanceManager;
    public Character player { get; set; }
    public Monster monster { get; set; }
    public LichMonster lichMonster { get; set; }
    public Lich_Attack lichAttack { get; set; }
    GameObject[] monsters;
    GameObject createObj;
    public ShopUI Shop;
    //List<Monster> monList { get; set; }
    float time;
    [SerializeField]
    public int monsterCount;
    [SerializeField]
    public int maxCount;

    private void Awake()
    {
        instance = this;
 
    }
    void Start()
    {
        monsterCount = 0;
        maxCount = 1000;
        instanceManager.Createinstance("Terrain", "Terrain_1");
        instanceManager.Createinstance("Charactor", "RPGHeroPolyart");
        if (SceneManager.GetActiveScene().name == "Village")
        {
            createObj = Resources.Load<GameObject>("Building/Smithy");
            createObj = GameObject.Instantiate<GameObject>(createObj);
            createObj.name = "Smithy";
            createObj.transform.position = new Vector3(-15, .5f, 20);
            createObj.transform.eulerAngles = new Vector3(0,140,0);

            createObj = Resources.Load<GameObject>("Charactor/Character_1");
            createObj = GameObject.Instantiate<GameObject>(createObj);
            createObj.name = "ShopNpc";
            createObj.transform.position = new Vector3(-13, .5f, 16);
            createObj.transform.eulerAngles = new Vector3(0, 160, 0);
            MonoBehaviour script = createObj.AddComponent<Shop>();
            Shop.shop = script as Shop;
        }
    }
    public void CreateMonster()
    {
        Monster createMonster =  (Monster)instanceManager.Createinstance("Monster", "Monster_1");
        
    }

    void CollisionDetect()
    {
        foreach (GameObject monster in monsters)
        {
            Collider monBounds = monster.GetComponent<Collider>();
            if (player.capsuleCollider.bounds.Intersects(monBounds.bounds))
            {
                monster.SetActive(false);
                monsterCount++;
                SendMessage("DamageTrigger", monBounds);
                break;
            }
        }
    }
    int spawn;
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Village")
        {
            time += Time.deltaTime;
            if (time >= 1.0f)
            {
                for (; spawn < maxCount;)
                {
                    CreateMonster();
                    time -= 1.0f;
                    spawn++;
                    if (spawn % 2 == 0)
                    {
                        LichMonster rcLichMonster = (LichMonster)instanceManager.Createinstance("Lich", "Lich_Monster");
                    }
                    break;
                }
            }
        }
        if (monsterCount >= maxCount)
        {
            SceneManager.LoadScene("Village");
        }
    }

    private void LateUpdate()
    {
        monsters = GameObject.FindGameObjectsWithTag("Monster");
        CollisionDetect();
    }
}
