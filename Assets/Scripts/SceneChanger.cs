using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int sceneIndex = 0;

    private void Start()
    {
        sceneIndex = 0;
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver() 
    {
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex);
       
    }

    public void Retry() 
    {
        sceneIndex--;
        SceneManager.LoadScene(sceneIndex);
    }

    public void Win() 
    {
        sceneIndex += 2;
        SceneManager.LoadScene(sceneIndex);
    }

    public void changeToMainScene()
    {
        if (Input.GetKeyDown("q")){
            SceneManager.LoadScene(sceneIndex = 0);
        }
    }
}
