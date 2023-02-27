using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUpWindow : MonoBehaviour
{
    [SerializeField] GameObject _cat;
    [SerializeField] TMP_InputField _setName;
    [SerializeField] TMP_InputField _setAge;
    [SerializeField] Image _setUpWindow;
    [SerializeField] Button _setupReady;
    [SerializeField] Manager _manager;

    void Awake()
    {
        _setupReady.onClick.AddListener(CheckIfFilledUp);
    }
    private void CheckIfFilledUp()
    {
        if(_setName.text!=null && _setAge.text!=null)
        {
            int value;
            if(int.TryParse(_setAge.text, out value))
            {
                _manager._age = value;
                _manager._name = _setName.text;
                _setUpWindow.gameObject.SetActive(false);
                _cat.SetActive(true);
                _cat.gameObject.transform.parent.GetComponent<MovementScript>().SetAge();
                _manager.StartCoroutine("InstantiateCandle");
            }
        }
    }
}
