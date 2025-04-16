using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<bool> PrimaryFireEvent;
    public event Action<Vector2> MoveEvent;

    private Controls controls;

    private void OnEnable() //������ Start() ��� ScriptableObject
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this); //� controls.Player ���� ����� SetCallbacks(), ������� ��������� ������, ����������� ��������� IPlayerActions. �� �������� this � �� ���� ������� ������ InputReader, ������� ��� ��������� ��������� IPlayerActions.  ��� ������, ��� ������ ��� ������� ����� OnMove, OnJump, OnPrimaryFire ����� ������������� ���������� � ���� ScriptableObject��, ���� Input System �� ��������������.
        }

        controls.Player.Enable();//�������� ����� ������ � action maps
    }

    public void OnMove(InputAction.CallbackContext context)
    {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PrimaryFireEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            PrimaryFireEvent?.Invoke(false);
        }
    }
}
