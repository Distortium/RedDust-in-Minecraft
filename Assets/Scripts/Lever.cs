using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private List<Collider> _sendSignal = new List<Collider>();
    private bool _isActiveted = false;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        SoundsManager.CheckMuteSounds(_audioSource);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<ConnectedWrite>())
        {
            _sendSignal.Add(collider);
        }
    }
    private void OnMouseDown()
    {
        _audioSource.Play();
        _isActiveted = !_isActiveted;
        if (_isActiveted)
        {
            foreach (Collider item in _sendSignal)
            {
                item.gameObject.GetComponent<ConnectedWrite>().ReceivedSignal();
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
                item.gameObject.GetComponent<ConnectedWrite>().CancelSignal();
            }
            foreach (Transform child in transform)
            {
                child.localPosition = new Vector3(0, child.position.y, -0.2f);
                child.rotation = Quaternion.Euler(-9, 0, 0);
            }
        }
    }
}
