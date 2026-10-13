# Quest Checkout — HCI Project 02

A Unity application based on our Figma prototype that simulates reservations for six Meta Quest 3 kits. It includes kit selection, available time slots, kit contents, and pickup and return information.

The demonstration uses predefined dates and time slots in September 2026.

## Submission Links

- [Original Figma prototype](https://www.figma.com/design/MeLB0xtBHJW6xkiPqwrDXi/HCI-First-Partial-Proyect?node-id=0-1)
- [Design report](docs/Design.pdf)
- [Testing report](docs/Testing.pdf)
- [AI usage log](docs/AI-Use.pdf)
- **Build on GitHub Release:** LINK TO BE ADDED.
- [Demonstration video](https://drive.google.com/file/d/1BVozf70XtHxFv7hFseE067CqmO4SCCRN/view?usp=sharing).

## Team Members and Contributions

| Team member | Contributions |
|---|---|
| César | Calendars for both scenarios, navigation integration, confirmation button adjustments, and collaboration on returning to Home and blocking reserved kits. |
| Iker | Kit selection and contents screens, visual states, and implementation of `KitManager` and `UserData` to share the selection between scenes. |
| Rodrigo | Pickup and return screens, and visual adjustments to the confirmation button based on user testing. |

## Requirements and Setup

- Unity Hub.
- **Unity 6000.5.9f1**.

1. Download or clone the repository.
2. In Unity Hub, select **Add / Add project from disk**.
3. Select the root folder containing `Assets`, `Packages`, and `ProjectSettings`.
4. Open the project with the specified Unity version and wait for the import to finish.

If the **Game** view looks pixelated, uncheck **Low Resolution Aspect Ratios** in the resolution selector. You can also use a fixed resolution of **1920 × 1080**.

## Running and Testing the Scenarios

**Start each flow only from its initial scene in Iker’s folder.** The intermediate screens use the selection made at the beginning.

Stop Play mode before switching scenarios.

### Scenario A — Available Reservation

1. Open only:
   `Assets/Iker/SceneA/SceneAStart.unity`.
2. Press **Play**.
3. Select an available kit.
4. In the calendar, select the **11:30 AM to 1:00 PM** time slot, corresponding to 90 minutes.
5. Click **Confirm Reservation** and review the kit contents.
6. Continue using **Next** until you reach the pickup screen, which displays **TI LAB #2** and a return time of **1:00 PM**.
7. Click **Home** to return to kit selection.

After returning through Home, the reserved kit appears as unavailable and remains blocked during that session.

### Scenario B — No Initial Availability

1. Open only:
   `Assets/Iker/SceneB/SceneBStart.unity`.
2. Press **Play**.
3. Select a kit to check its availability.
4. Verify that the calendar shows no available time slots for the initial day.
5. Select **September 28** to check the available alternative.
6. Select the time slot, confirm, and continue to the pickup information.
7. Click **Home** to return to kit selection.

### Running the Build

1. Download the compressed file from the GitHub Release linked above.
2. Extract the entire folder.
3. Run the `.exe` file, keeping the other build files and folders alongside it.

With the current configuration, the build starts in **Scenario A**. To test **Scenario B**, open its initial scene in Unity; the application does not yet include a scenario selector.

## Controls

| Control | Action |
|---|---|
| Hover over a kit | Displays visual feedback and, when applicable, information about its status. |
| Left click | Selects kits, dates, time slots, and buttons. |
| Back | Returns to the previous screen in the flow. |
| Next | Advances to the next screen. |
| Confirm Reservation | Continues after selecting an available time slot. |
| Home | Completes the flow, marks the kit as unavailable, and returns to kit selection. |

## Resetting the Tests

In Unity, stop Play mode and start it again from `SceneAStart` or `SceneBStart`. With the current project configuration, this resets the session data.

In the build, close the application completely and reopen it.

**Home does not reset the inventory:** it keeps kits reserved during the session blocked. There is currently no dedicated button to reset the scenarios within the application.

### Running the Builds (Scenario A and Scenario B)

The repository now includes standalone builds for both scenarios. To run them locally:

1. Navigate to the `BuildSceneA` or `BuildSceneB` folder within your cloned or downloaded repository.
2. Run the corresponding `.exe` file (e.g., `BuildSceneA.exe` or `BuildSceneB.exe`).
3. Make sure to keep the `.exe` file alongside its respective data folders (such as the `_Data` folder) so the application runs correctly.

*Note: Each scenario has its own independent executable. To test the other scenario, simply close the current application and run the `.exe` from the other folder.*

## Known Limitations

- Reservations and availability changes remain in memory during the session; they are not preserved after closing the application.
- The calendars use demonstration dates and time slots. They do not support choosing any date freely or changing the duration.
- Returning to the calendar requires selecting the time slot again.
- The contents screen allows users to review the accessories visually, but it does not automatically verify that all items are present before continuing.
