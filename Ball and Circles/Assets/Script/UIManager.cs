using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Button stopButton;
    public Image soundImage;
    public GameObject pausePanel;
    public TextMeshProUGUI collisionCpt;

    public GameObject interactablePanel; //make the pause and undo not intercatble

    /*Animation when reloading or starting the scene*/
    public Animator startPanelAnim;
    public GameObject startPanel;

    public Animator levelCompletePanelAnim;
    public GameObject levelCompletePanel;

    public Animator undoButtonAnim;

    private bool isSoundActive = true;
    private bool raycastAllowed = false;
    private bool gameOver = false; //if the game is over
    

    private void DesableButton(Button button)
    {
        button.gameObject.SetActive(false);
    }

    private void EnableButton(Button button)
    {
        button.gameObject.SetActive(true);
    }

    public void Start()
    {
        startPanelAnim.SetTrigger("Start");
    }


    public void DesableStopButton()
    {
        DesableButton(stopButton);
        FindObjectOfType<GuideLine>().enabled = true;
        raycastAllowed = true;
    }

    public void EnableStopButton()
    {
        EnableButton(stopButton);
        FindObjectOfType<GuideLine>().enabled = false;
        raycastAllowed = false;
    }

    public void StopObstacle()
    {
        FindObjectOfType<ObstacleController>().StopObstacle();
    }

    public void Pause()
    {
        FindObjectOfType<GameManager>().PauseLevel();
        pausePanel.SetActive(true);
        FindObjectOfType<GuideLine>().enabled = false;
    }

    public void Reload()
    {
        startPanel.SetActive(true);
        startPanelAnim.SetTrigger("Reload");
    }

    public void EnableLevelCpPanel()
    {
        interactablePanel.SetActive(true); //do not let the player pause or undo
        levelCompletePanel.SetActive(true);
    }

    public void Undo()
    {
        if (gameOver)
        {
            FindObjectOfType<Rewind>().StartRewind();
            gameOver = false;
        }
            
        else //game not over yew => a  simple undo to a collider
            FindObjectOfType<ObstacleController>().Undo();
    }

    public void UndoShake()
    {
        undoButtonAnim.SetTrigger("Shake");
    }


    public void Play()
    {
        FindObjectOfType<GameManager>().UnPauseLevel();
        pausePanel.SetActive(false);
        if(raycastAllowed)
            FindObjectOfType<GuideLine>().enabled = true;
    }

    public void Home()
    {
        FindObjectOfType<GameManager>().LoadHomeScene();
    }

    public void Sound()
    {
        if(isSoundActive)
        {
            DesableSound();
        }
        else
        {
            EnableSound();
        }
    }

    public void NextLevel()
    {
        levelCompletePanelAnim.SetTrigger("Next");
        StartCoroutine("StartNextPanel");

    }

    private IEnumerator StartNextPanel()
    {
        yield return new WaitForSeconds(1f);
        startPanel.SetActive(true);
        startPanelAnim.SetTrigger("Next");
    }

    private void EnableSound()
    {
        SetColorAlpha(1);
        isSoundActive = true;
    }

    private void DesableSound()
    {
        SetColorAlpha(0.35f);
        isSoundActive = false;
    }

    private void SetColorAlpha(float a)
    {
        Color color = soundImage.color;
        color.a = a;
        soundImage.color = color;
    }

    public void UpdateCollisionCpt(int cpt)
    {
        collisionCpt.text = cpt.ToString();
    }

    public void SetRaycastAllowed(bool x)
    {
        raycastAllowed = x;
    }

    public void SetGameOver(bool x)
    {
        gameOver = x;
    }




}
