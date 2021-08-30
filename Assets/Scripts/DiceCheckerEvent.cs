using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DiceCheckerEvent : MonoBehaviour
{
    [SerializeField] private string _expectedDice;
    private XRSocketInteractor _socket;

    public bool isDiceCorrect = false;
    private void Awake()
    {
        _socket = gameObject.GetComponent<XRSocketInteractor>();
        _socket.selectEntered.AddListener(CheckDiceIn);
        _socket.selectExited.AddListener(UpdateDiceOut);
    }
    private void UpdateDiceOut(SelectExitEventArgs obj)
    {
        isDiceCorrect = false;
    }
    private void CheckDiceIn(SelectEnterEventArgs obj)
    {
        if (obj.interactable.gameObject.CompareTag(_expectedDice))
        {
            isDiceCorrect = true;
        }
    }

    private void OnDestroy()
    {
        _socket.selectEntered.RemoveListener(CheckDiceIn);
        _socket.selectExited.RemoveListener((UpdateDiceOut));    
    }
}
