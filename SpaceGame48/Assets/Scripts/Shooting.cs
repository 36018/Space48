using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 3f;
    private float cooldownCounter = 0f;
    [SerializeField] private GameObject laserPrefab;
    
    void Update()
    {
        Shoot();
    }

    public float CoolDownTime
    {
        get { return cooldownTime; }
        set { cooldownTime = value; }
    }

    void Shoot()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }


    }
}
