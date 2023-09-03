using UnityEngine;

public class PistonWire : MonoBehaviour
{
    [SerializeField] private Transform _objectForMove;
    [SerializeField] private Transform _forwardObject;
    [SerializeField] private Transform _positionObjectToMove;
    [SerializeField] private bool _isSticky = true;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        SoundsManager.CheckMuteSounds(_audioSource);
    }
    public void ReceivedSignal()
    {
        _forwardObject.transform.localPosition = _positionObjectToMove.transform.localPosition;
        if (!_isSticky) _objectForMove.transform.parent = gameObject.transform.parent;
        _audioSource.Play();
    }
    public void CancelSignal()
    {
        _forwardObject.transform.localPosition = new Vector3(0, 0, 0.525f);
        _audioSource.Play();
    }
}
