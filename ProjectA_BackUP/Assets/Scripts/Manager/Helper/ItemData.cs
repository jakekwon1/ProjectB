using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public int index;
    public string type;
    public int data;
    
    public int getIndex
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }
    public string getType
    {
        get 
        {
            return type;
        }
        set 
        { 
            type = value; 
        } 
    }
    public int getData
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }

}
