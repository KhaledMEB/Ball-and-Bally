using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private int collisionCounter;


    /*All about winning the Level*/
    public SpriteRenderer goalSprite;
    public Collider2D goalCollider;
    public ParticleSystem winEffect;
    public Animator ballyFadeOut;

    public Animator transition; //Lights

    public GameObject interactablePanel; //make the pause and undo not intercatble
    public GameObject levelCompletePanel;


    public int GetCollisionCounter()
    {
      return collisionCounter;
    }


    public void PlayWinEffect()
    {
        goalCollider.enabled = false;
        winEffect.Play();
        goalSprite.enabled = false;
        ballyFadeOut.SetTrigger("FadeOut"); //give life to bally
        StartCoroutine("EnableCompleteLevel");

    }

    private IEnumerator EnableCompleteLevel()
    {
        interactablePanel.SetActive(true); //do not let the player pause or undo
        yield return new WaitForSeconds(4.5f);
        levelCompletePanel.SetActive(true);
        //FindObjectOfType<UIManager>().EnableLevelCpPanel();
    }

    #region Lights Animations

    //from Red to Green
    public void GrennLights()
    {
        transition.SetTrigger("Green");
    }

    //from Green to Red
    public void RedLights()
    {
        transition.SetTrigger("Red");
    }

    //Pull the lights up
    public void HideLights()
    {
        transition.SetTrigger("HideLight");
    }

    #endregion
}
