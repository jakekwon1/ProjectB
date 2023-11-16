using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestCharater : MonoBehaviour
{
    float speed;
    float rotate;
    float h, v;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        rotate = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = transform.position;
        tmp.x += JoyStick2.Instance.dir.normalized.x * Time.deltaTime * speed;
        tmp.z += JoyStick2.Instance.dir.normalized.y * Time.deltaTime * speed;
        transform.position = tmp;
    }
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v);
        if (!(h == 0 && v == 0))
        {
            // 회전하는 부분. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotate);
        }
    }
}
