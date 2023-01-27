using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakeAMove : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    List<Sprite> _crossAndCircle; // 0 - cross, 1 - circle

    GameManager _gameManager;
    bool _isFilled;

    [HideInInspector]
    public int whatSymbol; // 5 - cross, 6 - circle

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isFilled && !_gameManager.gameOver)
            FillTheCell(_gameManager.whichMoveIsIt);
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FillTheCell(int side)
    {
        GetComponent<Image>().sprite = _crossAndCircle[side];
        GetComponent<Image>().color = Color.white;
        _isFilled = true;
        whatSymbol = side + 5;
        _gameManager.numOfMoves++;

        ChangeSide(side);
    }

    void ChangeSide(int side)
    {
        _gameManager.whichMoveIsIt = side == 0 ? _gameManager.whichMoveIsIt = 1 : _gameManager.whichMoveIsIt = 0;
    }
}
