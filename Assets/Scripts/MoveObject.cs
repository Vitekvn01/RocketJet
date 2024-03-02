using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{


    [SerializeField] Vector3 movePosition;
    [SerializeField] float moveSpeed;
    [SerializeField][Range(0, 1)] float moveProgress; // ранж позунок 0 - не обьект не двтгался 1 - обьект поностью двигался
    Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1); // Mathf - систем класс мат функций, time - системный класс времени
        Vector3 offset = movePosition * moveProgress;
        transform.position = startPosition + offset;
    }
}
