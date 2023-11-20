using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventory;   
    public GameObject itemSlot;
    public Image itemButton;
    public GameObject skillSlot;
    public Image skillButton;
    public Button closeButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenInventory()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
        }
        else if ( !inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(true);
        }
    }
    public void CloseButton()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
