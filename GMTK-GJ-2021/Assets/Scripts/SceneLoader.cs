using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
        Debug.Log("Starting corutine");
        StartCoroutine(WaitForSceneToLoad(3));
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        //FindObjectOfType<GameSession>().StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitForSceneToLoad(float sec)
    {
        yield return new WaitForSeconds(sec);
        Debug.Log("Time Passed... time to start game!");
        FindObjectOfType<GameSession>().StartGame();
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}