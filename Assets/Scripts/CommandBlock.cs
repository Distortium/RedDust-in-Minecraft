using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBlock : MonoBehaviour
{
    [SerializeField] private Texture _disableRedstoneLamp, _activeRedstoneLamp;
    private Renderer _Renderer;

    [SerializeField] private Transform _spawnPos;
    [SerializeField] private GameObject _spawnObject;
    private GameObject _object;
    private AudioSource _audioSource;

    private void Start()
    {
        _Renderer = GetComponent<Renderer>();
        _audioSource = GetComponent<AudioSource>();
        SoundsManager.CheckMuteSounds(_audioSource);
        if (!_spawnPos) Debug.LogError("Empty spawnPos!");
        if (!_spawnObject) Debug.LogError("Empty spawnObject!");
    }
    public void ReceivedSignal()
    {
        if (!_object)
        {
            _audioSource.Play();
            _object = Instantiate(_spawnObject, _spawnPos.position, Quaternion.identity, _spawnPos);
            _Renderer.material.SetTexture("_MainTex", _activeRedstoneLamp);
        }
    }
    public void CancelSignal()
    {
        _audioSource.Play();
        _Renderer.material.SetTexture("_MainTex", _disableRedstoneLamp);
        Destroy(_object);
    }
}
