using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameFinished gameFinished1;
   private List<Button> puzzleButtons = new List<Button>();
   private List<Animator> puzzleButtonsAnimator = new List<Animator>();
   [SerializeField]
   private List<Sprite> gamePuzzleSprite = new List<Sprite>();

   private int level;
   private string selectedpuzzle;

   private Sprite PuzzleBackGroundImg;

   private bool FirstGuess, SecondGuess;
   private int FirstGuessindex, SecondGuessindex;
   private string FirstGuessPuzzle, SecondGuessPuzzle;

    private int countTryGuess;

    private int countCorrectGuess;
    private int gameGuess;

    void PickAPuzzle()
    {
        if (!FirstGuess)
        {
            FirstGuess = true;

            FirstGuessindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            FirstGuessPuzzle = gamePuzzleSprite[FirstGuessindex].name;

            StartCoroutine(TurnPuzzleButton(puzzleButtonsAnimator[FirstGuessindex], puzzleButtons[FirstGuessindex], gamePuzzleSprite[FirstGuessindex]));

        }
        else if (!SecondGuess)
        {
            SecondGuess = true;

            SecondGuessindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            SecondGuessPuzzle = gamePuzzleSprite[SecondGuessindex].name;

            StartCoroutine(TurnPuzzleButton(puzzleButtonsAnimator[SecondGuessindex], puzzleButtons[SecondGuessindex], gamePuzzleSprite[SecondGuessindex]));

            StartCoroutine(CheckIfThePuzzleMatch(PuzzleBackGroundImg));

            countTryGuess++;
        }
        // int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        // StartCoroutine(TurnPuzzleButton(puzzleButtonsAnimator[index], puzzleButtons[index], gamePuzzleSprite[index]));
    }
    IEnumerator CheckIfThePuzzleMatch(Sprite PuzzleBackGroundImg){
        yield return new WaitForSeconds(1.4f);

        if (FirstGuessPuzzle == SecondGuessPuzzle)
        {
            puzzleButtonsAnimator[FirstGuessindex].Play("fadeOut");
            puzzleButtonsAnimator[SecondGuessindex].Play("fadeOut");

            IfGameIsFinished();

        }
        else
        {
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimator[FirstGuessindex], puzzleButtons[FirstGuessindex], PuzzleBackGroundImg));
            StartCoroutine(TurnPuzzleButtonBack(puzzleButtonsAnimator[SecondGuessindex], puzzleButtons[SecondGuessindex], PuzzleBackGroundImg));
        }
        yield return new WaitForSeconds(.7f);
        FirstGuess = false;
        SecondGuess = false;

    }
    void IfGameIsFinished()
    {
        countCorrectGuess++;
        if (countCorrectGuess == gameGuess)
        {
            Debug.Log("");
            CheckHowManyGuesses();
        }
    }
    void CheckHowManyGuesses()
    {
        int HowManyGuesses = 0;
        switch (level)
        {
            case 0:
                HowManyGuesses = 5;
                break;
            case 1:
                HowManyGuesses = 10;
                break;
            case 2:
                HowManyGuesses = 15;
                break;
            case 3:
                HowManyGuesses = 20;
                break;
            case 4:
                HowManyGuesses = 25;
                break;
        }
        if (countTryGuess < HowManyGuesses)
        {
            gameFinished1.ShowGameFinishedPanel(3);

        }
        else if (countTryGuess < (HowManyGuesses + 5))
        {
            gameFinished1.ShowGameFinishedPanel(2);
        }
        else
        {
            gameFinished1.ShowGameFinishedPanel(1);
        }


    }

    public List<Animator> RestGamePlay()
    {
        FirstGuess = SecondGuess = false;

        countTryGuess = 0;
        countCorrectGuess = 0;

        gameFinished1.HideGameFinishedPanel();

        return puzzleButtonsAnimator;
    }

    IEnumerator TurnPuzzleButton(Animator anim, Button btn, Sprite PuzzleImage){
        anim.Play("turnUp");
        yield return new WaitForSeconds(.4f);
        btn.image.sprite = PuzzleImage;
    }
    IEnumerator TurnPuzzleButtonBack(Animator anim, Button btn, Sprite PuzzleImage){
        anim.Play("turnBack");
        yield return new WaitForSeconds(.4f);
        btn.image.sprite = PuzzleImage;
    }
   
    void AddListners()
    {
        foreach (Button btn in puzzleButtons)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void SetUpButtonAndAnimator(List<Button> buttons, List<Animator> animators)
    {
        this.puzzleButtons = buttons;
        this.puzzleButtonsAnimator = animators;

        gameGuess = puzzleButtons.Count / 2;

        PuzzleBackGroundImg = puzzleButtons[0].image.sprite;

        AddListners();
    }
    public void SetGamePuzzleSprites(List<Sprite> Gamesprites){
        this.gamePuzzleSprite = Gamesprites;
    }
    public void SetLevel(int level){
        this.level = level;
    }
    public void SetSelectedPuzzle(string selectedpuzzle){
        this.selectedpuzzle = selectedpuzzle;
    }
}
