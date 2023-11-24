using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    Monster monster;
    LichMonster lich_monster;
    Lich_Attack lich_attack;
    float damage;
    // Start is called before the first frame update
    void Start()
    {

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
        Village.instance.player.playerUI.SendMessage("SetHp", damage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
