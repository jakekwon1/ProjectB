using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich_Attack : MonoBehaviour
{
    public byte damage;
    private SphereCollider sphereCollider { get; set; }
    Vector3 dir;
    float time;

    void Start()
    {
        damage = 50;
        sphereCollider = GetComponent<SphereCollider>();
        dir = Village.instance.player.transform.GetChild(3).position - transform.position;
    }

    private void OnEnable()
    {
        dir = Village.instance.player.transform.GetChild(3).position - transform.position;
    }

    //private void OnDisable()
    //{
    //    dir = Vector3.zero;
    //}

    public void BulletMove()
    {
        float bulletSpeed = Time.deltaTime * 4.0f;
        transform.Translate(dir.normalized * bulletSpeed);
        time += Time.deltaTime;
        if (time >= 5.0f || Village.instance.player.capsuleCollider.bounds.Intersects(sphereCollider.bounds))
        {
            transform.gameObject.SetActive(false);
            this.enabled = false;
            time -= 5.0f;
        }
    }
    void Update()
    {
        BulletMove();
    }
}
