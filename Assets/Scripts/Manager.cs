using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject _candle;
    [SerializeField] private GameObject _cat;
    [SerializeField] public int _age;
    [SerializeField] public string _name;
    [SerializeField] private TMP_Text greatingText;


    private IEnumerator InstantiateCandle()
    {
        Instantiate(_candle, new Vector3(Random.Range(-4, 4), 0f, _cat.transform.position.z + Random.Range(1, 3)), _candle.transform.rotation);
        yield return new WaitForSeconds(2f);
        StartCoroutine("InstantiateCandle");
    }
    public void GreatingInstantiation(Vector3 pos)
    {
        greatingText.gameObject.transform.localPosition = pos;
        greatingText.text += $"Happy {_age} years, {_name}! <3";
    }
}
