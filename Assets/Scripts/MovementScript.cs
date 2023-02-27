using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private Animator _catAnimator;
    [SerializeField] private GameObject _cake;
    [SerializeField] private Transform tr;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Manager _manager;
    [SerializeField] private GameObject _road;
    [SerializeField] private GameObject _activeroad;
    [SerializeField] private Renderer _pathrenderer;

    private int age;
    private Vector3 _roadSize;
    private int score = 0;
    private float speed = 20f;
    private int _sizePath = 11;

    private void Awake()
    {
        scoreText.text += score;
        _roadSize = _pathrenderer.GetComponent<MeshRenderer>().bounds.size;
    }
    public void SetAge()
    {
        Debug.Log($"manager {_manager==null}");
        age = _manager._age;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
            _catAnimator.Play("Walk");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -0.3f * speed * Time.deltaTime, 0);
            //this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Translate(-Vector3.right * Time.deltaTime, Space.World);
            // this.transform.Translate(-Vector3.right * Time.deltaTime);
            _catAnimator.Play("Walk");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0.3f * speed * Time.deltaTime, 0);
            //this.transform.Translate(Vector3.forward * Time.deltaTime);
            this.transform.Translate(Vector3.right * Time.deltaTime, Space.World);

            //this.transform.Translate(Vector3.right * Time.deltaTime);
            _catAnimator.Play("Walk");
        }

        if(transform.position.z >= _activeroad.transform.position.z)
        {
            Vector3 pos = _activeroad.transform.position + new Vector3(0f,0f, _roadSize.z);
            _activeroad = Instantiate(_road, pos, _activeroad.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (score < age)
        {
            scoreText.text = scoreText.text.Replace($"{score.ToString()}", "");
            score++;
            scoreText.text += score;
            CheckIfEnoughCandkes();
        }
    }
    private void CheckIfEnoughCandkes()
    {
        if (score >= age)
        {
            Vector3 pos = transform.position + new Vector3(0f, 0f, 3f);
            Instantiate(_cake, pos, transform.rotation);
            _manager.GreatingInstantiation((pos + new Vector3(0f, 2f, 0f)));
            _manager.StopAllCoroutines();
        }
    }
}
