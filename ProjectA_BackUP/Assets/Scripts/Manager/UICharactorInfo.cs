using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICharactorInfo : MonoBehaviour
{
    //public TextMeshProUGUI name;
    public Image hp;
    public GameObject owner;
    byte playerHp;

    void Start()
    {
        if (owner.CompareTag("Player"))
        {
            playerHp = owner.GetComponent<Character>().hp;
        }
    }


    void Update()
    {
        if(owner.CompareTag("Player"))
            hp.fillAmount = Mathf.Lerp(0, 100, playerHp);
    }
}
