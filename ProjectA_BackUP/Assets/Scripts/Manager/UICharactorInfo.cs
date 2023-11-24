using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICharactorInfo : MonoBehaviour
{
    //public TextMeshProUGUI name;
    public Image hp;
    public GameObject owner;
    float playerHp
    {
        get
        {
            return owner.GetComponent<Character>().hp;
        }
        set
        {
            owner.GetComponent<Character>().hp = value;
        }
    }

    void Start()
    {
        hp.type = Image.Type.Filled;
        hp.fillMethod = Image.FillMethod.Horizontal;
        hp.fillOrigin = (int)Image.OriginHorizontal.Left;
        HpColor();
    }

    public void SetHp(float damage)
    {
        playerHp -= damage;
        HpColor();
    }
    public void HpColor()
    {
        float green = (255f / 100f) * playerHp;
        hp.color = new Color(255-green, green, 0, 1f);
    }

    void Update()
    {
        if (playerHp <= 0)
        {
            playerHp = 0;
            Debug.Log("Player Dead");
        }
        hp.fillAmount = playerHp / 100;
        if (playerHp == 0)
            SceneManager.LoadScene("Village");
    }
}
