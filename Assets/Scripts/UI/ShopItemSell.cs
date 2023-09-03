using UnityEngine;
using UnityEngine.UI;

public class ShopItemSell : MonoBehaviour
{
    [SerializeField] private int _indexItem;
    [SerializeField] private int _costItem;
    [SerializeField] private ShopMenu _shopMenu;
    [SerializeField] private Text _textCostItem;
    private bool _itemBuying = false;

    private void Start()
    {
        ItemCheckInBuying();
    }

    private void ItemCheckInBuying()
    {
        _textCostItem.text = _costItem.ToString();
        string[] _allBuyingItemsInString = ShopMenu.AllBuyingItem.Split('#');
        foreach (string item in _allBuyingItemsInString)
        {
            if (ShopMenu.AllBuyingItem == "") break;
            else if (item != "" && int.Parse(item) == _indexItem)
            {
                _textCostItem.text = "";
                _itemBuying = true;
                break;
            }
        }
    }

    public void ButtonClick()
    {
        _shopMenu.BuyItemOrUseId(_indexItem, _costItem);
        if (!_itemBuying) ItemCheckInBuying();
    }
}
