using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayService : MonoBehaviour
{
    void Start()
    {
        PlayGamesClientConfiguration.Builder builder = new PlayGamesClientConfiguration.Builder();
        PlayGamesPlatform.InitializeInstance(builder.Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success, string err) =>
        {
            if (success)
                Debug.Log("Login success");
            else
            {
                Debug.Log("Login failed");
                Debug.Log("Error: " + err);
            }
        });
    }


}
