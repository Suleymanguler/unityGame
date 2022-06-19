using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneScript : MonoBehaviour
{

    public Transform mainCharacterPos,clonePos;
    public GameObject mainCharacter,cloneCharacter;
 


    void Start()
    {
        
        mainCharacter = GameObject.Find("mainCharacter");
        mainCharacterPos = mainCharacter.transform;
        cloneCharacter = this.gameObject;
        clonePos = cloneCharacter.transform;

    }

    void FixedUpdate()
    {
       // clonePos.position = Vector3.Lerp(clonePos.position, mainCharacterPos.position, 0.05f);

        transform.position = Vector3.MoveTowards(transform.position, mainCharacterPos.transform.position-new Vector3(0,0,0f), .03f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boss")
        {
            gameObject.SetActive(false);
        }
    }
}
