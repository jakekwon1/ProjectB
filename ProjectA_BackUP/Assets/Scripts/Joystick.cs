using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있게 해주는 기능

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform stick;
    private RectTransform rectTransform;
    //
    [SerializeField, Range(10, 150)]
    private float stickrange;
    //
    private Vector2 inputDir;
    private bool isInput;
    //
    [SerializeField]
    private Character_Moving controller;
    //
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // 외부에서 받아옴
    }
    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        ControllerJoystick(eventData);
        isInput = true;
    }
    // 드래그 상태로 멈추면 입력이 안됨
    public void OnDrag(PointerEventData eventData)
    {
        ControllerJoystick(eventData);
        //
        var inputPos = eventData.position - rectTransform.anchoredPosition; // 이동 거리
        var inputVec = inputPos.magnitude < stickrange ? inputPos : inputPos.normalized * stickrange;

        Debug.Log("OnDrag: " + inputDir);
    }
    //
    public void OnEndDrag(PointerEventData eventData)
    {
        stick.anchoredPosition = Vector3.zero;
        isInput = false;
        //controller.Move(Vector2.zero);
    }
    //
    private void ControllerJoystick(PointerEventData eventData) // stick이 일정 위치 넘어가면 이전 위치에 고정
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVec = inputPos.magnitude < stickrange ? inputPos : inputPos.normalized * stickrange;
        stick.anchoredPosition = inputVec;
        inputDir = inputVec / stickrange;
    }
    //
    private void InputController()
    {
        //controller.Move(inputDir);
    }

    void Update()
    {
        if (isInput)
        {
            InputController();
        }    
    }
}

