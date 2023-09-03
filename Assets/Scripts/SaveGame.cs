using UnityEngine;
using YG;

public class SaveGame : MonoBehaviour
{
    // ������������� �� ������� GetDataEvent � OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    // ������������ �� ������� GetDataEvent � OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        // ��������� ���������� �� ������
        if (YandexGame.SDKEnabled == true)
        {
            // ���� ����������, �� ��������� ��� ����� ��� ��������
            GetLoad();

            // ���� ������ ��� �� �����������, �� ����� �� ���������� � ������ Start,
            // �� �� ���������� ��� ������ ������� GetDataEvent, ����� ��������� �������
        }
    }

    // ��� ����� ��� ��������, ������� ����� ����������� � ������
    public void GetLoad()
    {
        // �������� ������ �� ������� � ������ � ���� ��� �����
        // ��������, �� ����� �������� � ��������� UI.Text ������� � ������ �����:
        //textMoney.text = YandexGame.savesData.money.ToString();
        ShopMenu.Money = YandexGame.savesData.money;
        EndLevel.AllLevels = YandexGame.savesData.levels;
        ShopMenu.AllBuyingItem = YandexGame.savesData.buyItem;
    }

    // ��������, ��� ��� ����� ��� ����������
    public void MySave()
    {
        // ���������� ������ � ������
        // ��������, �� ����� ��������� ���������� ����� ������:
        //YandexGame.savesData.money = money;
        YandexGame.savesData.money = ShopMenu.Money;
        YandexGame.savesData.levels = EndLevel.AllLevels;
        YandexGame.savesData.buyItem = ShopMenu.AllBuyingItem;

        // ������ ������� ��������� ������
        YandexGame.SaveProgress();
    }
}
