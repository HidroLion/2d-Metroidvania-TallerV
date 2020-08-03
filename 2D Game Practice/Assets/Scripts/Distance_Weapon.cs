using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Weapon : MonoBehaviour
{
    public Transform fireOrigin;
    public GameObject kaiaBulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(kaiaBulletPrefab, fireOrigin.position, fireOrigin.rotation);
    }
}
