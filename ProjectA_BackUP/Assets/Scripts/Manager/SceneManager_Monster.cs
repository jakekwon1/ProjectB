using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Monster : MonoBehaviour
{
    void Start()
    {
    }

    
    void Update()
    {
        //time -= Time.deltaTime;
        //if( time <= 0.0f)
        //{
        //    SceneManager.LoadScene("Map_Making_scene");
        //}
        if(Village.instance.monsterCount >= Village.instance.maxCount)
        {
            SceneManager.LoadScene("Test_Intro");
        }
    }
}
