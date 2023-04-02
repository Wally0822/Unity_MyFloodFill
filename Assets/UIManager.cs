using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager instance = null;
    public static UIManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    instance = new GameObject(nameof(UIManager), typeof(UIManager)).GetComponent<UIManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    [SerializeField] Canvas InputPanel = null;
    [SerializeField] Board board = null;
    [SerializeField] Minesweeper minesweeper = null;
    [SerializeField] TextMeshProUGUI infoText = null;
    [SerializeField] TMP_InputField inPutBoardSizes = null;
    [SerializeField] TMP_InputField inPutMinesNums = null;
    [SerializeField] Button startGameBut = null;

    public string boardSizes { get; set; }
    public string minesNums { get; set; }

    void Awake()
    {
        // Set Screen Size 16:9, and No fullscreen
        Screen.SetResolution(800, 450, false);
        startGameBut.onClick.AddListener(() => StartGame());
    }

    void StartGame()
    {
        //startGameBut.interactable = true; // not input some. button false.
        boardSizes = inPutBoardSizes.text;
        minesNums = inPutMinesNums.text;
        //print("board : " + boardSizes);
        //print("minesNums : " + minesNums);
        if (string.IsNullOrEmpty(boardSizes) && string.IsNullOrEmpty(minesNums))
        {
            //print("null ¿Ã¥Ÿ");
            infoText.gameObject.SetActive(true);
            return;
        }
        else
        {
            infoText.gameObject.SetActive(false);
            InputPanel.gameObject.SetActive(false);
            minesweeper.gameObject.SetActive(true);
        }
    }
}