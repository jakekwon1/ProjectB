using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : SingleTon<ResourceManager>
{
    List<GameObject> rcChaList;
    List<GameObject> rcMonsterList;
    List<GameObject> rcLichMonsterList;
    List<GameObject> rcThunderList;
    List<Sprite> reIcon;

    // 1. 리소스 폴더에 있는 캐릭터 리소스를 로드
    public void LoadCharacter()
    {
        if (rcChaList == null)
            rcChaList = new List<GameObject>();
        GameObject[] rcTemp = Resources.LoadAll<GameObject>("Charactor");
        foreach (GameObject one in rcTemp)
        {
            rcChaList.Add(one);
        }
    }
    public void LoadMonster()
    {
        if (rcMonsterList == null)
            rcMonsterList = new List<GameObject>();
        GameObject[] rcTemp = Resources.LoadAll<GameObject>("Monster");
        foreach (GameObject one in rcTemp)
        {
            rcMonsterList.Add(one);
        }
    }
    public void LoadLichMonster()
    {
        if (rcLichMonsterList == null)
            rcLichMonsterList = new List<GameObject>();
        GameObject[] rcTemp = Resources.LoadAll<GameObject>("Lich");
        foreach (GameObject one in rcTemp)
        {
            rcLichMonsterList.Add(one);
        }
    }
    public void LoadThunderBolt()
    {
        if (rcThunderList == null)
            rcThunderList = new List<GameObject>();
        GameObject[] rcTemp = Resources.LoadAll<GameObject>("Attack");
        foreach (GameObject one in rcTemp)
        {
            rcThunderList.Add(one);
        }
    }
    public void LoadIcon()
    {
        if (reIcon == null)
            reIcon = new List<Sprite>();
        Sprite[] rcTemp = Resources.LoadAll<Sprite>("UI/Icon");
        foreach (Sprite one in rcTemp)
        {
            reIcon.Add(one);
        }
    }
    // 지형은 계속 로드 할 필요가 없다
    //public void LoadTerrain()
    //{
    //    if (rcTerrainList == null)
    //        rcTerrainList = new List<GameObject>();
    //    GameObject[] rcTemp = Resources.LoadAll<GameObject>("Terrain_1");
    //    foreach(GameObject one in rcTemp)
    //    {
    //        rcTerrainList.Add(one);
    //    }
    //}

    public GameObject GetCharacterRc(string name)
    {
        // o의 의미는 리스트에 저장된 원소 1개
        return rcChaList.Find(o => (o.name == name));
    }

    public GameObject GetTerrainRc(string name)
    {
        return Resources.Load<GameObject>("Terrain/" + name);
    }

    public GameObject GetBuildingRc(string name)
    {
        return Resources.Load<GameObject>("Building/" + name);
    }
    public GameObject GetMonsterRc(string name)
    {
        return rcMonsterList.Find(o => (o.name == name));
    }
    public GameObject GetLichMonsterRc(string name)
    {
        return rcLichMonsterList.Find(o => (o.name == name));
    }
    public GameObject GetThunderBoltRc(string name)
    {
        return rcThunderList.Find(o => (o.name == name));
    }
}
