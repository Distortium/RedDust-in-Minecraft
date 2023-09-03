using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    static public int Money = 0;
    static public string AllBuyingItem = "0#";
    [SerializeField] private Text _textMoney;
    [SerializeField] private SaveGame _savingGame;
    [SerializeField] private Material[] _gameSkins;
    static public Material _skinGroundUse;


    public void BuyItemOrUseId(int _indexItem, int _costItem)
    {
        bool _isTrueItem = false;
        string[] _allBuyingItemsInString = AllBuyingItem.Split('#');
        foreach (string item in _allBuyingItemsInString)
        {
            if (AllBuyingItem == "") break;
            else if (item != "" && int.Parse(item) == _indexItem)
            {
                _isTrueItem = true;
                break;
            }
            else _isTrueItem = false;
        }
        // Если нажатый предмет не куплен
        if (!_isTrueItem && Money >= _costItem)
        {
            Money -= _costItem;
            AllBuyingItem += _indexItem + "#";
        }
        else if (_isTrueItem)
        {
            _skinGroundUse = _gameSkins[_indexItem];
        }
        _savingGame.MySave();
    }

    private void FixedUpdate()
    {
        _textMoney.text = "" + Money;
    }
}
