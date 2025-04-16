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

    private void OnEnable() //Вместо Start() для ScriptableObject
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this); //У controls.Player есть метод SetCallbacks(), который принимает объект, реализующий интерфейс IPlayerActions. Ты передаёшь this — то есть текущий объект InputReader, который уже реализует интерфейс IPlayerActions.  Это значит, что теперь все события вроде OnMove, OnJump, OnPrimaryFire будут автоматически вызываться в этом ScriptableObject’е, если Input System их зарегистрирует.
        }

        controls.Player.Enable();//включаем карту игрока в action maps
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
