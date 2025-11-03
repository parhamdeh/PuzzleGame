using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField]
    private Manager manager;
    [SerializeField]
    private LoadPuzzleGame loadPuzzleGame;
    [SerializeField]
    private GameObject selectPuzzleMenuPanel, PuzzleLevelSelectPanel;

    [SerializeField]
    private Animator selectPuzzleMenuAnim, PuzzleLevelSelectAnim;

    private string selectPuzzle;

    public void BackToPuzzleSelectMenu()
    {
        StartCoroutine(ShowPuzzleSelectMenu());
    }

    public void SlectPuzzleLevel(){
        int Level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        manager.SetLevel(Level);
        loadPuzzleGame.LoadPuzzle(Level, selectPuzzle);
    }

    IEnumerator ShowPuzzleSelectMenu()
    {
        selectPuzzleMenuPanel.SetActive(true);
        selectPuzzleMenuAnim.Play("SlideIn");
        PuzzleLevelSelectAnim.Play("slideOut");
        yield return new WaitForSeconds(0.001f);
        PuzzleLevelSelectPanel.SetActive(false);
    }
    public void SetSelectedPuzzle(string selectPuzzle){
        this.selectPuzzle = selectPuzzle;
        Debug.Log("this is selected puzzle" + selectPuzzle);
    }
}

