using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _wallSprite;
    [SerializeField] private SpriteRenderer _floorSprite;
    [SerializeField] private SpriteRenderer _RefriSprite;
    [SerializeField] private SpriteRenderer _CuadroSprite;
    [SerializeField] private SpriteRenderer _DeskSprite;
    [SerializeField] private SpriteRenderer _DoorSprite;
    [SerializeField] private SpriteRenderer _LampSprite;
    [SerializeField] private Light2D _lampLight;
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private Light2D _HeavensLight;

    [SerializeField] private Sprite _BadRefri;
    [SerializeField] private Sprite _BadCuadro;

    [SerializeField] private Sprite _GoodRefri;
    [SerializeField] private Sprite _GoodDoor;
    [SerializeField] private Sprite _GoodCuadro;
    [SerializeField] private Sprite _GoodDesk;
    [SerializeField] private Sprite _GoodWall;
    [SerializeField] private Sprite _GoodFloor;
    [SerializeField] private Sprite _GoodLamp;


    [SerializeField] private Color _badWallColor;
    //[SerializeField] private Color _goodWallColor;

    [SerializeField] private Color _badFloorColor;
    //[SerializeField] private Color _goodFloorColor;
    void Start()
    {
        ChangeAmbient(GameManager.Instance.CurrentSanityLevel);
    }

    private void ChangeAmbient(int currentSanity)
    {
        switch (currentSanity)
        {
            case 2:
                //Very Good
                _wallSprite.sprite=_GoodWall;
                _floorSprite.sprite=_GoodFloor;
                _RefriSprite.sprite=_GoodRefri;
                _CuadroSprite.sprite=_GoodCuadro;
                _DeskSprite.sprite= _GoodDesk;
                _DoorSprite.sprite=_GoodDoor;
                _LampSprite.sprite=_GoodLamp;
                _lampLight.intensity = 1f;
                _globalLight.intensity = 1f;
                _HeavensLight.intensity = 0.3f;
                break;
            case 1:
                //Good
                _lampLight.intensity = 1f;
                _globalLight.intensity = 1f;
                break;
            case 0:
                //Neutral 
                _lampLight.intensity = 1f;
                _globalLight.intensity = .9f;
                break;
            case -1:
                //Bad
                _lampLight.intensity = 0.7f;
                _globalLight.intensity = 0.3f;
                break;
            case -2:
                //Very Bad
                _RefriSprite.sprite = _BadRefri;
                _CuadroSprite.sprite = _BadCuadro;
                _wallSprite.color = _badWallColor;
                _floorSprite.color = _badFloorColor;
                _lampLight.intensity = 0.7f;
                _globalLight.intensity = 0.3f;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentSanity), currentSanity, null);
        }
    }
}
