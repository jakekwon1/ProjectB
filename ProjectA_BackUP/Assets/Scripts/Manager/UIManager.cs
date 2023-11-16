using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public UICharactorInfo uiCharactorInfoSrc;   // 인스턴스 생성에 사용할 비활성화된 UI 게임 오브젝트의 컴포넌트
    public List<UICharactorInfo> uiCharInfoList { get; set; }

    private void Awake()
    {
        instance = this;
        uiCharInfoList = new List<UICharactorInfo>();
    }

    void Start()
    {

    }

    public UICharactorInfo CreateCharactorInfoUI(string name, GameObject owner)
    {
        GameObject createdInfo = null;
        UICharactorInfo charInfo = null;
        // UI 캐릭터 정보 리스트에서 검색
        for (int i = 0; i < uiCharInfoList.Count; i++)
        {
            // 재사용 가능한 게임오브젝트 존재
            if (uiCharInfoList[i].gameObject.activeSelf == false)
            {
                createdInfo = uiCharInfoList[i].gameObject;
                charInfo = createdInfo.GetComponent<UICharactorInfo>();
                break;
            }
        }
        if (createdInfo == null)
        {
            createdInfo = GameObject.Instantiate<GameObject>(uiCharactorInfoSrc.gameObject); // 생성
            charInfo = createdInfo.GetComponent<UICharactorInfo>();
            uiCharInfoList.Add(charInfo);
        }
        //charInfo.name.text = name;
        charInfo.owner = owner;
        createdInfo.name = name + "infoUI";
        createdInfo.transform.SetParent(uiCharactorInfoSrc.transform.parent);
        createdInfo.SetActive(true);


        return charInfo;
    }

    void Update()
    {

    }
}
