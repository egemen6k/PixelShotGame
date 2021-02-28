using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    private MeshRenderer _mr;
    private LineRenderer _lr;
    private Touch touch;
    private Vector3 _stickPositionHolder,_startPos3D, _endPos3D;
    private AudioSource _launchingSound;

    [SerializeField]
    private Transform _stick;
    [SerializeField]
    private bool isShoot = false;
    [SerializeField]
    private float forceMultiplier;
    [SerializeField]
    private float _stickSpeedModifier = 0.1f;

    void Start()
    {
        NullCheckProcess();
    }

    private void Update()
    {

        //Velocity limiting for solving ultra bouncing speed bugs
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -25f, 25f), Mathf.Clamp(_rb.velocity.y, -25f, 25f), 0);

        if (Input.touchCount > 0 && isShoot == false)
        {
            TouchController();
        }
    }

    void TouchController()
    {
        touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                _stickPositionHolder = _stick.position;
                _startPos3D = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                break;

            case TouchPhase.Moved:
                //Visual rendering
                VisualOnDrag();

                //Movement
                //Temprorary variable for manipulating _stick.position
                Vector3 _placeHolderPos = _stick.position;

                //Stick touch movement calculations in unit time
                _placeHolderPos.x += (touch.deltaPosition.x * Time.deltaTime * _stickSpeedModifier);
                _placeHolderPos.y += (touch.deltaPosition.y * Time.deltaTime * _stickSpeedModifier);
                _stick.position = _placeHolderPos;
                break;

            case TouchPhase.Ended:
                //Visual rendering
                VisualOnRelease();

                //Reset stick position
                _stick.position = _stickPositionHolder;

                //Apply force with touch input vector
                _endPos3D = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                Vector3 _direction = _startPos3D - _endPos3D;
                Shoot(_direction);
                break;
        }
    }

    void Shoot(Vector3 direction)
    {
        _rb.isKinematic = false;
        isShoot = true;

        //Limiting applying force for first frame huge blasts
        Vector3 _force = direction * forceMultiplier;
        Vector3 Force = new Vector3(Mathf.Clamp(_force.x,-1000f,+1000f), Mathf.Clamp(_force.y,-1750,+1750),0);
        _rb.AddForce(Force);
        _launchingSound.Play();
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

    public void NewBall()
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        gameObject.transform.position = new Vector3(0, -4, 0);
        _stick.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(ActivateTouch());
    }

    IEnumerator ActivateTouch()
    {
        yield return new WaitForEndOfFrame();
        isShoot = false;
    }

    private void NullCheckProcess()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb != null)
        {
            //Starting position
            _rb.isKinematic = true;
        }

        _mr = GetComponent<MeshRenderer>();
        if (_mr == null)
        {
            Debug.LogError("MR is null");
        }

        _lr = GetComponent<LineRenderer>();
        if (_lr == null)
        {
            Debug.LogError("LR is null");
        }

        _launchingSound = GetComponent<AudioSource>();
        if (_launchingSound == null)
        {
            Debug.LogError("Audio Source is null");
        }
    }

}

