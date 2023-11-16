using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Charactor_Test : MonoBehaviour
{
    public UICharactorInfo playerUI { get; set; }
    private Transform findHpTr;
    public NavMeshAgent navi { get; set; }

    public Transform hpTr
    {
        get
        {
            if (findHpTr == null)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform findTr = transform.GetChild(i);
                    if (findTr.name.Equals("Hp"))
                    {
                        findHpTr = findTr;
                        return findTr;
                    }

                }
            }
            return findHpTr;
        }
    }
    private float moveSpeed;
    Vector3 endPos;

    void Start()
    {
        //moveSpeed = 3.0f;
        navi.destination = transform.position;
    }

    public void UpdateUI()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(findHpTr.position);
        playerUI.transform.position = screenPos;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    navi.destination = hitInfo.point;
                }
                if (hitInfo.collider.CompareTag("Terrain"))
                {
                    navi.destination = hitInfo.point;
                }
            }
        }
        //Vector3 temp = transform.localPosition;
        //temp.x += endPos.x * Time.deltaTime * moveSpeed;
        //temp.z += endPos.z * Time.deltaTime * moveSpeed;
        //transform.localPosition = temp;
        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, Time.deltaTime * moveSpeed);
        //transform.LookAt(transform.forward);
    }
    private void LateUpdate()
    {
        //UpdateUI();
    }
}
