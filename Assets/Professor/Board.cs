using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //public int BoardSize = 50;
    public GameObject prefabCell = null;

    GameObject[,] grid = null;

    int BoardSize;

    void Awake()
    {
        BoardSize = int.Parse(UIManager.Inst.boardSizes);
    }

    // Start is called before the first frame update
    void Start()
    {
        generateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            floodFill(Random.Range(0, BoardSize), Random.Range(0, BoardSize), Color.red);
        }
        if(Input.GetMouseButton(0))
		{
            // 마우스 위치에서 시작하는 ray 를 생성해서 이 ray 와 출동하는 셀을 찾기 위해
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hitInfo, 1000f))
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
                grid[y, x] = Instantiate(prefabCell, new Vector3(x-BoardSize/2, y -BoardSize/2, 0), Quaternion.identity, transform);

                if (Random.Range(0, 1f) <= 0.5f)
                {
                    Renderer renderer = grid[y, x].GetComponent<Renderer>();
                    renderer.material.color = Color.black;
                }
            }
        }
    }

    // 코루틴 함수
	IEnumerator floodFill2(int x, int y, Color newColor)
	{
        yield return new WaitForSeconds(0.1f);

		if (x < 0 || x >= BoardSize) yield break;
		if (y < 0 || y >= BoardSize) yield break;

		// 탈출조건 - 셀이 검은색이거나, 이미 내가 칠한 셀이면 탈출
		Renderer renderer = grid[y, x].GetComponent<Renderer>();
		if (renderer.material.color == Color.black || renderer.material.color == newColor)
			yield break;

		// x, y 의 셀에 색을 칠하자
		renderer.material.color = newColor;

		StartCoroutine(floodFill2(x - 1, y, newColor)); // 좌
		StartCoroutine(floodFill2(x + 1, y, newColor)); // 우

		StartCoroutine(floodFill2(x, y + 1, newColor)); // 상
		StartCoroutine(floodFill2(x, y - 1, newColor)); // 하
	}


	// 채우는 함수
	// x, y 위치에 컬러를 지정된 색으로 칠하기
	void floodFill(int x, int y, Color newColor)
    {
        if (x < 0 || x >= BoardSize) return;
		if (y < 0 || y >= BoardSize) return;

		// 탈출조건 - 셀이 검은색이거나, 이미 내가 칠한 셀이면 탈출
		Renderer renderer = grid[y, x].GetComponent<Renderer>();
        if (renderer.material.color == Color.black || renderer.material.color == newColor)
            return;

        // x, y 의 셀에 색을 칠하자
        renderer.material.color = newColor;

		floodFill(x - 1, y, newColor); // 좌
		floodFill(x + 1, y, newColor); // 우

		floodFill(x, y + 1, newColor); // 상
		floodFill(x, y - 1, newColor); // 하
    }
}