using UnityEngine;
using UnityEngine.UI;
using YG;

public class EndLevel : MonoBehaviour
{
    static private GameObject _thisMenu;
    static public string AllLevels = "";
    [SerializeField] private StartingMenu _startMenu;
    [SerializeField] private SaveGame _savingGame;
    [SerializeField] private Text _textEntryMoney;
    [SerializeField] private Text TextPlusMoney;
    static private bool _isLevelFirstWin = false;

    private void Awake()
    {
        _thisMenu = gameObject;
        _thisMenu.SetActive(false);
    }
    private void FixedUpdate()
    {
        _textEntryMoney.text = ShopMenu.Money + "";
        if (_isLevelFirstWin) TextPlusMoney.text = "+1";
        else TextPlusMoney.text = "+0";
    }
    static public void OpenMenu(bool _isLevel)
    {
        _isLevelFirstWin = _isLevel;
        _thisMenu.SetActive(true);
    }
    public void CloseMenu()
    {
        _thisMenu.SetActive(false);
        _savingGame.MySave();
    }
    public void ExampleOpenRewardAd()
    {
        YandexGame.RewVideoShow(1);
    }
    public void ClickButton(int index)
    {
        _startMenu.ButtonClickManager(index);
    }
}
