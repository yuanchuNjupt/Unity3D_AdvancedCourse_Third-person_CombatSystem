using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private static InputManager _instance = new InputManager();

    public static InputManager Instance => _instance;

    private MainInput mainInput;

    private InputManager()
    {
        mainInput = new MainInput();
        mainInput.Enable();
    }

    ~InputManager()
    {
        mainInput.Disable();
        mainInput = null;
    }

    public bool ATK => mainInput.GameInput.ATK.triggered;

    public bool Parry => mainInput.GameInput.Parry.phase == InputActionPhase.Performed;

    public Vector2 Move => mainInput.GameInput.Movement.ReadValue<Vector2>();

    public Vector2 CameraMove => mainInput.GameInput.CameraMove.ReadValue<Vector2>();






}
