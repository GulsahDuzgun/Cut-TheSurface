using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Inputs;
using CutTheSurface.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : IInputReader
{
    public float Horizontal { get; private set; }
    PlayerInput _playerInput;
    public bool IsJump { get; private set; }

    public InputReader(PlayerInput playerInput)
    {
        _playerInput = playerInput;
        //perform işlemin gerçekleştiği anlamına gelir
        _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
        //start butona basma anı ilk başlangıcı
        _playerInput.currentActionMap.actions[1].started += OnJump;
        //canceled ise işlemden çıkış anıdır
        _playerInput.currentActionMap.actions[1].canceled += OnJump;

    }

    void OnJump(InputAction.CallbackContext context)
    {
        IsJump = context.ReadValueAsButton();
    }

    void OnHorizontalMove(InputAction.CallbackContext context)
    {
        Horizontal = context.ReadValue<float>();
    }
}
















