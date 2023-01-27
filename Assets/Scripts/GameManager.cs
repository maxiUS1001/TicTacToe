using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<MakeAMove> _buttonList;
    
    [SerializeField]
    List<GameObject> _horizontalWin;
    
    [SerializeField]
    List<GameObject> _verticalWin;
    
    [SerializeField]
    List<GameObject> _diagonalWin;

    [SerializeField]
    TextMeshProUGUI _winnerText;
    
    [SerializeField]
    GameObject _winnerPanel;

    [HideInInspector]
    public int whichMoveIsIt;
    
    [HideInInspector]
    public int numOfMoves;

    [HideInInspector]
    public bool gameOver;

    int _showWinningLine;
    string _winner;

    // Update is called once per frame
    void Update()
    {
        if (CheckForWinner())
            ShowWinnerPanel(_winner);

        if (!CheckForWinner() && numOfMoves == 9)
            ShowWinnerPanel("Draw!!!");
    }

    bool CheckForWinner()
    {
        return CheckHorizontals() || CheckVerticals() || CheckDiagonals();
    }

    bool CheckHorizontals()
    {
        for (int i = 2; i < _buttonList.Count; i += 3)
        {
            if (_buttonList[i - 2].whatSymbol + _buttonList[i - 1].whatSymbol + _buttonList[i].whatSymbol == 15)
            {
                _horizontalWin[_showWinningLine].SetActive(true);
                gameOver = true;
                _winner = "X won!!!";
                return true;
            }

            if (_buttonList[i - 2].whatSymbol + _buttonList[i - 1].whatSymbol + _buttonList[i].whatSymbol == 18)
            {
                _horizontalWin[_showWinningLine].SetActive(true);
                gameOver = true;
                _winner = "0 won!!!";
                return true;
            }

            _showWinningLine++;
        }

        _showWinningLine = 0;
        return false;
    }

    bool CheckVerticals()
    {
        for (int i = 6; i < _buttonList.Count; i++)
        {
            if (_buttonList[i - 6].whatSymbol + _buttonList[i - 3].whatSymbol + _buttonList[i].whatSymbol == 15)
            {
                _verticalWin[_showWinningLine].SetActive(true);
                gameOver = true;
                _winner = "X won!!!";
                return true;
            }

            if (_buttonList[i - 6].whatSymbol + _buttonList[i - 3].whatSymbol + _buttonList[i].whatSymbol == 18)
            {
                _verticalWin[_showWinningLine].SetActive(true);
                gameOver = true;
                _winner = "0 won!!!";
                return true;
            }

            _showWinningLine++;
        }

        _showWinningLine = 0;
        return false;
    }

    bool CheckDiagonals()
    {
        for (int i = 6, j = 0; i < _buttonList.Count; i += 2, j += 4)
        {
            if (_buttonList[i - 4 - j].whatSymbol + _buttonList[4].whatSymbol + _buttonList[i].whatSymbol == 15)
            {
                _diagonalWin[_showWinningLine].SetActive(true);
                gameOver = true;
                _winner = "X won!!!";
                return true;
            }

            if (_buttonList[i - 4 - j].whatSymbol + _buttonList[4].whatSymbol + _buttonList[i].whatSymbol == 18)
            {
                _diagonalWin[_showWinningLine].SetActive(true);
                gameOver = true;
                _winner = "0 won!!!";
                return true;
            }

            _showWinningLine++;
        }

        _showWinningLine = 0;
        return false;
    }

    void ShowWinnerPanel(string text)
    {
        _winnerPanel.SetActive(true);
        _winnerText.text = text;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
