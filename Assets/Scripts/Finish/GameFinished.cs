using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
    [SerializeField]
    private GameObject gameFinishPanel;
    [SerializeField]
    private Animator gameFinishanim, star1anim, star2anim, star3anim, textAnim;

    // public void Start()
    // {
    //     ShowGameFinishedPanel(3);
    // }
    public void ShowGameFinishedPanel(int stars)
    {
        StartCoroutine(ShowPanel(stars));
    }
    public void HideGameFinishedPanel()
    {
        if (gameFinishPanel.activeInHierarchy)
        {
            StartCoroutine(HidePanel());
        }
    }

    IEnumerator ShowPanel(int stars)
    {
        gameFinishPanel.SetActive(true);
        gameFinishanim.Play("FadeIn");

        yield return new WaitForSeconds(1.7f);

        switch (stars)
        {
            case 1:
                star1anim.Play("FadeIn");
                yield return new WaitForSeconds(.1f);
                textAnim.Play("FadeIn");
                break;
            case 2:
                star1anim.Play("FadeIn");
                yield return new WaitForSeconds(.25f);
                star2anim.Play("FadeIn");
                yield return new WaitForSeconds(.1f);
                textAnim.Play("FadeIn");
                break;

            case 3:
                star1anim.Play("FadeIn");
                yield return new WaitForSeconds(.25f);
                star2anim.Play("FadeIn");
                yield return new WaitForSeconds(.25f);
                star3anim.Play("FadeIn");
                yield return new WaitForSeconds(.1f);
                textAnim.Play("FadeIn");
                break;
        }

    }
    IEnumerator HidePanel()
    {
        gameFinishanim.Play("FadeOut");
        star1anim.Play("FadeOut");
        star2anim.Play("FadeOut");
        star3anim.Play("FadeOut");

        yield return new WaitForSeconds(1.5f);

        gameFinishPanel.SetActive(false);
    }
}
