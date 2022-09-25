using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonNext : MonoBehaviour
{
    [SerializeField] private GameObject _frameContainer;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Canvas[] _contextFrames;
    private float _position = 0f;
    private float _step = 25f;
    private int _count = 0;
    private int _childCount;
    private bool _goNext = false;
    private bool _goPrev = false;

    private void Start()
    {
        _childCount = _frameContainer.transform.childCount - 1;
    }

    public void OnClickNext()
    {
        _count++;
        if (_count <= _childCount)
        {
            _contextFrames[_count - 1].gameObject.SetActive(false);
            _position -= _step;
            _goNext = true;
        }
        else
        {
            GameManager.Instance.ChangeState(GameState.Lobby);
            LevelManager.Instance.LoadScene("Lobby");
        }
    }
    public void OnClickPrev()
    {
        _count--;
        if (_count >= 0)
        {
            _contextFrames[_count + 1].gameObject.SetActive(false);
            _position += _step;
            _goPrev = true;
        }
        else _count = 0;
    }

    private void Update()
    {
        if(_goNext)
        {
            _frameContainer.transform.position += Vector3.left * Time.deltaTime * _speed;
            var framePosX = _frameContainer.transform.position.x;
            if (framePosX <= _position)
            {
                _goNext = false;
                if (_count > _contextFrames.Length - 1) return;
                _contextFrames[_count].gameObject.SetActive(true);
            }
        }
        else if(_goPrev)
        {
            _frameContainer.transform.position+=Vector3.right * Time.deltaTime * _speed;
            var framePosX = _frameContainer.transform.position.x;
            if(framePosX >= _position)
            {
                _goPrev = false;
                if (_count < 0) return;
                _contextFrames[_count].gameObject.SetActive(true);
            }
        }

    }
}
