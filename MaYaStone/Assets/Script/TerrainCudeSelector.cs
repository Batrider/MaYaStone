using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCudeSelector : MonoBehaviour
{

    public TerrainType type;

    public void Awake()
    {
        switch (type)
        {
            case TerrainType.None:
                break;
            case TerrainType.Brick1:
                GameObject brick1 = Instantiate(Resources.Load("Brick1")) as GameObject;
                brick1.transform.parent = transform;
                brick1.transform.localPosition = Vector3.zero;
                brick1.transform.localScale = Vector3.one;
                brick1.transform.localEulerAngles = Vector3.zero;
                break;
            case TerrainType.Brick2:
                GameObject brick2 = Instantiate(Resources.Load("Brick2")) as GameObject;
                brick2.transform.parent = transform;
                brick2.transform.localPosition = Vector3.zero;
                brick2.transform.localScale = Vector3.one;
                brick2.transform.localEulerAngles = Vector3.zero;

                break;
        }

    }
}
