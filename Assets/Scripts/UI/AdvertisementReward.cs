using UnityEngine;
using YG;

public class AdvertisementReward : MonoBehaviour
{
    // Подписываемся на событие открытия рекламы в OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    // Подписанный метод получения награды
    private void Rewarded(int id)
    {
        // Если ID = 1, то выдаём "x2 монет"
        if (id == 1)
            AddDoubleMoney();

        // Если ID = 2, то выдаём "hz".
        else if (id == 2)
            print("id = 2");
    }

    // Метод для вызова видео рекламы
    /*public void ExampleOpenRewardAd(int id)
    {
        // Вызываем метод открытия видео рекламы
        YandexGame.RewVideoShow(id);
    }*/

    private void AddDoubleMoney()
    {
        ShopMenu.Money++;
    }
}
