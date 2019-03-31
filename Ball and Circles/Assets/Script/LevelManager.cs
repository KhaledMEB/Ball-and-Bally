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
        yield return new WaitForSeconds(4.5f);
        FindObjectOfType<UIManager>().EnableLevelCpPanel();
    }

    #region Lights Animations

    public void SwitchLights()
    {
        transition.SetTrigger("Green");
    }

    public void HideLights()
    {
        transition.SetTrigger("HideLight");
    }

    #endregion
}
