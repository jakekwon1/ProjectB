using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.ComponentModel;
using Unity.Services.Analytics.Internal;
using Unity.VisualScripting;

public class JoyStick2: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static JoyStick2 Instance;
    public Image innerStick;
    public RectTransform rectTransform;
    public Vector3 dir {  get; set; }
    Vector3 startPos;
    float radius;
    //public bool isMoving {  get; set; }

    void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        //rectTransform = GetComponent<RectTransform>();  // 성능 저하가 일이나 잘 사용 하지않음
        startPos = innerStick.transform.position;
        radius = rectTransform.rect.width * 0.5f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //innerStick.transform.position = eventData.position;
        Village.instance.player.isMoving = true;
        float distance = Vector3.Distance(startPos, eventData.position);
        dir = (Vector3)eventData.position - startPos;
        if (distance > radius)
            innerStick.transform.position = startPos + dir.normalized * radius;
        else
            innerStick.transform.position = startPos + dir.normalized * distance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Village.instance.player.isMoving = true;
        float distance = Vector3.Distance(startPos, eventData.position);
            dir = (Vector3)eventData.position - startPos;
        if (distance > radius)
            innerStick.transform.position = startPos + dir.normalized * radius;
        else
            innerStick.transform.position = startPos + dir.normalized * distance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        innerStick.transform.position = startPos;
        dir = Vector3.zero;
        Village.instance.player.isMoving = false;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
