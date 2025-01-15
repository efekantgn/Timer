# Timer Script - README

## Overview
This script provides a reusable and flexible **Timer** component for Unity projects. The Timer allows you to track time durations, pause, resume, and reset, with built-in events for key lifecycle moments.

## Features
- **Start, Pause, Resume, and Reset**: Fully control the timer lifecycle.
- **Event-based Updates**: Hook into events for start, pause, resume, reset, and completion.
- **Progress Updates**: Receive real-time updates with the remaining time.
- **Customizable Duration**: Define the timer duration at runtime.
- **Simple Integration**: Add the script to a GameObject and call its methods as needed.

## How It Works
The Timer script:
1. Tracks a countdown from the specified duration.
2. Provides events for each lifecycle phase.
3. Updates the remaining time every frame when active.

## Public Properties
| Property     | Description                              |
|--------------|------------------------------------------|
| `Duration`   | The total duration of the timer (seconds). |
| `IsRunning`  | Indicates if the timer is currently active. |

## Events
| Event           | Trigger Condition                                           |
|------------------|------------------------------------------------------------|
| `OnStart`        | Triggered when the timer starts.                            |
| `OnPause`        | Triggered when the timer is paused.                         |
| `OnResume`       | Triggered when the timer resumes after being paused.        |
| `OnReset`        | Triggered when the timer is reset.                          |
| `OnComplete`     | Triggered when the timer completes its countdown.           |
| `OnUpdate(float)`| Triggered every frame during countdown; provides remaining time. |

## Methods

### `void StartTimer(float duration)`
Starts the timer with a specified duration.

**Parameters:**
- `duration`: The total time in seconds for the timer.

### `void PauseTimer()`
Pauses the timer if it is currently running.

### `void ResumeTimer()`
Resumes the timer if it is paused and there is remaining time.

### `void ResetTimer()`
Resets the timer to its initial duration and stops it.

## Usage Example
```csharp
using Efekan.Systems.Timer;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private Timer timer;

    private void Start()
    {
        // Subscribe to timer events
        timer.OnStart += () => Debug.Log("Timer started!");
        timer.OnPause += () => Debug.Log("Timer paused!");
        timer.OnResume += () => Debug.Log("Timer resumed!");
        timer.OnComplete += () => Debug.Log("Timer completed!");
        timer.OnUpdate += remainingTime => Debug.Log($"Time remaining: {remainingTime}");

        // Start the timer with a duration of 10 seconds
        timer.StartTimer(10f);
    }

    private void Update()
    {
        // Example: Pause the timer when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer.PauseTimer();
        }

        // Example: Resume the timer when the R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            timer.ResumeTimer();
        }
    }
}
```

## Integration Steps
1. Add the **Timer** component to a GameObject in your Unity scene.
2. Configure the timer using the public methods or properties.
3. Subscribe to the timer events as needed.
4. Use the `StartTimer`, `PauseTimer`, `ResumeTimer`, and `ResetTimer` methods to control the timer.

## Notes
- The timer automatically resets when it completes.
- Ensure you subscribe to events before starting the timer for consistent behavior.
- This script uses Unity's `Time.deltaTime` for frame-based updates.

## License
This script is open for modification and use in any Unity project. Attribution is appreciated but not required.

