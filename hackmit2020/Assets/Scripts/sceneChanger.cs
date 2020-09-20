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
    public void gotoLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void gotoLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void gotoLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    IEnumerator Level1()
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level1");
    }
}
