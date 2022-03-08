using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    bool isAlt;

    public CameraState CameraType;
    public enum CameraState
    {
        TPS,
        FPS
    }
    private void Start()
    {
        Managers._Input.KeyAction -= RotateCamera;
        Managers._Input.KeyAction += RotateCamera;
    }

    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x , Player.transform.position.y + 2.5f, Player.transform.position.z - 2f);
    }

    void RotateCamera()
    {

    }
}
