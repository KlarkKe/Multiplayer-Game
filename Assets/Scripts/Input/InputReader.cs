using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private Controls controls;

    private void OnEnable() //Вместо Start() для ScriptableObject
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this); //У controls.Player есть метод SetCallbacks(), который принимает объект, реализующий интерфейс IPlayerActions. Ты передаёшь this — то есть текущий объект InputReader, который уже реализует интерфейс IPlayerActions.  Это значит, что теперь все события вроде OnMove, OnJump, OnPrimaryFire будут автоматически вызываться в этом ScriptableObject’е, если Input System их зарегистрирует.
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {

    }
}
