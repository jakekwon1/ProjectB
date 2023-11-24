using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    float speed;
    float rotate;
    float h, v;
    Vector3 dir;
    public bool isMoving { get; set; }
    protected JoyStick2 joystick;
    public NavMeshAgent navi { get; set; }
    public UICharactorInfo playerUI { get; set; }
    private Transform findHpTr;
    public float hp { get; set; }
    public CapsuleCollider capsuleCollider { get; set; }
    //public NavMeshAgent navi { get; set; }
    public Transform hpTr
    {
        get
        {
            if (findHpTr == null)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    findHpTr = transform.GetChild(i);
                    if (findHpTr.name.Equals("Hp"))
                    {
                        return findHpTr;
                    }
                }
            }
            return null;
        }
    }
    private void Awake()
    {
        hp = 100;
    }
    void Start()
    {

        if (SceneManager.GetActiveScene().name.Equals("Village"))
            speed = 10f;
        else speed = 10f;
        rotate = 200f;
        capsuleCollider = GetComponent<CapsuleCollider>();
        if (joystick == null)
            joystick = GetComponent<JoyStick2>();
        //navi.destination = transform.position;
    }
    void Move()
    {

        Vector3 tmp = transform.position;
        tmp.x += JoyStick2.Instance.dir.normalized.x * Time.deltaTime * speed;
        tmp.z += JoyStick2.Instance.dir.normalized.y * Time.deltaTime * speed;
        transform.position = tmp;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    // Update is called once per frame
        void Update()
    {
        if(isMoving)
            Move();
    }
    public void UpdateUI()
    {
        Vector2 screepPos = Camera.main.WorldToScreenPoint(findHpTr.position);
        playerUI.transform.position = screepPos;
    }
    void FixedUpdate()
    {
        h = JoyStick2.Instance.dir.normalized.x;
        v = JoyStick2.Instance.dir.normalized.y;

        dir = new Vector3(h, 0, v);
        if (!(h == 0 && v == 0))
        {
            // 회전하는 부분. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotate);
        }
    }
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name != "Village")
        {
            UpdateUI();
        }
    }
}
