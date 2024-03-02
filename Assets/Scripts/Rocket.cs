using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _rotSpeed = 200f;
    [SerializeField] private float _flySpeed = 100f;
    [SerializeField] private ParticleSystem _flyParticles;
    [SerializeField] private ParticleSystem _boomParticles;
    [SerializeField] private ParticleSystem _finishParticles;
    [SerializeField] private PanelUi panelUi;
    private Rigidbody rigidBody;

    enum State { Playing, Dead, NextLevel }; // состояние и {обьявление возможных состояний}
    State state = State.Playing; // текущие состояние;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (state == State.Playing)
        {
            Lunch();
            Rotation();
        }
        if (state == State.Dead)
        {
            panelUi.ActivePanelLose();
        }
    }
    void Lunch()
    {
        float lunchSpeed = _flySpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) == true)
        {
            _flyParticles.Play();
            rigidBody.AddRelativeForce(Vector3.up * lunchSpeed);
        }
        else
        {
            _flyParticles.Stop();
        }
    }
    void Rotation()
    {
        float rotatinSpeed = _rotSpeed * Time.deltaTime;
        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, 0f, 1f) * rotatinSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 0f, -1f) * rotatinSpeed);
        }
        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Playing)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                _finishParticles.Play();
                state = State.NextLevel;
                panelUi.ActivePanelWin();
                break;
            default:
                _boomParticles.Play();
                state = State.Dead;
                break;
        }
    }

    public void StateDead()
    {
        state = State.Dead;
    }
}


