using System;
using UnityEngine;
using UnityEngine.Events;

// In order to pass data to an event, you must derived from the EventArgs base-class
public class PlayerScoreEventArgs : EventArgs
{
    public int amount;
}

public class Events : MonoBehaviour
{
    UnityEvent OnPlayerDeath = new UnityEvent();
    UnityEvent<PlayerScoreEventArgs> OnPlayerScore = new UnityEvent<PlayerScoreEventArgs>();

    int playerScore = 0;

    void Start()
    {
        // "When the player death event happens, it will run the HandlePlayerDeath function"
        OnPlayerDeath.AddListener(HandlePlayerDeath);

        // "When the player score event happens, it will run the HandlePlayerScore function"
        OnPlayerScore.AddListener(HandlePlayerScore);

        float playerHealth = 100.0f;
        playerHealth -= 101.0f;
        if (playerHealth <= 0.0f)
        {
            // Trigger the player-death event if the player's health is zero or less
            OnPlayerDeath.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerScoreEventArgs args = new PlayerScoreEventArgs();
            args.amount = 10;
            OnPlayerScore.Invoke(args);
        }
    }

    void HandlePlayerDeath()
    {
        Debug.Log("You have died");
    }

    void HandlePlayerScore(PlayerScoreEventArgs e)
    {
        playerScore += e.amount;
        Debug.Log("Player score is: " + playerScore);
    }
}
