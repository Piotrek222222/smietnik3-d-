using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject cannon;
    public GameObject projectile;
    public float force = 100f;
    bool canShoot = true;
    float shooted;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            GameObject bullet = Instantiate(projectile , spawnPos.transform.position,  cannon.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(cannon.transform.forward * force, ForceMode.Impulse);
            canShoot = false;
            shooted = Time.time;
        }
        if (Time.time > shooted + 3)
            canShoot = true;
    }

    void MoveCannon()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

    }

}
