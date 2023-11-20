using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    void Start()
    {
        //if()

        //ExportMapData("MapData2");
        //LoadMapData("MapData2");
    }

    public void ExportMapData(string mapName)
    {
        GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        string dir = Application.dataPath;
        string fileName = mapName + ".csv";
        string column = "index,type,name,positonX,positonY,positonZ,rotationX,rotationY,rotationZ,scaleX,scaleY,scaleZ";
        // using 명령어를 사용시 변수가 사용후 초기화됨(삭제), 즉 1회성 명령어
        using (StreamWriter writer = new StreamWriter(dir + "/" + fileName)) // 없으면 생성함
        {
            writer.WriteLine(column);
            //Terrain
            int curIndex = 0;
            string line = string.Empty;
            for (int i = 0; i < terrains.Length; i++)
            {
                line += curIndex.ToString() + ",";
                line += "Terrain" + ",";
                line += terrains[i].name + ",";
                line += terrains[i].transform.position.x + ",";
                line += terrains[i].transform.position.y + ",";
                line += terrains[i].transform.position.z + ",";
                line += terrains[i].transform.localEulerAngles.x + ",";
                line += terrains[i].transform.localEulerAngles.y + ",";
                line += terrains[i].transform.localEulerAngles.z + ",";
                line += terrains[i].transform.localScale.x + ",";
                line += terrains[i].transform.localScale.y + ",";
                line += terrains[i].transform.localScale.z;
                writer.WriteLine(line);
                curIndex++;
            }
            //Building
            for (int i = 0; i < buildings.Length; i++)
            {
                line = string.Empty;
                line += curIndex.ToString() + ",";
                line += "Building" + ",";
                line += buildings[i].name + ",";
                line += buildings[i].transform.position.x + ",";
                line += buildings[i].transform.position.y + ",";
                line += buildings[i].transform.position.z + ",";
                line += buildings[i].transform.localEulerAngles.x + ",";
                line += buildings[i].transform.localEulerAngles.y + ",";
                line += buildings[i].transform.localEulerAngles.z + ",";
                line += buildings[i].transform.localScale.x + ",";
                line += buildings[i].transform.localScale.y + ",";
                line += buildings[i].transform.localScale.z;
                writer.WriteLine(line);
                curIndex++;
            }
        }
    }

    public void LoadMapData(string mapName)
    {
        string dir = Application.dataPath;
        string fileName = mapName + ".csv";
        string line;
        using (StreamReader reader = new StreamReader(dir + "/" + fileName))
        {
            line = reader.ReadLine();
            //line = reader.ReadToEnd
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                string[] datas = line.Split(",");
                int index = int.Parse(datas[0]);
                string type = datas[1];
                string name = datas[2];
                Vector3 pos = new Vector3(float.Parse(datas[3]), float.Parse(datas[4]), float.Parse(datas[5]));
                Vector3 rot = new Vector3(float.Parse(datas[6]), float.Parse(datas[7]), float.Parse(datas[8]));
                Vector3 sca = new Vector3(float.Parse(datas[9]), float.Parse(datas[10]), float.Parse(datas[11]));
                GameObject rc = null;
                GameObject createdObj = null;

                switch (type)
                {
                    case "Terrain":
                        rc = Resources.Load<GameObject>("Terrain/" + name);
                        createdObj = GameObject.Instantiate<GameObject>(rc);
                        createdObj.transform.position = pos;
                        createdObj.transform.localEulerAngles = rot;
                        createdObj.transform.localScale = sca;

                        break;
                    case "Building":
                        rc = Resources.Load<GameObject>("Building/" + name);
                        createdObj = GameObject.Instantiate<GameObject>(rc);
                        createdObj.transform.position = pos;
                        createdObj.transform.localEulerAngles = rot;
                        createdObj.transform.localScale = sca;

                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
