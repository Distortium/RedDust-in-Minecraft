using UnityEngine;
using YG;

public class AdvertisementReward : MonoBehaviour
{
    // ������������� �� ������� �������� ������� � OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    // ������������ �� ������� �������� ������� � OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    // ����������� ����� ��������� �������
    private void Rewarded(int id)
    {
        // ���� ID = 1, �� ����� "x2 �����"
        if (id == 1)
            AddDoubleMoney();

        // ���� ID = 2, �� ����� "hz".
        else if (id == 2)
            print("id = 2");
    }

    // ����� ��� ������ ����� �������
    /*public void ExampleOpenRewardAd(int id)
    {
        // �������� ����� �������� ����� �������
        YandexGame.RewVideoShow(id);
    }*/

    private void AddDoubleMoney()
    {
        ShopMenu.Money++;
    }
}
