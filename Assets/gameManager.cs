using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;
    GameObject[,] field;
    GameObject instance;

    /// <summary>
    /// 与えられた数字をマップ上で移動させる
    /// </summary>
    /// <param name = "number" > 移動させる数字 </ param >
    /// < param name="moveFrom">元の位置</param>
    /// <param name = "moveTo" > 移動先の位置 </ param >
    /// < returns > 移動可能な時 true</returns>
    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }

        //return true;

        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if (!success) { return false; }
        }

        field[moveFrom.y, moveFrom.x].transform.position =
            new Vector3(moveTo.x, -1 * moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }

    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                GameObject obj = field[y, x];
                if (obj != null && obj.tag == "Player") //obj?.tag == "Player"
                {
                    return new Vector2Int(x, y);
                } //プレイヤーを見つけた
            }
        }
        return new Vector2Int(-1, -1);
    }

    void PrintArray()
    {
        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }

            debugText += "\n";
        }

        Debug.Log(debugText);
    }

    void Start()
    {
        map = new int[,]
        {
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 1, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 2, 0 }
        };

        PrintArray();

        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    instance =
                        Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                    break;
                }
                if (map[y, x] == 2)
                {
                    instance =
                        Instantiate(boxPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                } 
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, playerPosition + Vector2Int.right);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, playerPosition + Vector2Int.left);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2Int playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, playerPosition - Vector2Int.up);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2Int playerPosition = GetPlayerIndex();
            MoveNumber(playerPosition, playerPosition - Vector2Int.down);
            PrintArray();
        }
    }
}