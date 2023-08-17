using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedWrite : MonoBehaviour
{
    //[SerializeField] private GameObject _nextWrite;
    private bool _isActiveRed = false;
    private bool _isCancelRed = false;
    private ReceivedSignalToWin _scriptForWin;
    private PistonWire _scriptPiston;
    private CommandBlock _scriptCommandBlock;

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
                collider.gameObject.GetComponent<ConnectedWrite>().Invoke("ReceivedSignal", 0.3f);
            else if (_isCancelRed)
                collider.gameObject.GetComponent<ConnectedWrite>().CancelSignal();
        }
    }
    public void ReceivedSignal()
    {
        StartMechanism();
    }
    public void CancelSignal()
    {
        _isActiveRed = false;
        _isCancelRed = true;
        if (_scriptPiston) _scriptPiston.CancelSignal();
        else if (_scriptCommandBlock) _scriptCommandBlock.CancelSignal();
        else gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    private void StartMechanism()
    {
        _isActiveRed = true;
        if (_scriptPiston) _scriptPiston.ReceivedSignal();
        else if (_scriptCommandBlock) _scriptCommandBlock.ReceivedSignal();
        else if (_scriptForWin) _scriptForWin.ReceivedSignalForWin();
        else gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
