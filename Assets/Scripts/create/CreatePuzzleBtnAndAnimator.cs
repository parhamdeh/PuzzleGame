using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePuzzleBtnAndAnimator : MonoBehaviour
{
    [SerializeField]
    private Button PuzzleBtn;

    [SerializeField]
    private LayoutPuzzleBtn LayoutPuzzleBtn;

    private int PuzzleGame1 = 6;
    private int PuzzleGame2 = 12;
    private int PuzzleGame3 = 18;
    private int PuzzleGame4 = 24;
    private int PuzzleGame5 = 30;


    private List<Button> level1button = new List<Button>();
    private List<Button> level2button = new List<Button>();
    private List<Button> level3button = new List<Button>();
    private List<Button> level4button = new List<Button>();
    private List<Button> level5button = new List<Button>();

    private List<Animator> level1Animtor = new List<Animator>();
    private List<Animator> level2Animtor = new List<Animator>();
    private List<Animator> level3Animtor = new List<Animator>();
    private List<Animator> level4Animtor = new List<Animator>();
    private List<Animator> level5Animtor = new List<Animator>();
    void Start()
    {
        AssignButtonAndAnims();
    }


    void Awake()
    {
        CreateButton();
        GetAnimtor();
    }

    void AssignButtonAndAnims(){
        LayoutPuzzleBtn.level1Button = level1button;
        LayoutPuzzleBtn.level2Button = level2button;
        LayoutPuzzleBtn.level3Button = level3button;
        LayoutPuzzleBtn.level4Button = level4button;
        LayoutPuzzleBtn.level5Button = level5button;

        LayoutPuzzleBtn.level1Animator = level1Animtor;
        LayoutPuzzleBtn.level2Animator = level2Animtor;
        LayoutPuzzleBtn.level3Animator = level3Animtor;
        LayoutPuzzleBtn.level4Animator = level4Animtor;
        LayoutPuzzleBtn.level5Animator = level5Animtor;
    }
    void CreateButton()
    {
        for (int i = 0; i < PuzzleGame1; i++)
        {
            Button btn = Instantiate(PuzzleBtn);
            btn.gameObject.name = "" + i;
            level1button.Add(btn);
        }
        for (int i = 0; i < PuzzleGame2; i++)
        {
            Button btn = Instantiate(PuzzleBtn);
            btn.gameObject.name = "" + i;
            level2button.Add(btn);
        }
        for (int i = 0; i < PuzzleGame3; i++)
        {
            Button btn = Instantiate(PuzzleBtn);
            btn.gameObject.name = "" + i;
            level3button.Add(btn);
        }
        for (int i = 0; i < PuzzleGame4; i++)
        {
            Button btn = Instantiate(PuzzleBtn);
            btn.gameObject.name = "" + i;
            level4button.Add(btn);
        }
        for (int i = 0; i < PuzzleGame5; i++)
        {
            Button btn = Instantiate(PuzzleBtn);
            btn.gameObject.name = "" + i;
            level5button.Add(btn);
        }
    }
    void GetAnimtor()
    {
        for (int i = 0; i < level1button.Count; i++)
        {
            level1Animtor.Add(level1button[i].gameObject.GetComponent<Animator>());
            level1button[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level2button.Count; i++)
        {
            level2Animtor.Add(level2button[i].gameObject.GetComponent<Animator>());
            level2button[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level3button.Count; i++)
        {
            level3Animtor.Add(level3button[i].gameObject.GetComponent<Animator>());
            level3button[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level4button.Count; i++)
        {
            level4Animtor.Add(level4button[i].gameObject.GetComponent<Animator>());
            level4button[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < level5button.Count; i++)
        {
            level5Animtor.Add(level5button[i].gameObject.GetComponent<Animator>());
            level5button[i].gameObject.SetActive(false);
        }
    }
}
