using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCannon : MonoBehaviour
{
    public int cannonNum;
    CannonController cc;
    void Start()
    {
        cc = GetComponent<CannonController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<GameObject>().SetActive(false);
            cc.SetCannonActive(cannonNum);
            

        }
    }
    void Update()
    {
        
    }
}
