﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 2.0f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
            Destroy(collision.gameObject);

            gameObject.SetActive(false);
        }
    }


}
