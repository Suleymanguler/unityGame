using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneScript : MonoBehaviour
{

    public Transform mainCharacterPos,clonePos,destinyMain,destiny1,destiny2,destiny3,destiny4;
    public GameObject mainCharacter,cloneCharacter;
    mainCharacter mainCharacterScript;


 


    void Start()
    {
        
        mainCharacter = GameObject.Find("mainCharacter");
        mainCharacterScript = mainCharacter.GetComponent<mainCharacter>();
        mainCharacterPos = mainCharacter.transform;
        cloneCharacter = this.gameObject;
        clonePos = cloneCharacter.transform;
        destinyMain.position = new Vector3(0, 0, 0);

    }

    void FixedUpdate()
    {

        //transform.position = Vector3.MoveTowards(transform.position, mainCharacterPos.transform.position-new Vector3(0,0,0.02f), .045f);
        transform.position = Vector3.MoveTowards(transform.position, destinyMain.transform.position - new Vector3(0, 0, 0f), .045f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(mainCharacterScript.checkpoint==0)
        {
            destinyMain = mainCharacterScript.destinySphere;
        }
        else if(mainCharacterScript.checkpoint==1)
        {
            destinyMain = mainCharacterScript.destinySphere2;
        }
        else if(mainCharacterScript.checkpoint==2)
        {
            destinyMain = mainCharacterScript.destinySphere3;
        }
        else if(mainCharacterScript.destiny4Flag)
        {
            destinyMain = mainCharacterScript.destinySphere4;
        }
        if (other.gameObject.tag == "boss")
        {
            gameObject.SetActive(false);
            mainCharacterScript.numberOfClones--;
        }
    }
}
