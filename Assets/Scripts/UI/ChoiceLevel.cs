using UnityEngine;
using UnityEngine.UI;

public class ChoiceLevel : MonoBehaviour
{
    [SerializeField] private int _indexLevel = 1;
    [SerializeField] private Image _imageStar;
    [SerializeField] private Sprite _spriteActiveStar;
    [SerializeField] private StartingMenu _gameManagerObject;
    private bool _findActivetedLevel = false;
    private bool _findActivetedButton = false;

    private void OnEnable()
    {
        bool _isTryLevel = true;
        string[] _allLevelsInString = EndLevel.AllLevels.Split('#');
        foreach (string itemLevel in _allLevelsInString)
        {
            if (itemLevel == "") break;
            if (int.Parse(itemLevel) == _indexLevel)
            {
                _isTryLevel = false;
                _findActivetedLevel = true;
            }
            else if (!_findActivetedLevel) _isTryLevel = true;
            int _prevIndexLevel = _indexLevel;
            _prevIndexLevel--;
            if (int.Parse(itemLevel) == _prevIndexLevel)
            {
                gameObject.GetComponent<Button>().interactable = true;
                _findActivetedButton = true;
            }
            else if (!_findActivetedButton) gameObject.GetComponent<Button>().interactable = false;
        }
        if (!_isTryLevel)
        {
            // Если этот уровень пройден
            _imageStar.sprite = _spriteActiveStar;
        }
    }

    public void LevelClick()
    {
        _gameManagerObject._audioSource.Play();
        _gameManagerObject.StartLevel(_indexLevel);
    }
}
