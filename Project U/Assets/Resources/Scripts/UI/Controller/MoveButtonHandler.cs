using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonHandler : MonoBehaviour
{
    public enum Button_Direction
    {
        NO_TOUCH,
        LFET = -1,
        RIGHT = 1
    }

    private bool m_IsOnlyOne;

    private Button_Direction ePadDirection;
    public Button_Direction m_ePadDirection
    {
        get
        {
            return ePadDirection;
        }
    }

    void Start()
    {
        m_IsOnlyOne = false;
        ePadDirection = Button_Direction.NO_TOUCH;
    }

    public void SetDirection(int _input)
    {
        if (m_IsOnlyOne)
            return;

        ePadDirection = (Button_Direction)_input;
        m_IsOnlyOne = true;
    }

    public void OnClickUp()
    {
        m_IsOnlyOne = false;
        ePadDirection = Button_Direction.NO_TOUCH;
    }
}
