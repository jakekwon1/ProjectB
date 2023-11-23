using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InstanceManager : MonoBehaviour
{
    List<Monster> monsterList;
    List<LichMonster> lichMonsterList;
    List<Lich_Attack> thunderBoltList;

    private void Awake()
    {
        monsterList = new List<Monster>();
        lichMonsterList = new List<LichMonster>();
        thunderBoltList = new List<Lich_Attack>();
    }
    private void Start()
    {

    }
    // 근접 몬스터
    public Monster GetUsableMonster(string name)
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            if (monsterList[i].gameObject.activeSelf == false && monsterList[i].gameObject.name == name)
            {
                return monsterList[i];
            }
        }
        GameObject rcMonster = ResourceManager.instance.GetMonsterRc(name);
        GameObject createdObj = GameObject.Instantiate<GameObject>(rcMonster);
        createdObj.name = name;
        createdObj.SetActive(false);
        Monster addedScript = createdObj.AddComponent<Monster>();
        //addedScript.navi = createdObj.AddComponent<NavMeshAgent>();
        monsterList.Add(addedScript);
        return addedScript;
    }
    // 원거리 몬스터
    public LichMonster GetUsableLichMonster(string name)
    {
        for (int i = 0; i < lichMonsterList.Count; i++)
        {
            if (lichMonsterList[i].gameObject.activeSelf == false && lichMonsterList[i].gameObject.name == name)
            {
                return lichMonsterList[i];
            }
        }
        GameObject rcLichMonster = ResourceManager.instance.GetLichMonsterRc(name);
        GameObject createdObj = GameObject.Instantiate<GameObject>(rcLichMonster);
        createdObj.name = name;
        createdObj.SetActive(false);
        LichMonster addedScript = createdObj.AddComponent<LichMonster>();
        Village.instance.lichMonster = addedScript;
        lichMonsterList.Add(addedScript);
        return addedScript;
    }
    public Lich_Attack GetUsableThunderBolt(GameObject obj, string name)
    {
        for (int i = 0; i < thunderBoltList.Count; i++)
        {
            if (thunderBoltList[i].gameObject.activeSelf == false && thunderBoltList[i].gameObject.name == name)
            {
                return thunderBoltList[i];
            }
        }
        GameObject reThundeBolt = ResourceManager.instance.GetThunderBoltRc(name);
        GameObject createdObj = GameObject.Instantiate<GameObject>(reThundeBolt);
        createdObj.name = name;
        createdObj.SetActive(false);
        Lich_Attack addedScript = createdObj.AddComponent<Lich_Attack>();
        Village.instance.lichAttack = addedScript as Lich_Attack;
        createdObj.transform.localPosition = obj.transform.GetChild(2).position;
        thunderBoltList.Add(addedScript);
        return addedScript;
    }

    // 생성한 인스턴스를 호출한 곳으로 반환
    public MonoBehaviour Createinstance(string type, string name)    // MonoBehaviour 설정하면 모든 형변환 가능
    {
        MonoBehaviour addedScript = null;
        GameObject createObj;
        GameObject rcCharactor;

        switch (type)
        {
            case "Charactor":
                {
                    // Ray를 이용하여 지형의 높이를 구하여 배치
                    // 특정위치에서 아래로 향하는 광선을 캐스팅
                    Vector3 pos = RayHelper.GetPositionOnTerrain(Vector3.zero);
                    rcCharactor = ResourceManager.instance.GetCharacterRc(name);
                    createObj = GameObject.Instantiate<GameObject>(rcCharactor);
                    addedScript = createObj.AddComponent<Character>();
                    Village.instance.player = addedScript as Character;
                    (addedScript as Character).navi = createObj.AddComponent<NavMeshAgent>();
                    createObj.name = name;
                    createObj.transform.position = pos;
                    UICharactorInfo createdUI = UIManager.instance.CreateCharactorInfoUI(name, createObj);
                    Vector2 screenPos = Camera.main.WorldToScreenPoint((addedScript as Character).hpTr.position);
                    createdUI.transform.position = screenPos;
                    (addedScript as Character).playerUI = createdUI;
                    //CustomCamera.instance.SetPlayer(addedScript as Character);
                    break;
                }

            case "Monster":
                {
                    //몬스터의 생성 좌표는 파일 형태로(csv) 존재. 하지만 지금은 파일을 안만들었기 때문에 랜덤 값으로 배치
                    Vector3 createPos = new Vector3(Random.Range(-49f, 49f), 0, Random.Range(-49f, 49f));
                    Vector3 pos = RayHelper.GetPositionOnTerrain(createPos);
                    Monster monster = GetUsableMonster(name);
                    monster.gameObject.transform.position = pos;
                    monster.gameObject.SetActive(true);
                }
                break;
            case "Lich":
                {
                    Vector3 createPos = new Vector3(Random.Range(-49f, 49f), 0, Random.Range(-49f, 49f));
                    Vector3 pos = RayHelper.GetPositionOnTerrain(createPos);
                    LichMonster lichMonster = GetUsableLichMonster(name);
                    lichMonster.gameObject.transform.position = pos;
                    lichMonster.gameObject.SetActive(true);
                }
                break;
            case "Terrain":
                {
                    GameObject rcTerrain = ResourceManager.instance.GetTerrainRc(name);
                    createObj = GameObject.Instantiate<GameObject>(rcTerrain);
                    createObj.name = name;
                    createObj.transform.position = Vector3.zero;
                    break;
                }
        }
        return addedScript;
    }
}
