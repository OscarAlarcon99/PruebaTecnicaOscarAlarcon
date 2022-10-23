using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class CharacterInput : Singleton<CharacterInput>
{
    /// <summary>
    /// variable que almacena el valor tomado por el input system sobre movimiento del jugador. 
    /// </summary>
    public Vector2 deltaMove;

    /// <summary>
    /// variable que almacena el valor tomado por el input system sobre la vista del jugador. 
    /// </summary>
    public Vector2 deltaLook;
    public Vector2 deltaLookAim;
    public Vector2 fingerPosition;
    /// <summary>
    /// variable que almacena el componente encargado del input system del jugador. 
    /// </summary>
    InputPlayer input;

    /// <summary>
    /// variable que almacena el valor tomado por el input system sobre movimiento del jugador en el eje horizontal. 
    /// </summary>
    float _horizontalInput;
    /// <summary>
    /// variable que almacena el valor tomado por el input system sobre movimiento del jugador en el eje vertical. 
    /// </summary>
    float _verticalInput;
    /// <summary>
    /// variable que almacena sensibilidad de camara en el eje vertical. 
    /// </summary>
    public float sensitivityX;
    /// <summary>
    /// variable que almacena sensibilidad de camara en el eje horizontal. 
    /// </summary>
    public float sensitivityY;

    /// <summary>
    /// variable que almacena el valor tomado por el input system sobre camara del jugador en el eje horizontal. 
    /// </summary>

    private float _horizontalCameraInput;
    /// <summary>
    /// variable que almacena el valor tomado por el input system sobre camara del jugador en el eje vertical. 
    /// </summary>
    private float _verticalCameraInput;

    public bool touch;

    public delegate void StartTouch(Vector2 position);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position);
    public event EndTouch OnEndTouch;

    public Camera maincamera;
    public Image fingerPositionImage;
    /// <summary>
    /// Funcion que desactiva funcionalidad de input. 
    /// </summary>
    public void Desactivate()
    {
        _horizontalInput = 0;
        _verticalInput = 0;
        deltaMove = deltaLookAim = deltaLook = Vector2.zero;
    }
    /// <summary>
    /// Funcion que recibe valor de input de movimiento. 
    /// </summary>
    public void GetInput()
    {
        if (ScenesManager.Instance)
        {
            touch = ScenesManager.Instance.touchdBuild;
        }


        if (touch)
        {
            deltaMove = input.PlayerMovementTouch.Move.ReadValue<Vector2>();
            deltaLookAim = input.PlayerMovement.LookAim.ReadValue<Vector2>();

            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("sssssssssssssssssssssss");
                return;
            }
            else
            {
                deltaLook = input.PlayerMovementTouch.Look.ReadValue<Vector2>();
                fingerPosition = input.PlayerMovementTouch.PrimaryTouchPosition.ReadValue<Vector2>();
            }


            if (fingerPositionImage.gameObject.activeInHierarchy)
            {
                fingerPositionImage.rectTransform.position = fingerPosition;
            }
        }
        else
        {
            deltaMove = input.PlayerMovement.Move.ReadValue<Vector2>();
            deltaLook = input.PlayerMovement.Look.ReadValue<Vector2>();
        }
    }


    public bool PauseKeyIsPressed()
    {
        if (touch)
        {
            return input.PlayerMovementTouch.Pause.triggered;
        }
        else
        {
            return input.PlayerMovement.Pause.triggered;

        }
    }
    /// <summary>
    /// Funcion que recibe valor de input de salto. 
    /// </summary>
    public bool IsJumpKeyPressed()
    {
        if (touch)
        {
            return input.PlayerMovementTouch.Jump.triggered;
        }
        else
        {
            return input.PlayerMovement.Jump.triggered;
        }
    }
    /// <summary>
    /// Funcion que recibe valor de input de action. 
    /// </summary>
    public bool IsActionPressed()
    {
        if (touch)
        {
            return input.PlayerMovementTouch.Action.triggered;
        }
        else
        {
            return input.PlayerMovement.Action.triggered;
        }
    }
    /// <summary>
    /// Funcion que retorna el valor de input de salto en el eje horizontal. 
    /// </summary>
    public float GetHorizontalMovementInput()
	{
        _horizontalInput = deltaMove.x;
		return _horizontalInput;
	}
    /// <summary>
    /// Funcion que retorna el valor de input de salto en el eje vertical. 
    /// </summary>
    public float GetVerticalMovementInput()
	{
        _verticalInput = deltaMove.y;
		return _verticalInput;
	}
    /// <summary>
    /// Funcion que retorna el valor de input de camara en el eje horizontal. 
    /// </summary>
    public float GetHorizontalCameraInput()
    {
        if (touch)
        {
            _horizontalCameraInput = deltaLook.x * sensitivityX;
            return _horizontalCameraInput;
        }
        else
        {
            _horizontalCameraInput = deltaLook.x;
            return _horizontalCameraInput;
        }
    }
    /// <summary>
    /// Funcion que retorna el valor de input de camara en el eje vertical. 
    /// </summary>
    public float GetVerticalCameraInput()
    {
        if (touch)
        {
            if (true)
            {
                return _verticalCameraInput = deltaLook.y * sensitivityY;
            }
            else
            {
                return _verticalCameraInput = deltaLookAim.y * sensitivityY;
            }
        }
        else
        {
            return _verticalCameraInput = deltaLook.y;
        }
    }

    public void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        if (OnStartTouch != null || Player.Instance.IsActive)
        {
            if (EventSystem.current.IsPointerOverGameObject(PointerInputModule.kFakeTouchesId))
            {
                Debug.Log("Clicked on the UI");
            }
            else
            {
                OnStartTouch(Utils.ScreenToWorld(maincamera, input.PlayerMovementTouch.PrimaryTouchPosition.ReadValue<Vector2>()));
            }
        }
    }

    public void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null)
        {
            if (EventSystem.current.IsPointerOverGameObject(PointerInputModule.kFakeTouchesId))
            {
                Debug.Log("Clicked on the UI");
            }
            else
            {
                OnEndTouch(Utils.ScreenToWorld(maincamera, input.PlayerMovementTouch.PrimaryTouchPosition.ReadValue<Vector2>()));
            }
        }
    }

    //private void Start()
    //{
    //    input.PlayerMovementTouch.PrimaryTouchContact.started += ctx => StartTouchPrimary(ctx);
    //    input.PlayerMovementTouch.PrimaryTouchContact.canceled += ctx => EndTouchPrimary(ctx);
    //}

    private void OnEnable()
    {
        input = new InputPlayer();
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
