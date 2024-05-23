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
        //�ړI�n�ɓ������Ă����珈�����Ȃ�
        if(origin == destination) { return; }
        //���Ԍo�߂����Z
        elapsedTime += Time.deltaTime;
        //�o�ߎ��Ԃ��������Ԃ̉��������Z�o
        float timeRate = elapsedTime / duration;
        //�������Ԃ𒴂���悤�ł���Ύ��s�������ԑ����Ɋۂ߂�B
        if(timeRate > 1) { timeRate = 1; }

        //���W���Z�o
        Vector3 currentPosition = Vector3.Lerp(origin, destination, timeRate);
        //�Z�o�������W��position�ɑ��
        transform.position = currentPosition;
    }
}
