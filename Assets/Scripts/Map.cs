using UnityEngine;
using YG;

public class Map : MonoBehaviour
{
    [SerializeField] private int _indexLevel = 1;
    [SerializeField] private GameObject _mapGround;


    private void Start()
    {
        YandexGame.FullscreenShow();
        if (ShopMenu._skinGroundUse) _mapGround.GetComponent<MeshRenderer>().material = ShopMenu._skinGroundUse;
    }
    public void LevelWin()
    {
        bool _isTryLevel = true;
        string[] _allLevelsInString = EndLevel.AllLevels.Split('#');
        foreach (string itemLevel in _allLevelsInString)
        {
            if (itemLevel == "") break;
            else if (int.Parse(itemLevel) == _indexLevel)
            {
                _isTryLevel = false;
                break;
            }
            else _isTryLevel = true;
        }
        if (_isTryLevel)
        {
            EndLevel.AllLevels += _indexLevel + "#";
            ShopMenu.Money++;
        }
        EndLevel.OpenMenu(_isTryLevel);
    }
}
