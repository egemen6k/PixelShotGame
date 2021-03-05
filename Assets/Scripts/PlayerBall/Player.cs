using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private MeshRenderer _mr;
    private LineRenderer _lr;
    //private Touch touch;
    private Vector3 _stickPositionHolder;/*,_startPos3D, _endPos3D;*/
    private AudioSource _launchingSound;

    [SerializeField]
    private Transform _stick;
    //[SerializeField]
    //private bool isShoot = false;
    //[SerializeField]
    //private float forceMultiplier;
    //[SerializeField]
    //private float _stickSpeedModifier = 0.1f;

    void Start()
    {
        NullCheckProcess();
    }

    private void Update()
    {

        //Velocity limiting for solving ultra bouncing speed bugs

        //Debug.Log(_rb.velocity);
    }

   

    private void VisualOnDrag()
    {
        _mr.enabled = false;
        _lr.enabled = true;
        _lr.SetPosition(0, _stickPositionHolder);
        _lr.SetPosition(1, _stick.position);
    }

    private void VisualOnRelease()
    {
        _lr.enabled = false;
        _mr.enabled = true;
        _stick.GetComponent<MeshRenderer>().enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    //public void NewBall()
    //{
    //    _rb.velocity = Vector3.zero;
    //    _rb.isKinematic = true;
    //    gameObject.transform.position = new Vector3(0, -4, 0);
    //    //_stick.GetComponent<MeshRenderer>().enabled = true;
    //    StartCoroutine(ActivateTouch());
    //}

    //IEnumerator ActivateTouch()
    //{
    //    yield return new WaitForEndOfFrame();
    //    GetComponent<BallMovement>()._hasThrown = false;
    //}

    private void NullCheckProcess()
    {

        _mr = GetComponent<MeshRenderer>();
        if (_mr == null)
        {
            Debug.LogError("MR is null");
        }

        //_lr = GetComponent<LineRenderer>();
        //if (_lr == null)
        //{
        //    Debug.LogError("LR is null");
        //}

        _launchingSound = GetComponent<AudioSource>();
        if (_launchingSound == null)
        {
            Debug.LogError("Audio Source is null");
        }
    }

}

