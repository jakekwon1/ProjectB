using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionSetting : MonoBehaviour
{
    InventoryUIManager inventoryUIManager;
    public Image option;
    public Image setting;
    public Image ExitText;
    public Button CloseButton1;
    public Button CloseButton2;
    public GameObject Shop;
    public GameObject JoyStick;
    public GameObject UI;

    void Start()
    {
        inventoryUIManager = GetComponent<InventoryUIManager>();
    }

    public void CloseOption()
    {
        if(setting.gameObject.activeSelf)
        {
            setting.gameObject.SetActive(false);
        }
        else if(option.gameObject.activeSelf)
        {
            option.gameObject.SetActive(false);
            CloseButton1.gameObject.SetActive(false);
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
        if (inventoryUIManager.inventory.gameObject.activeSelf == true)
            inventoryUIManager.inventory.gameObject.SetActive(false);

        CloseButton1.gameObject.SetActive(true);
        option.gameObject.SetActive(true);
    }

    public void OpenSetting()
    {
        setting.gameObject.SetActive(true);
    }

    public void ExitPopup()
    {
        if(ExitText.gameObject.activeSelf)
        {
            ExitText.gameObject.SetActive(false);
            CloseButton2.gameObject.SetActive(false);
        }
        else if (!ExitText.gameObject.activeSelf)
        {
            ExitText.gameObject.SetActive(true);
            CloseButton2.gameObject.SetActive(true);
        }


    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
