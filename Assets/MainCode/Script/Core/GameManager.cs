using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int levelNumber = 1;
    public int girlMustSave = 10;
    public int arrowAvailable = 10;
    public int perfectScore = 1000;
    static int count;
    //Private
    private int score;
    private string levelName;

    public enum GameState
    {
        Menu,
        Playing,
        Pause,
        Success,
        Fail
    }

    public GameState state;

    public static int girlCurrent
    {
        get { return instance.girlMustSave; }
        set { instance.girlMustSave = value; }
    }

    public static int arrowCurrent
    {
        get { return instance.arrowAvailable; }
        set
        {
            instance.arrowAvailable = value;

        }
    }

    public static void ArrowFinish()
    {
        if ((instance.arrowAvailable <= 0) && (instance.state != GameState.Success))
        {
            UIManager.instiance.ShowOutOfArrow();
        }
    }

    public static GameState CurrentState
    {
        get { return instance.state; }
    }

    public static int Score
    {
        get { return instance.score; }
        set { instance.score = value; }
    }

    public static int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(instance.levelName, 0);
        }
        set
        {
            PlayerPrefs.SetInt(instance.levelName, value);

        }
    }

    public static bool isPerfect
    {
        get
        {
            if (instance.score >= instance.perfectScore)
            {
                PlayerPrefs.SetInt(GlobalValue.perfectLevel + instance.levelNumber, 1); //save perfect
                return true;
            }
            else
                return false;
        }
    }



    // Use this for initialization
    void Start()
    {
        instance = this;
        levelName = SceneManager.GetActiveScene().name;
        state = GameState.Playing;
    }


    public static void Rescued()
    {
        instance.girlMustSave--;
        if (instance.girlMustSave <= 0)
        {
            //Check high score
            instance.CheckHighScore();
            //Check level reached, in case user play again
            instance.CheckLevelPassed();

            instance.state = GameState.Success;
            UIManager.instiance.ShowGameSuccess();
        }
    }

    public static void Fail()
    {
        instance.state = GameState.Fail;
        UIManager.instiance.ShowGameFail();
        count++;
        if (count >= 5)
        {

            if (PlayerPrefs.GetInt("purchasednoads") == 0)
            {
                //YOU CAN SHOW HERE AN AD
                showApplovin();
            }
            count = 0;
        }
    }

    //Private 
    private void CheckHighScore()
    {
        if (score > HighScore)
            HighScore = score;
    }

    private void CheckLevelPassed()
    {
        int levelpass = PlayerPrefs.GetInt(GlobalValue.levelReached, 1);
        if (levelNumber >= levelpass)
        {
            int levelReached = levelNumber + 1;// add levelNumber 1 mean you reach to next level
            PlayerPrefs.SetInt(GlobalValue.levelReached, levelReached);
        }
    }


    //-------------------------------------------------------------------------------------------------------------------------------

    private static void showApplovin()
    {
        AppLovin.SetSdkKey("YOUR-SDK-KEY");
        AppLovin.InitializeSdk();
        AppLovin.PreloadInterstitial();
        AppLovin.ShowInterstitial();
    }
}
