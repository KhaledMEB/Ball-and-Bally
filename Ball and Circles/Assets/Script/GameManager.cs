using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int homeSceneIndex = 0;

    public void ReloadLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadHomeScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(homeSceneIndex);
    }

    public void PauseLevel()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseLevel()
    {
        Time.timeScale = 1f;
    }
	
}
