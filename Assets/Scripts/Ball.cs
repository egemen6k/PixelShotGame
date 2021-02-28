using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    GameObject _explosionPrefab;
    [SerializeField]
    private Material _mat;
    [SerializeField]
    private AudioClip _explosionSound;

    private AudioSource _bouncingSound;
    private Rigidbody _rb;
    private UIManager _uiManager;
    private bool _scorable = true;

    private void Start()
    {
        _bouncingSound = GetComponent<AudioSource>();
        if (_bouncingSound == null)
        {
            Debug.LogError("Audio source is null");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")
        {
            Rigidbody ball = other.transform.GetComponent<Rigidbody>();
            if (ball != null)
            {
                ball.useGravity = true;
            }

            MeshRenderer _mesh = GetComponent<MeshRenderer>();
            if (_mesh != null)
            {
                _mesh.material = _mat;
            }

            _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            if (_uiManager != null)
            {
                StartCoroutine(ScoreAndDestroy());
            }
        }

        if (other.transform.tag == "Player")
        {
            _rb = GetComponent<Rigidbody>();
            if (_rb != null)
            {
                _rb.useGravity = true;
            }

            MeshRenderer _mesh = GetComponent<MeshRenderer>();
            if (_mesh != null)
            {
                _mesh.material = _mat;
            }

            _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            if (_uiManager != null)
            {
                StartCoroutine(ScoreAndDestroy());
            }
        }
    }

    IEnumerator ScoreAndDestroy()
    {
        if (_scorable)
        {
            _uiManager.UpdateScore();
            _scorable = false;
            _bouncingSound.Play();
        }
        yield return new WaitForSeconds(5f);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_explosionSound, transform.position);
        Destroy(this.gameObject,0.2f);
    }
}
