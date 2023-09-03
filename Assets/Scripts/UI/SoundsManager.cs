using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioClip[] _musicClips;
    static public List<AudioSource> _soundsAudioSource = new List<AudioSource>();
    [SerializeField] private Image _imageButtonMuteMusic, _imageButtonMuteSounds;
    [SerializeField] private Sprite[] _spritesButtonMuteMusic, _spritesButtonMuteSounds;
    [SerializeField] private StartingMenu _startingMenuAudioSource;
    private static int _soundsVolume = 1;
    private bool _isPlayingSounds = true;
    private bool _isPlayingMusic = true;
    private int _musicIndex = 0;


    static public void CheckMuteSounds(AudioSource _audio)
    {
        _audio.volume = _soundsVolume;
    }

    public void ButtonSoundsMute()
    {
        _isPlayingSounds = !_isPlayingSounds;
        if (_isPlayingSounds)
        {
            foreach (AudioSource sound in _soundsAudioSource)
            {
                _soundsVolume = 1;
                sound.volume = 1;
                _imageButtonMuteSounds.sprite = _spritesButtonMuteSounds[1];
            }
        }
        else
        {
            foreach(AudioSource sound in _soundsAudioSource)
            {
                _soundsVolume = 0;
                sound.volume = 0;
                _imageButtonMuteSounds.sprite = _spritesButtonMuteSounds[0];
            }
        }
    }
    public void ButtonMusicMute()
    {
        _startingMenuAudioSource._audioSource.Play();
        _isPlayingMusic = !_isPlayingMusic;
        if (_isPlayingMusic)
        {
            _musicAudioSource.volume = 1;
            _imageButtonMuteMusic.sprite = _spritesButtonMuteMusic[1];
        }
        else 
        {
            _musicAudioSource.volume = 0;
            _imageButtonMuteMusic.sprite = _spritesButtonMuteMusic[0];
        }
    }
    public void ButtonPreviousMusic()
    {
        _startingMenuAudioSource._audioSource.Play();
        if (_musicIndex >= 1)
        {
            _musicAudioSource.clip = _musicClips[_musicIndex];
            _musicAudioSource.Play();
            _musicIndex--;
        }
        else _musicIndex = _musicClips.Length - 1;
    }
    public void ButtonNextMusic()
    {
        _startingMenuAudioSource._audioSource.Play();
        if (_musicIndex < _musicClips.Length - 1)
        {
            _musicAudioSource.clip = _musicClips[_musicIndex];
            _musicAudioSource.Play();
            _musicIndex++;
        }
        else _musicIndex = 0;
    }
}
