using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform ballTransform;
    private Vector3 offset;
    [SerializeField] private GameManager gameManager; 

    void Start()
    {
        offset = transform.position - ballTransform.position;        
    }

    void Update()
    {
        if (gameManager.GetGameOn())
            transform.position = ballTransform.position + offset;
    }
}
