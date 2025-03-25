using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public List<GameObject> cannonList;

    public void SetCannonActive(int cannonNum)
    {
        GameObject cannon = cannonList[cannonNum];
        bool icu = cannon.GetComponent<CannonScript>().IsCannonUsed;
        icu = true;
    }
}
