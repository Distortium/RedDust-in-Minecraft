using UnityEngine;
using YG;

public class SaveGame : MonoBehaviour
{
    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled == true)
        {
            // Если запустился, то выполняем Ваш метод для загрузки
            GetLoad();

            // Если плагин еще не прогрузился, то метод не выполнится в методе Start,
            // но он запустится при вызове события GetDataEvent, после прогрузки плагина
        }
    }

    // Ваш метод для загрузки, который будет запускаться в старте
    public void GetLoad()
    {
        // Получаем данные из плагина и делаем с ними что хотим
        // Например, мы хотил записать в компонент UI.Text сколько у игрока монет:
        //textMoney.text = YandexGame.savesData.money.ToString();
        ShopMenu.Money = YandexGame.savesData.money;
        EndLevel.AllLevels = YandexGame.savesData.levels;
        ShopMenu.AllBuyingItem = YandexGame.savesData.buyItem;
    }

    // Допустим, это Ваш метод для сохранения
    public void MySave()
    {
        // Записываем данные в плагин
        // Например, мы хотил сохранить количество монет игрока:
        //YandexGame.savesData.money = money;
        YandexGame.savesData.money = ShopMenu.Money;
        YandexGame.savesData.levels = EndLevel.AllLevels;
        YandexGame.savesData.buyItem = ShopMenu.AllBuyingItem;

        // Теперь остаётся сохранить данные
        YandexGame.SaveProgress();
    }
}
