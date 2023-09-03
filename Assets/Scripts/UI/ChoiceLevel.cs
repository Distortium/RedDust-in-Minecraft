using UnityEngine;
using UnityEngine.UI;

public class ChoiceLevel : MonoBehaviour
{
    [SerializeField] private int _indexLevel = 1;
    [SerializeField] private Image _imageStar;
    [SerializeField] private Sprite _spriteActiveStar;
    [SerializeField] private StartingMenu _gameManagerObject;

    private void OnEnable()
    {
        bool _isTryLevel = true;
        string[] _allLevelsInString = EndLevel.AllLevels.Split('#');
        foreach (string itemLevel in _allLevelsInString)
        {
            if (EndLevel.AllLevels == "") break;
            else if (int.Parse(itemLevel) == _indexLevel)
            {
                _isTryLevel = false;
                break;
            }
            else _isTryLevel = true;
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
