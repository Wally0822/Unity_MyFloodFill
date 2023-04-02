using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minesweeper : MonoBehaviour
{
    //public int BoardSize = 50;
    public GameObject prefabCell = null;
    public GameObject mines = null;

    GameObject[,] grid = null;

    int BoardSize;

    void Awake()
    {
        BoardSize = int.Parse(UIManager.Inst.boardSizes);
    }

    void Start()
    {
        generateBoard();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // ���콺 ��ġ���� �����ϴ� ray �� �����ؼ� �� ray �� �⵿�ϴ� ���� ã�� ����
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, 1000f))
            {
                Vector3 pos = hitInfo.collider.transform.position;
                //floodFill((int)pos.x, (int)pos.y, Color.red);
                StartCoroutine(floodFill2((int)pos.x + BoardSize / 2, (int)pos.y + BoardSize / 2, Color.red));
            }
        }
    }

    void generateBoard()
    {
        grid = new GameObject[BoardSize, BoardSize];
        for (int y = 0; y < BoardSize; ++y)
        {
            for (int x = 0; x < BoardSize; ++x)
            {
                grid[y, x] = Instantiate(prefabCell, new Vector3(x - BoardSize / 2, y - BoardSize / 2, 0), Quaternion.identity, transform);

                float mines = int.Parse(UIManager.Inst.minesNums);

                if (Random.Range(0, 1f) <= mines/100)
                {
                    Renderer renderer = grid[y, x].GetComponent<Renderer>();
                    renderer.material.color = Color.black;
                }
            }
        }
    }

    // �ڷ�ƾ �Լ�
    IEnumerator floodFill2(int x, int y, Color newColor)
    {
        yield return new WaitForSeconds(0.1f);

        if (x < 0 || x >= BoardSize) yield break;
        if (y < 0 || y >= BoardSize) yield break;

        // Ż������ - ���� �������̰ų�, �̹� ���� ĥ�� ���̸� Ż��
        Renderer renderer = grid[y, x].GetComponent<Renderer>();
        if (renderer.material.color == Color.black || renderer.material.color == newColor)
            yield break;

        // x, y �� ���� ���� ĥ����
        renderer.material.color = newColor;

        StartCoroutine(floodFill2(x - 1, y, newColor)); // ��
        StartCoroutine(floodFill2(x + 1, y, newColor)); // ��

        StartCoroutine(floodFill2(x, y + 1, newColor)); // ��
        StartCoroutine(floodFill2(x, y - 1, newColor)); // ��
    }
}
