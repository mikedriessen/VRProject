using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public float bulletSpeed = 3;//1100;
    public GameObject bullet;

    AudioSource bulletAudio;

    List<GameObject> bulletList;

    private bool CanShoot;
    public int shots;

    public Text shootText;
    

    // Use this for initialization
    void Start()
    {
        shots = 30;
        CanShoot = true;
        
        bulletList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }

        bulletAudio = GetComponent<AudioSource>();

    }

    void Fire()
    {

        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed*1000);
                break;
            }
        }
        //Shoot
        /*GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 0.5f);*/

        //Play Audio
        bulletAudio.Play();

    }


    // Update is called once per frame
    void Update()
    {
        shootText.text = "Shots:" + shots;

        if (CanShoot && Input.GetMouseButtonDown(0))
        {
            Fire();
            shots--;
        }
        if (shots == 0)
        {
            CanShoot = false;
            shootText.text = "Reload!";
        }
        if (shots == 0 && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadTime());
        }
    }
    void Reloading()
    {
        CanShoot = true;
        shots = 30;
    }
    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(3);
        Reloading();
       
    }
}
