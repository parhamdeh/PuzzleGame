using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpPuzzleGame : MonoBehaviour
{
    [SerializeField]
    private Manager manager;
    private Sprite[] candySprites, fruitSprites, transportSprites;
    [SerializeField]
    private List<Sprite> gamePuzzles = new List<Sprite>();
    private List<Button> puzzleButtons = new List<Button>();
    private List<Animator> puzzleButtonAnimators = new List<Animator>();

    private int level;
    private string selectedpuzzle;

    private int looper;
    void Awake()
    {
        candySprites = Resources.LoadAll<Sprite>("Sprits/Game/Candy");
        fruitSprites = Resources.LoadAll<Sprite>("Sprits/Game/Fruits");
        transportSprites = Resources.LoadAll<Sprite>("Sprits/Game/Transport");
        
    }

    void PreperGameSprites()
    {
        gamePuzzles.Clear();
        gamePuzzles = new List<Sprite>();

        int index = 0;
        switch(level){
            case 0:
                looper = 6;
                break;  
            case 1:
                looper = 12;
                break;  
            case 2:
                looper = 18;
                break;  
            case 3:
                looper = 24;
                break;  
            case 4:
                looper = 30;
                break;  
        }
        switch (selectedpuzzle){
            case "candy button":
                for(int i = 0; i < looper; i++){
                    if(index == looper/2){
                        index = 0;
                    }
                    gamePuzzles.Add(candySprites[index]);
                    index++;
                }
                break;
            case "fruit button":
                for(int i = 0; i < looper; i++){
                    if(index == looper/2){
                        index = 0;
                    }
                    gamePuzzles.Add(fruitSprites[index]);

                    index++;

                }
                break;
            case "transport button":
                for(int i = 0; i < looper; i++){
                    if(index == looper/2){
                        index = 0;
                    }
                    gamePuzzles.Add(transportSprites[index]);

                    index++;
                }
                break;
        }
        shuffle(gamePuzzles);
        
    }
    void shuffle(List<Sprite> list){
        for (int i = 0; i <list.Count; i++){
            Sprite temp =  list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    public void SetLevelAndPuzzle(int level, string selectedpuzzle)
    {
        this.level = level;
        this.selectedpuzzle = selectedpuzzle;

        PreperGameSprites();

        manager.SetGamePuzzleSprites(this.gamePuzzles);

    }
    public void SetPuzzleButtonsAndAnimators(List<Button> puzzleButtons, List<Animator> puzzleButtonAnimators)
    {
        this.puzzleButtons = puzzleButtons;
        this.puzzleButtonAnimators = puzzleButtonAnimators;

        manager.SetUpButtonAndAnimator(puzzleButtons, puzzleButtonAnimators);
    }
}
