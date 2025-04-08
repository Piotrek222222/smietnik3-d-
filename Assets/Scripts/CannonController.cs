using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public List<GameObject> cannonList;
    public void SetCannonBool(int cannonNum , bool trueorfalse)
    {
        GameObject cannon = cannonList[cannonNum];
        bool icu = cannon.GetComponent<CannonScript>().IsCannonUsed;
        icu = trueorfalse;
    }
}
