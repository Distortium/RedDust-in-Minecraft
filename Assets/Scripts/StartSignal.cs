using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSignal : MonoBehaviour
{
    private List<Collider> _sendSignal = new List<Collider>();

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<ConnectedWrite>())
        {
            collider.gameObject.GetComponent<ConnectedWrite>().ReceivedSignal();
            _sendSignal.Add(collider);
        }
    }

    private void OnDestroy()
    {
        foreach (Collider item in _sendSignal)
        {
            item.GetComponent<ConnectedWrite>().CancelSignal();
        }
    }
}
