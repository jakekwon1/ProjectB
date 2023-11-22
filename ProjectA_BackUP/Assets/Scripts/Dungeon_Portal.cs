using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dungeon_Portal : MonoBehaviour
{
    private CapsuleCollider2D capsuleColleder2D;
    void Start()
    {
        capsuleColleder2D = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        if (Village.instance.player.capsuleCollider.bounds.Intersects(capsuleColleder2D.bounds))
        {
            LoadSceaneController.LoadScene("Monster");
        }
    }
}
