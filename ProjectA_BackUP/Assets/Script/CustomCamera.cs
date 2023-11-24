using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CustomCamera : MonoBehaviour
{
    //public Transform character;
    // Start is called before the first frame update
    Vector3 tmp;
    float speed;
    bool ShopView;
    // 추가내용-------------------------------------------------------------------------------
    Vector3 bossY;
    //

    void Start()
    {
        transform.rotation = Quaternion.Euler(45,0,0);    //(45,0,0) ,y+15, z-15 // (22,0,0),y+7, z-20
        ShopView = false;
        bossY = new Vector3(0f, -7f, 20f);
    }

    public void View(bool view)
    {
        ShopView = view;
        if (view)
        {
            transform.rotation = Quaternion.Euler(0, -10, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(45, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShopView)
        {
            tmp = transform.localPosition;
            Vector3 ptmp = Village.instance.player.transform.localPosition;
            tmp.x = ptmp.x;
            tmp.y = ptmp.y + 15;
            tmp.z = ptmp.z - 15;
            transform.localPosition = tmp;
        }
        else if (ShopView)
        {
            tmp.x = -11.2f;
            tmp.y = 2.7f;
            tmp.z = 14f;
            speed = 15f;
            transform.position = Vector3.MoveTowards(transform.position, tmp, Time.deltaTime*speed);
        }
        // 추가내용------------------------------------------------------------------------------
        if (SceneManager.GetActiveScene().name == "BossMonster")
        {
            if (BossMonster.instance.ani.GetBool("aniBool") != true)
            {
                transform.position = Village.instance.bossMonster.transform.position - bossY;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Village.instance.player.playerUI.gameObject.SetActive(false);
            }
            else if (BossMonster.instance.ani.GetBool("aniBool") == true)
            {
                tmp = transform.localPosition;
                Vector3 ptmp = Village.instance.player.transform.localPosition;
                tmp.x = ptmp.x;
                tmp.y = ptmp.y + 15;
                tmp.z = ptmp.z - 15;
                transform.localPosition = tmp;
                transform.rotation = Quaternion.Euler(45, 0, 0);
                Village.instance.player.playerUI.gameObject.SetActive(true);
            }
        }
        //-----------------------------------------------------------------
    }
}
