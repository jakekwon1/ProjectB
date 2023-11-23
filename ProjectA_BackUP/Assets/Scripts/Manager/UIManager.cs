using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public UICharactorInfo uiCharactorInfoSrc;   // 인스턴스 생성에 사용할 비활성화된 UI 게임 오브젝트의 컴포넌트
    public List<UICharactorInfo> uiCharInfoList { get; set; }
    byte playerHp;


    public GameObject inventory;
    public GameObject itemSlot;
    public Image itemButton;
    public GameObject skillSlot;
    public Image skillButton;
    public Image option;
    public Image setting;
    public Image ExitText;
    public Button closeButton1;
    public Button closeButton2;
    public GameObject Shop;
    public GameObject JoyStick;
    public GameObject UI;


    private void Awake()
    {
        instance = this;
        uiCharInfoList = new List<UICharactorInfo>();
    }

    void Start()
    {
        //playerHp = GetComponent<Character>().hp;
        //hp.fillAmount = Mathf.Lerp(0, 100, playerHp);
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

    public void OpenInventory()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
            closeButton1.gameObject.SetActive(false);
        }
        else if (!inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(true);
            closeButton1.gameObject.SetActive(true);
        }
    }

    public void CloseButton()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
            closeButton1.gameObject.SetActive(false);
        }
    }

    public void ItemSlot()
    {
        skillSlot.SetActive(false);
        skillButton.color = Color.gray;
        itemSlot.SetActive(true);
        itemButton.color = Color.white;
    }

    public void SkillSlot()
    {
        itemSlot.SetActive(false);
        itemButton.color = Color.gray;
        skillSlot.SetActive(true);
        skillButton.color = Color.white;
    }

    public void CloseOption()
    {
        if (setting.gameObject.activeSelf)
        {
            setting.gameObject.SetActive(false);
        }
        else if (option.gameObject.activeSelf)
        {
            option.gameObject.SetActive(false);
            closeButton1.gameObject.SetActive(false);
        }
    }

    public void OpenShop()
    {
        UI.SetActive(false);
        JoyStick.SetActive(false);
        Shop.SetActive(true);
        Camera.main.SendMessage("View", true);
    }

    public void CloseShop()
    {
        UI.SetActive(true);
        JoyStick.SetActive(true);
        Shop.SetActive(false);
        Camera.main.SendMessage("View", false);
    }

    public void OpenOption()
    {
        if (inventory.gameObject.activeSelf == true)
            inventory.gameObject.SetActive(false);

        closeButton1.gameObject.SetActive(true);
        option.gameObject.SetActive(true);
    }

    public void OpenSetting()
    {
        setting.gameObject.SetActive(true);
    }

    public void ExitPopup()
    {
        if (ExitText.gameObject.activeSelf)
        {
            ExitText.gameObject.SetActive(false);
            closeButton2.gameObject.SetActive(false);
        }
        else if (!ExitText.gameObject.activeSelf)
        {
            ExitText.gameObject.SetActive(true);
            closeButton2.gameObject.SetActive(true);
        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
