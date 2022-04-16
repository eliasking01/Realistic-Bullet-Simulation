using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
