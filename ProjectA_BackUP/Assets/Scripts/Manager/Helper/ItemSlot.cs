using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public string name
    {
        get
        {
            return icon.sprite.name;
        }
    }
    Rect rc; // UI 사각형
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rc.x = rectTransform.position.x - rectTransform.rect.width * 0.5f;
        rc.y = rectTransform.position.y - rectTransform.rect.height * 0.5f; // 2개의 값이 좌상단 꼭지점
        rc.width = rectTransform.rect.width;
        rc.height = rectTransform.rect.height;                              // 2개의 값이 우하단 꼭지점
    }

    public bool PtInRect(Vector2 eventpos)
    {
        if (eventpos.x >= rc.x && eventpos.x <= rc.x + rc.width && eventpos.y >= rc.y && eventpos.y <= rc.y + rc.height)
            return true;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        rc.x = rectTransform.position.x - rectTransform.rect.width * 0.5f;
        rc.y = rectTransform.position.y - rectTransform.rect.height * 0.5f; // 2개의 값이 좌상단 꼭지점
        rc.width = rectTransform.rect.width;
        rc.height = rectTransform.rect.height;                              // 2개의 값이 우하단 꼭지점     
    }
}
