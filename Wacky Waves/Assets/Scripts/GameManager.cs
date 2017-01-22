using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State { TITLE, LIVE, GAME_OVER}

    public delegate void StateHandler(State state);
    public static event StateHandler OnStateChanged;

	public string SceneToLoad;

    State _State = State.TITLE;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

	void Update()
    {
        switch (_State)
        {
            case State.TITLE:
                UpdateTitle();
                break;
            case State.LIVE:
                UpdateLive();
                break;
            case State.GAME_OVER:
                UpdateGameOver();
                break;
        }
	}

    void ChangeState(State state)
    {
        _State = state;

        switch (_State)
        {
            case State.TITLE:
                break;
            case State.LIVE:
                SceneManager.LoadScene(SceneToLoad);
                break;
            case State.GAME_OVER:
                UpdateGameOver();
                break;
        }

        if (OnStateChanged != null)
        {
            OnStateChanged(_State);
        }
    }

    void UpdateTitle()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            ChangeState(State.LIVE);
        }
    }

    void UpdateLive()
    {
    }

    void UpdateGameOver()
    {
    }
}
