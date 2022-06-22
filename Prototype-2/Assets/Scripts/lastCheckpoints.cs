using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastCheckpoints : MonoBehaviour
{
    public GameObject mainCharacter2;
    mainCharacter mainCharacterScript2;
    void Start()
    {
        mainCharacter2 = GameObject.Find("mainCharacter");
        mainCharacterScript2 = mainCharacter2.GetComponent<mainCharacter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "main character")
        {
            mainCharacterScript2.destiny4Flag = true;
        }
    }
}
