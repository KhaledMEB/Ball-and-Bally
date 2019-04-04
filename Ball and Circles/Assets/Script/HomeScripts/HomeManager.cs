using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour {

    public Animator homeCanvas;
    public GameObject transitionPanel;
    public Animator transitionPanelAnim;

    private void Start()
    {
        transitionPanelAnim.SetTrigger("Start");
    }


    public void Play()
    {
        homeCanvas.SetTrigger("PlayButton");
        StartCoroutine("LaunchGame");
    }

    private IEnumerator LaunchGame()
    {
        yield return new WaitForSeconds(0.45f);
       transitionPanel.SetActive(true);
        transitionPanelAnim.SetTrigger("Next");
    }
}
