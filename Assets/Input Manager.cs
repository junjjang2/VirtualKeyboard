using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using VKey;

public class InputManager : MonoBehaviour, VirtualKeyboard.IVKeyboardActions
{
    [SerializeField] VKeyboardManager vKeyboardManager;
    
    // Start is called before the first frame update
    private void Awake()
    {
        VirtualKeyboard vKeyboard = new VirtualKeyboard();
        vKeyboard.VKeyboard.SetCallbacks(this);
        vKeyboard.VKeyboard.Enable();
    }

    #region Input Event Handlers
    public void OnLeftJoystick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Left Joystick: " + context.ReadValue<Vector2>());
            var dir = context.ReadValue<Vector2>();
            if (dir.x > 0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveInput(KeyDirection.Right);
            }
            else if (dir.x < -0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveInput(KeyDirection.Left);
            }
            else if (dir.y > 0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveInput(KeyDirection.Up);
            }
            else if (dir.y < -0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveInput(KeyDirection.Down);
            }
        }
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vKeyboardManager.vKeyboard.ReceiveInput(KeyDirection.Click);
        }
    }

    public void OnRightJoystick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Right Joystick: " + context.ReadValue<Vector2>());
            var dir = context.ReadValue<Vector2>();
            if (dir.x > 0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveVowelInput(KeyDirection.Right);
            }
            else if (dir.x < -0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveVowelInput(KeyDirection.Left);
            }
            else if (dir.y > 0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveVowelInput(KeyDirection.Up);
            }
            else if (dir.y < -0.5f)
            {
                vKeyboardManager.vKeyboard.ReceiveVowelInput(KeyDirection.Down);
            }
        }
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vKeyboardManager.vKeyboard.ReceiveVowelInput(KeyDirection.Click);
        }
    }

    public void OnLeftPrim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vKeyboardManager.vKeyboard.MoveToNextLayer();
        }
    }

    public void OnLeftSecondary(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vKeyboardManager.vKeyboard.MoveToPreviousLayer();
        }
    }

    public void OnRightPrim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vKeyboardManager.vKeyboard.Delete();
        }
    }

    public void OnRightSecondary(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            vKeyboardManager.vKeyboard.NextLine();
        }
    }
    #endregion
}
