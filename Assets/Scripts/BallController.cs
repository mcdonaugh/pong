using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	[SerializeField] private int _ballMoveSpeed;
	private PlayerController _currentInteractedPaddle;
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
		if (collision.transform.tag == "Player")
		{
			_ballMoveSpeed = -_ballMoveSpeed;
			_pongSound.Play();
			_currentInteractedPaddle = collision.transform.GetComponent<PlayerController>();

			if (_currentInteractedPaddle.Direction == 1)
			{
				_ballMoveDirection = 30;
			}
			if (_currentInteractedPaddle.Direction == 0)
			{
				_ballMoveDirection = -30;
			}
		}

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
		}
	}
	
	private IEnumerator WaitForFunction()
	{
		yield return new WaitForSeconds(1.5f);
		
		transform.position = new Vector3(0,0,0);
		SetDirectionRandom();
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