using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHelper
{
    public static Vector3 GetPositionOnTerrain(Vector3 origin)
    {
        // Ray를 이용하여 지형의 높이를 구하여 배치
        // 특정위치에서 아래로 향하는 광선을 캐스팅
        RaycastHit hitInfo;
        Vector3 rayOrigin = origin + new Vector3(0, 100, 0);
        Physics.Raycast(rayOrigin, Vector3.down, out hitInfo);
        return hitInfo.point;
    }
}
