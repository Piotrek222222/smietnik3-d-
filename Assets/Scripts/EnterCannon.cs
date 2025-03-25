using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnterCannon : MonoBehaviour
{
    public int cannonNum;
    public GameObject cannonCamera;
    GameObject playerCamera;
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
            cannonCamera.gameObject.SetActive(true);
            playerCamera = other.gameObject.transform.Find("MainCamera").gameObject;
            playerCamera.gameObject.SetActive(false);
            

        }
    }
}
