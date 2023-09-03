using UnityEngine;

public class ReceivedSignalToWin : MonoBehaviour
{
    public bool _isWin { get; private set; }
    private AudioSource _audioSource;

    private void Start()
    {
        _isWin = false;
        _audioSource = GetComponent<AudioSource>();
        SoundsManager.CheckMuteSounds(_audioSource);
    }
    public void ReceivedSignalForWin()
    {
        gameObject.GetComponentInParent<Map>().LevelWin();
        _audioSource.Play();
        print("Победа");
    }

    public void CancelSignal()
    {
        _isWin = false;
    }
}
