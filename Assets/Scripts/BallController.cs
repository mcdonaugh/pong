using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    [SerializeField] private int _ballMoveSpeed;
    [SerializeField] private PlayerController _paddle1;
    [SerializeField] private PlayerController _paddle2;
    private int _ballMoveDirection = 0;
    private AudioSource _pongSound;
    

    private void Start()
    {
       SetDirectionRandom();
       _pongSound = GetComponent<AudioSource>();  
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + _ballMoveSpeed * Time.deltaTime, transform.position.y + _ballMoveDirection * Time.deltaTime, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Paddle Deflection
        if (collision.transform.tag == "Player")
        {
            _ballMoveSpeed = -_ballMoveSpeed;
            _pongSound.Play();

            if (_paddle1.Direction == 1)
            {
                _ballMoveDirection = 30;
            }
            if (_paddle1.Direction == 0)
            {
                _ballMoveDirection = -30;
            }

            if (_paddle2.Direction == 1)
            {
                _ballMoveDirection = 30;
            }
            if (_paddle2.Direction == 0)
            {
                _ballMoveDirection = -30;
            }

            Debug.Log($"{_ballMoveDirection}");

        }

        // Reflects off bounds
        else if (collision.transform.tag == "Bound")
        {
            _pongSound.Play();
            _ballMoveDirection = -_ballMoveDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.transform.tag == "Goal")
        {
            StartCoroutine(WaitForFunction());

            IEnumerator WaitForFunction()
            {
                yield return new WaitForSeconds(1.5f);
                transform.position = new Vector3(0,0,0);
                SetDirectionRandom();
                Debug.Log("New Point!");
            }  
        }
    }

    private void SetDirectionRandom()
    {
        int randomNumber = Random.Range(0, 2);
        _ballMoveDirection = 0;

        if(randomNumber == 0)
        {   
            _ballMoveSpeed = -_ballMoveSpeed;
        }
        
    }
}