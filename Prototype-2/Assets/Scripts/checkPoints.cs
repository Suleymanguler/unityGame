using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoints : MonoBehaviour
{
    public GameObject mainCharacter;
    mainCharacter mainCharacterScript;
    void Start()
    {
        mainCharacter = GameObject.Find("mainCharacter");
        mainCharacterScript = mainCharacter.GetComponent<mainCharacter>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
