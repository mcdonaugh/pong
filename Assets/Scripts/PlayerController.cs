using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode _playerInputUp;
    [SerializeField] private KeyCode _playerInputDown;
    [SerializeField] private Vector3 _playerStartPosition;
    [SerializeField] private int _playerMovementSpeed;
    [SerializeField] private int _playerTopBound;
    [SerializeField] private int _playerBottomBound;
    public int Direction {get; private set;}


    private void Start()
    {
        transform.position = _playerStartPosition;
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
       if (Input.GetKey(_playerInputUp))
       {
            if (transform.position.y >= _playerTopBound)
            {
                return;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + _playerMovementSpeed * Time.deltaTime, transform.position.z);
            Direction = 1;
       }
       else if (Input.GetKey(_playerInputDown))
       {
            if (transform.position.y <= _playerBottomBound)
            {
                return;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y - _playerMovementSpeed * Time.deltaTime, transform.position.z);
            Direction = 0;
       }
    }
}