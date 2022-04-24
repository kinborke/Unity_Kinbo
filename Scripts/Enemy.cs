using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    public float enemySpeed = 25;
    public float sagsolhiz = 40;
    System.Random ras;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        ras = new System.Random();


    }

    // trigira giriyo random sag sol alaný olustur 0 if zeroysa biyere one ise baska yere random gitcek saga sola da move towardsla götürcez 
    // eger dogruysa konumu 0 olcak move towardsa 0 yazcaz sonra trigira girdidiginde ayný iþlem yine olcak 

    void Update()
    {
        enemyRb.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime, Space.World);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            int z = ras.Next(0, 2);
            if (z == 1)      //(other.gameObject.GetComponent<TrueFalse>().answer==true)
            {
                transform.DOMoveX(Mathf.Clamp(7, -9, 9), 1f);
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(7, -9, 9), transform.position.y, transform.position.z), Time.deltaTime * sagsolhiz);
            }
            else
            {
                transform.DOMoveX(Mathf.Clamp(-7, -9, 9), 1f);
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(-7, -9, 9), transform.position.y, transform.position.z), Time.deltaTime * sagsolhiz);
            }

        }
        if(other.gameObject.CompareTag("dogru"))
        {
            if (other.gameObject.GetComponent<TrueFalse>().answer == true)
            {
                transform.DOMoveX(Mathf.Clamp(0, -9, 9), 1f);
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(transform.position.x + 0, -9, 9), transform.position.y, transform.position.z), Time.deltaTime * sagsolhiz);
            }
        }
    }




}
