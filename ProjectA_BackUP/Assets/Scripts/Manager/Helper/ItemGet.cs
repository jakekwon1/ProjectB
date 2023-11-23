using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void GetItem()
    {
        string Item = RandomItem();
        int range = Random.Range(1, 20);
        string line = string.Empty;
        int index = -1;
        using (StreamReader reader = new StreamReader(Application.dataPath + "/Resources/ITEM/ItemManager.csv"))
        {
            string read;
            while ((read = reader.ReadLine()) != null)  // 아무것도 없어도 읽어옴
            {
                if (string.IsNullOrEmpty(read))         // 아무것도 없으면 종료
                {
                    line += "index,type,atk/def//";
                    index++;
                    break;
                }
                line += read + "//";
                index++;
            }
        }
        string[] split;
        using (StreamWriter writer = new StreamWriter(Application.dataPath + "/Resources/ITEM/ItemManager.csv")) // 없으면 생성함
        {
            split = line.Split("//");
            for(int i = 0; i < split.Length-1; i++)
                writer.WriteLine(split[i]);
            writer.WriteLine(index + "," + Item + "," + range);
        }
    }

    public static string RandomItem()
    {
        int index = Random.Range(0, 3);
        string item = null;
        switch (index)
        {
            case 0:
                item = "Sword";
                break;
            case 1:
                item = "Helmet";
                break;
            case 2:
                item = "TopArmor";
                break;
            case 3:
                item = "BottomArmor";
                break;
        }
        return item;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
