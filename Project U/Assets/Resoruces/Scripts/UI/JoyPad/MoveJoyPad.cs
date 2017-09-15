using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoyPad : MonoBehaviour
{
    public enum JoyPad_Direction
    {
        NO_TOUCH,
        LFET = -1,
        RIGHT = 1
    }

    private JoyPad_Direction ePadDir;
    public JoyPad_Direction m_ePadDir
    {
        set
        {
            if(m_IsPossible)
            {
                this.ePadDir = value;
                m_IsPossible = false;
            }
        }
        get
        {
            return ePadDir;
        }
    }

    public bool m_IsPossible;

    void Start()
    {
        m_IsPossible = true;
        ePadDir = JoyPad_Direction.NO_TOUCH;
    }

    public void SetDirection(int _input)
    {
        m_ePadDir =  (JoyPad_Direction)_input;
    }

    public void OnClickUp()
    {
        m_IsPossible = true;
        ePadDir = JoyPad_Direction.NO_TOUCH;
    }
}
