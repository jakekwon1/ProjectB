using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//반드시 구현해야되는 함수를 선언한 자료형
public interface IAction
{
    public void Test1();

    public void Test2();

    //void Execute();
}

public class TestImageStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        
    }

    public void Test1()
    {
        
    }
    public void Test2()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("PointerDown = " + eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("PointerUp = " + eventData.position);
    }
    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag = " + eventData.position);

    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag = " + eventData.position);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("EndDrag = " + eventData.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
