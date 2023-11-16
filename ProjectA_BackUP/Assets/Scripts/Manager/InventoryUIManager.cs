using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventory;   
    public GameObject itemSlot;
    public GameObject skillSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenInventory()
    {
        if (inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(false);
        }
        else if ( !inventory.gameObject.activeSelf)
        {
            inventory.gameObject.SetActive(true);
        }
    }

    public void ItemSlot()
    {
        skillSlot.SetActive(false);
        itemSlot.SetActive(true);
    }

    public void SkillSlot()
    {
        itemSlot.SetActive(false);
        skillSlot.SetActive(true);
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
