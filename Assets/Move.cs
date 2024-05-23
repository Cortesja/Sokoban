using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float duration = 0.2f;
    float elapsedTime;
    Vector3 destination;
    Vector3 origin;
    public void MoveTo(Vector3 destination)
    {
        //transform.position = destination;
        elapsedTime = 0;
        origin = this.destination;
        transform.position = origin;
        this.destination = destination;
    }
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        origin = destination; 
    }

    // Update is called once per frame
    void Update()
    {
        //目的地に到着していたら処理しない
        if(origin == destination) { return; }
        //時間経過を加算
        elapsedTime += Time.deltaTime;
        //経過時間が完了時間の何割かを算出
        float timeRate = elapsedTime / duration;
        //完了時間を超えるようであれば実行完了時間相当に丸める。
        if(timeRate > 1) { timeRate = 1; }

        //座標を算出
        Vector3 currentPosition = Vector3.Lerp(origin, destination, timeRate);
        //算出した座標をpositionに代入
        transform.position = currentPosition;
    }
}
