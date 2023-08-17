using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivedSignalToWin : MonoBehaviour
{
    //[SerializeField] private Texture _disableRedstoneLamp, _activeRedstoneLamp;
    //private Renderer _Renderer;

    private void Start()
    {
        //_Renderer = GetComponent<Renderer>();
    }
    public void ReceivedSignalForWin()
    {
        //_Renderer.material.SetTexture("_MainTex", _activeRedstoneLamp);
        print("Победа");
    }
}
