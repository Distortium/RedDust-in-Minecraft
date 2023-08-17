using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonWire : MonoBehaviour
{
    [SerializeField] private Transform _objectForMove;
    [SerializeField] private Transform _forwardObject;
    [SerializeField] private Transform _positionObjectToMove;
    [SerializeField] private bool _isSticky = true;

    public void ReceivedSignal()
    {
        _forwardObject.transform.localPosition = _positionObjectToMove.transform.localPosition;
        if (!_isSticky) _objectForMove.transform.parent = null;
    }
    public void CancelSignal()
    {
        _forwardObject.transform.localPosition = new Vector3(0, 0, 0.525f);
    }
}
