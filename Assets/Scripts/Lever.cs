using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : MonoBehaviour
{
    private List<Collider> _sendSignal = new List<Collider>();
    private bool _isActiveted = false;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<ConnectedWrite>())
        {
            _sendSignal.Add(collider);
        }
    }
    private void OnMouseDown()
    {
        _isActiveted = !_isActiveted;
        if (_isActiveted)
        {
            foreach (Collider item in _sendSignal)
            {
                item.GetComponent<ConnectedWrite>().ReceivedSignal();
            }
            foreach (Transform child in transform)
            {
                child.localPosition = new Vector3(0, child.position.y, 0.2f);
                child.rotation = Quaternion.Euler(9, 0, 0);
            }
        }
        else
        {
            foreach (Collider item in _sendSignal)
            {
                item.GetComponent<ConnectedWrite>().CancelSignal();
            }
            foreach (Transform child in transform)
            {
                child.localPosition = new Vector3(0, child.position.y, -0.2f);
                child.rotation = Quaternion.Euler(-9, 0, 0);
            }
        }
    }
}
