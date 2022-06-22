using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eventManager : MonoBehaviour
{
    void Start()
    {
        
    }

    public void loadScene1()
    {
        SceneManager.LoadScene("Scene");
    }
}
