using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int index;
    public AudioSource tap;

    public void PlayButton()
    {
        StartCoroutine(SceneLoader(1));
    }

    public void NextLevel()
    {
        StartCoroutine(SceneLoader(index + 1));
    }

    public void MainMenu()
    {
        StartCoroutine(SceneLoader(0));
    }

    public void LevelOne()
    {
        StartCoroutine(SceneLoader(1));
    }

    public void LevelTwo()
    {
        StartCoroutine(SceneLoader(2));
    }

    public void LevelThree()
    {
        StartCoroutine(SceneLoader(3));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator SceneLoader(int sceneIndex)
    {
        tap.Play();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(sceneIndex);
    }

}
