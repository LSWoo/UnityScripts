using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagers : MonoBehaviour
{
    private Animator animator;

    Weapon.WeaponType weaponType;

    #region Move
    public MoveState moveType;
    public enum MoveState
    {
        Idle,
        Front,
        Left,
        Right,
        Back,
        Run
    }
    #endregion

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        Managers._Input.KeyAction -= Move;
        Managers._Input.KeyAction += Move;
    }
    void InputCheck(MoveState _state, KeyCode _key)
    {
        if (Input.GetKey(_key))
            moveType = _state;

        if (Input.GetKeyUp(_key))
            moveType = MoveState.Idle;
    }
    void SetAnimation(MoveState _state)
    {
        if (moveType == _state)
            animator.SetBool($"{_state}", true);
        else
            animator.SetBool($"{_state}", false);
    }
    void MoveStateCheck()
    {
        InputCheck(MoveState.Front, KeyCode.W);
        InputCheck(MoveState.Left, KeyCode.A);
        InputCheck(MoveState.Right, KeyCode.D);
        InputCheck(MoveState.Back, KeyCode.S);

        if (moveType == MoveState.Front || moveType == MoveState.Run)
            InputCheck(MoveState.Run, KeyCode.LeftShift);
    }
    void LookingPointer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float _CamerarayDistance = 100f;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground");

        if (Physics.Raycast(ray, out hit, _CamerarayDistance, layerMask))
        {
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 10, Color.red);
            Vector3 dir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = dir;
        }
    }
    void Move()
    {
        if (transform.position.y < 0)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        MoveStateCheck();
        LookingPointer();

        SetAnimation(MoveState.Front);
        SetAnimation(MoveState.Left);
        SetAnimation(MoveState.Right);
        // SetAnimation(MoveState.Back);
        if (moveType == MoveState.Run)
        {
            animator.SetBool("Front", true);
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);
    }
}
