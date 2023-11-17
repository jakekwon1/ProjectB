using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    Monster monster;
    LichMonster lich_monster;
    Lich_Attack lich_attack;
    //byte hp { get; set; }
    byte damage;

    //Collider a;
    // Start is called before the first frame update
    void Start()
    {
        //hp = Village.instance.player.hp;
    }

    public void DamageTrigger(Collider monBounds)
    {
        MonoBehaviour script = monBounds.gameObject.GetComponent<MonoBehaviour>();
        if (script.name == "Monster_1")
        {
            monster = script as Monster;
            damage = monster.damage;
        }
        if (script.name == "Lich_Monster")
        {
            lich_monster = script as LichMonster;
            damage = lich_monster.damage;
        }
        if (script.name == "ThunderBolt_Small")
        {
            lich_attack = script as Lich_Attack;
            damage = lich_attack.damage;
        }
        Village.instance.player.hp -= damage;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
