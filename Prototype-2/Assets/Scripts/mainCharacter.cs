using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    public GameObject clone;

    //trial 
    public GameObject destinySphereObject,destinySphereObject2,destinySphereObject3;
    public Transform destinySphere,destinySphere2,destinySphere3,mainCharacterPos;
    public float randxLow=-1f, randxHigh=1f,randzLow=0.1f,randzHigh=1f;
    private float xVar, zVar;
    


    void Start()
    {
        
        destinySphere = destinySphereObject.transform;
        destinySphere2 = destinySphereObject2.transform;
        destinySphere3 = destinySphere3.transform;
        xVar = Random.Range(randxLow, randxHigh);
        zVar = Random.Range(randzLow, randzHigh);

    }

    void FixedUpdate()
    {
        //mainCharacterPos.position = Vector3.Lerp(mainCharacterPos.position, destinySphere.position, 0.04f);
        transform.position = Vector3.MoveTowards(transform.position, destinySphere.transform.position, 0.03f);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="+2")
        {
            
            Instantiate(clone,new Vector3(transform.position.x-xVar,transform.position.y,transform.position.z-zVar) , transform.rotation);
            Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);
            destinySphereObject = GameObject.Find("destiny");
            destinySphere = destinySphereObject.transform;
        }
        if(other.gameObject.tag=="+10")
        {
            destinySphereObject2 = GameObject.Find("destiny2");
            destinySphere = destinySphereObject2.transform;
            for (int i = 0; i <= 9; i++)
            {
                xVar = Random.Range(randxLow, randxHigh);
                zVar = Random.Range(randzLow, randzHigh);
                Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);
              
               
            }

        }
        if(other.gameObject.tag=="+15")
        {
            destinySphereObject3 = GameObject.Find("Boss");
            destinySphere = destinySphereObject3.transform;
            for (int i = 0; i <= 14; i++)
            {
                xVar = Random.Range(randxLow, randxHigh);
                zVar = Random.Range(randzLow, randzHigh);
                Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);

            }
        }
        if(other.gameObject.tag=="boss")
        {
            gameObject.SetActive(false);
        }
    }
}
