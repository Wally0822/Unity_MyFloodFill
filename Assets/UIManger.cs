using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManger : MonoBehaviour
{
    #region ╫л╠шео

    //static UIManger inst;

    //public static UIManger Inst
    //{
    //    get
    //    {
    //        if(inst == null)
    //            inst = FindObjectOfType<UIManger>();
    //        return inst;
    //    }
    //}

    #endregion


    [SerializeField] GameObject InputPanel = null;

    [SerializeField] TMP_InputField inPutBoardSizes = null;
    [SerializeField] TMP_InputField inPutMinesNums = null;
    [SerializeField] Button Startgame = null;

    bool isinPut = false;

    private void Awake()
    {
        // Set Screen Size 16:9, and No fullscreen
        Screen.SetResolution(800, 450, false);

        Startgame.interactable = false; // not input some. button false.
    }




    public string GetBoardsize()
    {
        return inPutBoardSizes.text;
    }
    
    public string GetMinesNum()
    {
        return inPutMinesNums.text;
    }

    public void SetPanel()
    {


    }



    public void gameStart()
    {

        Startgame.interactable = true; // 

        InputPanel.SetActive(false);
    }



}

