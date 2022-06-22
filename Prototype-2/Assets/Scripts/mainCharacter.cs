using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacter : MonoBehaviour
{
    public GameObject clone;

    //trial 
    public GameObject destinySphereObject,destinySphereObject2,destinySphereObject3,destinySphereObject4;
    public Transform destinySphere,destinySphere2,destinySphere3,destinySphere4,mainCharacterPos;
    public float randxLow=-1f, randxHigh=1f,randzLow=0.1f,randzHigh=1f;
    private float xVar, zVar;
    public  int touchCounter=0;
    public bool flag=true,destiny4Flag=false,destroyFlag=false;
    public int checkpoint = 0,numberOfClones=1;

    cloneScript cloneScript;
    public GameObject cloneObject;
    Camera myCamera;


    void Start()
    {
        cloneScript = cloneObject.GetComponent<cloneScript>();
        destroyFlag = false;
        numberOfClones = 1;
        myCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
        destinySphere4 = destinySphere4.transform;
        xVar = Random.Range(randxLow, randxHigh);
        zVar = Random.Range(randzLow, randzHigh);
        touchCounter = 0;
        destiny4Flag = false;
        
    }
    

    void LateUpdate()
    {
        if(Input.touchCount>0)
        {
            Touch finger = Input.GetTouch(0);

            RaycastHit touchedObject;
            if(Physics.Raycast(myCamera.ScreenPointToRay(finger.position),out touchedObject))
            {
                if (flag==true && Input.touchCount == 0)
                {
                    flag = false;
                }
                 else if (!flag && Input.touchCount > 0)
                {
                    if(touchCounter==0)
                    {
                        destinySphere = touchedObject.transform;
                        cloneScript = cloneObject.GetComponent<cloneScript>();
                        cloneScript.destiny1 = touchedObject.transform;
                    }
                    else if(touchCounter==1)
                    {
                        destinySphere2 = touchedObject.transform;
                        cloneScript = cloneObject.GetComponent<cloneScript>();
                        cloneScript.destiny2 = touchedObject.transform;
                    }
                    else if(touchCounter==2)
                    {
                        destinySphere3 = touchedObject.transform;
                        cloneScript = cloneObject.GetComponent<cloneScript>();
                        cloneScript.destiny3= touchedObject.transform;
                    }
                    touchCounter += 1;
                    flag = true;
                    

                }
                
                if(finger.phase==TouchPhase.Ended)
                {
                    flag = false;
                }


            }     
            
        }
        
        
        
        if (touchCounter == 3 && checkpoint==0)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinySphere.transform.position, 0.02f);
        }
        if(touchCounter==3 && checkpoint==1)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinySphere2.transform.position, 0.02f);
        }
        if(touchCounter==3 &&checkpoint==2)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinySphere3.transform.position, 0.02f);
        }
        if(destiny4Flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinySphere4.transform.position, 0.02f);

        }



        if (numberOfClones == 1&&destroyFlag)
        {

            gameObject.SetActive(false);

        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag=="+2")
        {
            destroyFlag = true;
            checkpoint++;
            Instantiate(clone,new Vector3(transform.position.x-xVar,transform.position.y,transform.position.z-zVar) , transform.rotation);
            Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);
            
            //destinySphere = destinySphereObject.transform;
            numberOfClones = numberOfClones + 2;
        }
        if(other.gameObject.tag=="+10")
        {
            destroyFlag = true;
            checkpoint++;
          
            //destinySphere = destinySphereObject2.transform;
            for (int i = 0; i <= 9; i++)
            {
                xVar = Random.Range(randxLow, randxHigh);
                zVar = Random.Range(randzLow, randzHigh);
                Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);
                
            }
            numberOfClones = numberOfClones + 10;
        }
        if(other.gameObject.tag=="+15")
        {
            checkpoint++;
            destroyFlag = true;
            //destinySphere = destinySphereObject3.transform;
            for (int i = 0; i <= 14; i++)
            {
                xVar = Random.Range(randxLow, randxHigh);
                zVar = Random.Range(randzLow, randzHigh);
                Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);
               
            }
            numberOfClones = numberOfClones + 15;
        }
        if(other.gameObject.tag=="2x")
        {
            destroyFlag = true;
            checkpoint++;
            //destinySphere = destinySphereObject3.transform;
            for (int i = 0; i <= (numberOfClones-1); i++)
            {
                xVar = Random.Range(randxLow, randxHigh);
                zVar = Random.Range(randzLow, randzHigh);
                Instantiate(clone, new Vector3(transform.position.x - xVar, transform.position.y, transform.position.z - zVar), transform.rotation);

            }
            numberOfClones = numberOfClones * 2;
        }
        
    }
}
