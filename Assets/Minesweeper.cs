using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minesweeper : MonoBehaviour
{



    // 지뢰 찾기
    // 보드판을 먼저 생성을 하고
    // 지뢰를 생성
    // 클릭 시  

    // 인풋 필드로 입력한 값을 받아서 보드판 및 지뢰 생성

    public UIManger manger;

    private void Awake()
    {


    }

    void grenerateBoard()
    {
        string Boardnum = manger.GetBoardsize();

        int BoardSize = int.Parse(Boardnum);

        Debug.Log("BoardSize : " + BoardSize);
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
