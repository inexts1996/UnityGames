using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public enum PlayerColorEnum
{
    Cyan,
    Yellow,
    Magenta,
    Pink
}

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private Color _cyan;
    [SerializeField] private Color _yellow;
    [SerializeField] private Color _magenta;
    [SerializeField] private Color _pink;
    [SerializeField] private PlayerColorEnum _currentColor;

    // Start is called before the first frame update
    private void Start()
    {
        _sr.color = GetColorWith(GetRandomColorEnum);
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) _rb.velocity = Vector2.up * _jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ColorChanger"))
        {
            _sr.color = GetColorWith(GetRandomColorEnum);
            GameObject.Destroy(other.gameObject);
            return;
        }
        if (!other.CompareTag(_currentColor.ToString()))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private PlayerColorEnum GetRandomColorEnum()
    {
        var randomColorEnum = (PlayerColorEnum) Random.Range(0, 4);
        _currentColor = randomColorEnum;

        return randomColorEnum;
    }

    private Color GetColorWith(Func<PlayerColorEnum> func)
    {
        var cEnum = func();
        if (cEnum == PlayerColorEnum.Cyan) return _cyan;

        if (cEnum == PlayerColorEnum.Yellow) return _yellow;

        if (cEnum == PlayerColorEnum.Magenta) return _magenta;

        if (cEnum == PlayerColorEnum.Pink) return _pink;

        return Color.white;
    }
}