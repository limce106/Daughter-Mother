using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ChangeScene2Name()
    {
        SceneManager.LoadScene("SetName");
    }
    public void ChangeSceneOut()
    {
        Application.Quit();
    }
}