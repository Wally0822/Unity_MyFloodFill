using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minesweeper : MonoBehaviour
{



    // ���� ã��
    // �������� ���� ������ �ϰ�
    // ���ڸ� ����
    // Ŭ�� ��  

    // ��ǲ �ʵ�� �Է��� ���� �޾Ƽ� ������ �� ���� ����

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
