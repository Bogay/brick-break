using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    public GameObject blockObject;
    public Transform blockGroup;
    public StageData[] datas;

    public bool generate(int stageLevel)
    {
        foreach(StageData data in datas)
        {
            if(data.level == stageLevel)
            {
                foreach(Vector3 pos in data.positions)
                {
                    Instantiate(blockObject, pos, Quaternion.identity, blockGroup);
                    Debug.Log("Spawn at: " + pos);
                }
                return true;
            }
        }
        Debug.Log(System.String.Format("Stage [{0}] not found!", stageLevel));
        return false;
    }
}
