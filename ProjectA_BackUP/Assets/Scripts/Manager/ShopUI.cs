using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Character player;
    public Shop shop {  get; set; }
    public Image UI;
    public GameObject Tree;

    // Start is called before the first frame update
    void Start()
    {
        player = Village.instance.player;
        Tree.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(shop.transform.position, player.transform.position);
        if(distance <= 5f)
            UI.gameObject.SetActive(true);
        else if(distance > 5f)
            UI.gameObject.SetActive(false);
    }
}
