using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _cameraPos;

    private void Start()
    {
        _cameraPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_player.position.y > _cameraPos.y)
        {
            _cameraPos.y = _player.position.y;
            transform.position = _cameraPos;
        }
    }
}