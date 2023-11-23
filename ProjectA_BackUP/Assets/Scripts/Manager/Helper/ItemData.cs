using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public int index { get; set; }
    public string type { get; set; }
    public int data { get; set; }

    public void changeIndex(ItemData xindex)
    {
        index = xindex.index;
    }
    public void changeType(ItemData xtype)
    {
        type = xtype.type;
    }
    public void changeData(ItemData xdata)
    {
        data = xdata.data;
    }
}
