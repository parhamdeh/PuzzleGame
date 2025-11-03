using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LayoutPuzzleBtn : MonoBehaviour
{
    
    [SerializeField]
    private SetUpPuzzleGame setUpPuzzleGame;
    public Transform puzzleLevel1, puzzleLevel2, puzzleLevel3, puzzleLevel4, puzzleLevel5;


    public List<Button> level1Button, level2Button, level3Button, level4Button, level5Button;
    public List<Animator> level1Animator, level2Animator, level3Animator, level4Animator, level5Animator;

   [SerializeField]
   private Sprite[] puzzleBtnBackimg;
   private int puzzleLevel;

   private string selectedpuzzle;

   public void LayoutButtons(int level, string puzzle){

        this.puzzleLevel = level;
        this.selectedpuzzle = puzzle;

        setUpPuzzleGame.SetLevelAndPuzzle(level, puzzle);
        LayoutPuzzle();
   }

   public void LayoutPuzzle(){
    switch (puzzleLevel){

    case 0:
        foreach (Button btn in level1Button){
            if(!btn.gameObject.activeInHierarchy){
                btn.gameObject.SetActive(true);
                btn.gameObject.transform.SetParent(puzzleLevel1, false);
                if(selectedpuzzle == "candy button"){
                    btn.image.sprite = puzzleBtnBackimg[0];
                }else if(selectedpuzzle == "transport button"){
                    btn.image.sprite = puzzleBtnBackimg[1];
                }else if(selectedpuzzle == "fruit button"){
                    btn.image.sprite = puzzleBtnBackimg[2];
                }

            }
        }
        setUpPuzzleGame.SetPuzzleButtonsAndAnimators(level1Button, level1Animator);
        
        break;
    case 1:
        foreach (Button btn in level2Button){
            if(!btn.gameObject.activeInHierarchy){
                btn.gameObject.SetActive(true);
                btn.gameObject.transform.SetParent(puzzleLevel2, false);
                if(selectedpuzzle == "candy button"){
                    btn.image.sprite = puzzleBtnBackimg[0];
                }else if(selectedpuzzle == "transport button"){
                    btn.image.sprite = puzzleBtnBackimg[1];
                }else if(selectedpuzzle == "fruit button"){
                    btn.image.sprite = puzzleBtnBackimg[2];
                }

            }
        }
        setUpPuzzleGame.SetPuzzleButtonsAndAnimators(level2Button, level2Animator);
        break;
    case 2:
        foreach (Button btn in level3Button){
            if(!btn.gameObject.activeInHierarchy){
                btn.gameObject.SetActive(true);
                btn.gameObject.transform.SetParent(puzzleLevel3, false);
                if(selectedpuzzle == "candy button"){
                    btn.image.sprite = puzzleBtnBackimg[0];
                }else if(selectedpuzzle == "transport button"){
                    btn.image.sprite = puzzleBtnBackimg[1];
                }else if(selectedpuzzle == "fruit button"){
                    btn.image.sprite = puzzleBtnBackimg[2];
                }

            }
        }
        setUpPuzzleGame.SetPuzzleButtonsAndAnimators(level3Button, level3Animator);
        
        break;
    case 3:
        foreach (Button btn in level4Button){
            if(!btn.gameObject.activeInHierarchy){
                btn.gameObject.SetActive(true);
                btn.gameObject.transform.SetParent(puzzleLevel4, false);
                if(selectedpuzzle == "candy button"){
                    btn.image.sprite = puzzleBtnBackimg[0];
                }else if(selectedpuzzle == "transport button"){
                    btn.image.sprite = puzzleBtnBackimg[1];
                }else if(selectedpuzzle == "fruit button"){
                    btn.image.sprite = puzzleBtnBackimg[2];
                }

            }
        }
        setUpPuzzleGame.SetPuzzleButtonsAndAnimators(level4Button, level4Animator);
        
        break;
    case 4:
        foreach (Button btn in level5Button){
            if(!btn.gameObject.activeInHierarchy){
                btn.gameObject.SetActive(true);
                btn.gameObject.transform.SetParent(puzzleLevel5, false);
                if(selectedpuzzle == "candy button"){
                    btn.image.sprite = puzzleBtnBackimg[0];
                }else if(selectedpuzzle == "transport button"){
                    btn.image.sprite = puzzleBtnBackimg[1];
                }else if(selectedpuzzle == "fruit button"){
                    btn.image.sprite = puzzleBtnBackimg[2];
                }

            }
        }
        setUpPuzzleGame.SetPuzzleButtonsAndAnimators(level5Button, level5Animator);
        break;
    }

   }
   
}
