using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSetting : MonoBehaviour
{
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Escape))
        Application.Quit();

        if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("main");
    }
}
