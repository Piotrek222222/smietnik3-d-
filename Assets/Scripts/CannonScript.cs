using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cannon;
    public GameObject projectile;
    public float force = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void Shoot()
    {
        if (Input.GetKeyDown("Jump"))
        {
            GameObject bullet = Instantiate(projectile , cannon.transform.position + new Vector3(0 , 0 , 0),  cannon.transform.rotation);
            rb.AddExplosionForce(force , bullet.transform.position - Vector3.back , 2);
            
                
            
        }

    }
}
