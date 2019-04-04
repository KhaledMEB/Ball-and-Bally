using UnityEngine;

public class StartPanel : MonoBehaviour {

    public void ReloadLevel()
    {
        FindObjectOfType<GameManager>().ReloadLevel();
    }

    public void LoadNextLevel()
    {
        FindObjectOfType<GameManager>().LoadNextLevel(); //change it when adding multiple levels
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

}
