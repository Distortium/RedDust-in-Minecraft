using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSignal : MonoBehaviour
{

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<ConnectedWrite>())
        {
            collider.gameObject.GetComponent<ConnectedWrite>().ReceivedSignal();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<ConnectedWrite>())
        {
            collider.gameObject.GetComponent<ConnectedWrite>()._isActiveRed = false;
        }
    }
}
