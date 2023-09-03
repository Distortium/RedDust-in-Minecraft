using UnityEngine;

public class AddSoundInList : MonoBehaviour
{
    private void Start()
    {
        SoundsManager._soundsAudioSource.Add(GetComponent<AudioSource>());
    }

}
