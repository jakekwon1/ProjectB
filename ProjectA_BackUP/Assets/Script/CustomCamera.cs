using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    //public Transform character;
    // Start is called before the first frame update
    Vector3 tmp;
    float speed;
    bool ShopView;

    void Start()
    {
        transform.rotation = Quaternion.Euler(45,0,0);    //(45,0,0) ,y+15, z-15 // (22,0,0),y+7, z-20
        ShopView = false;
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
    }
}
