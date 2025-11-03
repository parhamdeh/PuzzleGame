using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour
{

    [SerializeField]
    private Manager manager;
    [SerializeField]
    private LayoutPuzzleBtn LayoutPuzzleBtn;
    [SerializeField]
    private GameObject PPuzzleLevelSelectPanel;
    [SerializeField]
    private Animator puzzleLevelSelectanim;
    [SerializeField]
    private GameObject puzzleGamepanel1, puzzleGamepanel2, puzzleGamepanel3, puzzleGamepanel4, puzzleGamepanel5;
    [SerializeField]
    private Animator puzzleGameanim1, puzzleGameanim2, puzzleGameanim3, puzzleGameanim4, puzzleGameanim5;

    private List<Animator> anims;
    private int puzzleLevel;
    private string selectedpuzzle;

    public void LoadPuzzle(int level, string puzzle){
        this.puzzleLevel = level;
        this.selectedpuzzle = puzzle;

        LayoutPuzzleBtn.LayoutButtons(level, selectedpuzzle);

        switch (puzzleLevel)
        {
            case 0:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamepanel1, puzzleGameanim1));
                break;
            case 1:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamepanel2, puzzleGameanim2));
                break;
            case 2:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamepanel3, puzzleGameanim3));
                break;
            case 3:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamepanel4, puzzleGameanim4));
                break;
            case 4:
                StartCoroutine(LoadPuzzleGamePanel(puzzleGamepanel5, puzzleGameanim5));
                break;
            
        }
        
    }
    public void BackTOPuzzleLevelMenu(){

        anims = manager.RestGamePlay(); 
        switch (puzzleLevel)
        {
            case 0:
                StartCoroutine(LoadPuzlleLevelSelectMenu(puzzleGamepanel1, puzzleGameanim1));
                break;
            case 1:
                StartCoroutine(LoadPuzlleLevelSelectMenu(puzzleGamepanel2, puzzleGameanim2));
                break;
            case 2:
                StartCoroutine(LoadPuzlleLevelSelectMenu(puzzleGamepanel3, puzzleGameanim3));
                break;
            case 3:
                StartCoroutine(LoadPuzlleLevelSelectMenu(puzzleGamepanel4, puzzleGameanim4));
                break;
            case 4:
                StartCoroutine(LoadPuzlleLevelSelectMenu(puzzleGamepanel5, puzzleGameanim5));
                break;

        }

    }
    IEnumerator LoadPuzlleLevelSelectMenu(GameObject puzzleGamePanel, Animator puzzleGameAnim){
        PPuzzleLevelSelectPanel.SetActive(true);
        puzzleGameAnim.Play("slideout");
        puzzleLevelSelectanim.Play("slidein");
        yield return new WaitForSeconds(1f);

        foreach (Animator anim in anims)
        {
            // Check This name idle....
            anim.Play("idle");
        }
        yield return new WaitForSeconds(.5f);
    
        puzzleGamePanel.SetActive(false);
    }
    IEnumerator LoadPuzzleGamePanel(GameObject puzzleGamePanel, Animator puzzleGameAnim){
        puzzleGamePanel.SetActive(true);
        puzzleGameAnim.Play("SlideIn");
        puzzleLevelSelectanim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        PPuzzleLevelSelectPanel.SetActive(false);
    }
}
