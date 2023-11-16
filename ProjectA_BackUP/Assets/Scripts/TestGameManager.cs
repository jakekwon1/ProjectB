using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public delegate void Do();

public class TestGameManager : MonoBehaviour
{
    public Button SummonBtn;
    public Do doSomething { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        //SummonBtn.onClick.AddListener(SummonBtnClick);
        //SummonBtn.onClick.AddListener(DisplayData);
        doSomething = DisplayData;
        Test2(Test);
        Test2(DisplayData);
        //do SummonBtnClick(); while (SummonBtn != null);
    }

    public void SummonBtnClick()
    {
        Debug.Log("Button Pressed");
        if (doSomething != null)
            doSomething();
    }
    public void DisplayData() // 자동 호출
    {
        Debug.Log("DisplayData");
    }

    public void Test()
    {
        Debug.Log("Test");
    }
    public void Test2(Do _do)
    {
        if(_do != null)
            _do();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F1))
        {
            doSomething = DisplayData;
        }
        if (Input.GetKey(KeyCode.F2))
        {
            doSomething = Test;
        }
    }
}
