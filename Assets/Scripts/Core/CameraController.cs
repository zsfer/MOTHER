using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3[] CameraPositions;

    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CameraPositions[0] = transform.position;
    }

    public void MoveCameraPosition(int positionIndex)
    {
        var pos = CameraPositions[positionIndex];
        transform.position = new Vector3(pos.x, pos.y, -10);
    }


}
