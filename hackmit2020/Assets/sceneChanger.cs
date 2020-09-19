using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{

    public Animator transition;

    public void gotoLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void gotoMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void gotoLevel1()
    {
        SceneManager.LoadScene("Level1");
    }


    IEnumerator Level1()
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level1");
    }
}
