using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    //public GameObject button;
    private void Awake()
    {
        ResourceManager.instance.LoadCharacter();
        ResourceManager.instance.LoadMonster();
        ResourceManager.instance.LoadLichMonster();
        ResourceManager.instance.LoadThunderBolt();
        ResourceManager.instance.LoadIcon();
    }
    void Start()
    {

    }

    public void Onclick()
    {
        SceneManager.LoadScene("Monster2");
        //SceneManager.LoadScene("Village");
    }

    void Update()
    {
        
    }   
}
