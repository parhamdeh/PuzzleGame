using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{

    [SerializeField]
    private Manager manager;
    [SerializeField]
    public Level selectlevel;
    [SerializeField]
    private GameObject selectPuzzleMenuPanel, puzzlelevelselectpanel;
    [SerializeField]
    private Animator selectPuzzleMenuanim, puzzlelevelselectanim;
    private string selectedPuzzle;

    public void SelectPuzzle()
    {
        selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        manager.SetSelectedPuzzle(selectedPuzzle);

        selectlevel.SetSelectedPuzzle(selectedPuzzle);

        StartCoroutine(ShowLevel());
    }
    IEnumerator ShowLevel()
    {
        puzzlelevelselectpanel.SetActive(true);
        selectPuzzleMenuanim.Play("SlideOut");
        puzzlelevelselectanim.Play("slidein");
        yield return new WaitForSeconds(1f);
        selectPuzzleMenuPanel.SetActive(false);


    }
    
}
