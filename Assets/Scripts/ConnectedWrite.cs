using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectedWrite : MonoBehaviour
{
    //[SerializeField] private GameObject _nextWrite;
    public bool _isActiveRed = false;
    private ReceivedSignalToWin _scriptForWin;
    private PistonWire _scriptPiston;
    private CommandBlock _scriptCommandBlock;
    private enum GameState {startRed, endRed};

    private void Awake()
    {
        _scriptPiston = GetComponent<PistonWire>();
        _scriptCommandBlock = GetComponent<CommandBlock>();
        _scriptForWin = GetComponent<ReceivedSignalToWin>();
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<ConnectedWrite>())
        {
            if (_isActiveRed)
            {
                StartCoroutine(IEStateSingal(collider));
            }
        }
    }

    private void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.startRed:
                _isActiveRed = true;
                break;
            case GameState.endRed:
                _isActiveRed = false;
                break;
        }
    }
    public void ReceivedSignal()
    {
        SetGameState(GameState.startRed);
        StartMechanism();
    }
    public void CancelSignal()
    {
        if (_scriptPiston) _scriptPiston.CancelSignal();
        else if (_scriptCommandBlock) _scriptCommandBlock.CancelSignal();
    }

    private void StartMechanism()
    {
        if (_scriptPiston) _scriptPiston.ReceivedSignal();
        else if (_scriptCommandBlock) _scriptCommandBlock.ReceivedSignal();
        else if (_scriptForWin) _scriptForWin.ReceivedSignalForWin();
        else gameObject.GetComponent<Renderer>().material.color = Color.red;
    }


    IEnumerator IEStateSingal(Collider collider)
    {
        yield return new WaitForSeconds(0.3f);
        if (!collider.gameObject.GetComponent<ConnectedWrite>()._isActiveRed)
        {
            if (_isActiveRed) collider.gameObject.GetComponent<ConnectedWrite>().ReceivedSignal();
        }
        yield break;
    }
}
