using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void gotoLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void gotoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
