using UnityEngine;
using YG;

public class StartingMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _containerLevels;
    [SerializeField] private GameObject _buttonsMenu;
    [SerializeField] private GameObject _buttonsChoiceLevel;
    [SerializeField] private GameObject _buttonsShop;
    private GameObject _thisLevel;
    private enum StateMenu {showChoiceLevels, showShop, showMenu }
    public AudioSource _audioSource;

    private void Awake()
    {
        SoundsManager._soundsAudioSource.Add(_audioSource);
        StateHideMenu(StateMenu.showMenu);
    }

    private void StateHideMenu(StateMenu menu)
    {
        gameObject.SetActive(true);
        switch (menu) 
        { 
            case StateMenu.showChoiceLevels:
                _buttonsMenu.SetActive(false);
                _buttonsChoiceLevel.SetActive(true);
                _buttonsShop.SetActive(false);
                break;
            case StateMenu.showShop:
                _buttonsMenu.SetActive(false);
                _buttonsChoiceLevel.SetActive(false);
                _buttonsShop.SetActive(true);
                break;
            case StateMenu.showMenu:
                _buttonsMenu.SetActive(true);
                _buttonsChoiceLevel.SetActive(false);
                _buttonsShop.SetActive(false);
                break;
        }
    }

    public void ButtonClickManager(int index)
    {
        _audioSource.Play();

        switch (index)
        {
            // ������� ��������� ����
            case 0:
                StateHideMenu(StateMenu.showMenu);
                break;
            // ���� ����� �������
            case 1:
                StateHideMenu(StateMenu.showChoiceLevels);
                break;
            // �������
            case 2:
                StateHideMenu(StateMenu.showShop);
                break;
            // ������� ����
            case 3:
                YandexGame.ReviewShow(true);
                break;
            // ������� ���������� ����
            case 4:
                YandexGame.ResetSaveProgress();
                break;
        }
    }

    public void StartLevel(int _level)
    {
        if (_thisLevel) Destroy( _thisLevel);
        _thisLevel = Instantiate(_containerLevels[_level - 1], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
