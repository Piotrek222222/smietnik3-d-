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
    bool usingCannon = false;
    void Start()
    {
        cc = GetComponent<CannonController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && usingCannon)
        {
            usingCannon = false;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SetActive(true);
            playerCamera.gameObject.SetActive(true);
            cannonCamera.gameObject.SetActive(false);
            cc.SetCannonBool(cannonNum , false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            usingCannon = true;
            other.gameObject.SetActive(false);
            cc.SetCannonBool(cannonNum , true);
            cannonCamera.gameObject.SetActive(true);
            playerCamera = other.gameObject.transform.Find("MainCamera").gameObject;
            playerCamera.gameObject.SetActive(false);
            

        }
    }
}
