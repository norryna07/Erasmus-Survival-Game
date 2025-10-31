

# 🎮 *Erasmus Survival* — Unity Implementation Summary (3D Version)

## 🧱 1. Project Setup

### Engine & Framework

* **Unity version:** 2022 LTS or newer
* **Template:** 3D (URP recommended for good visuals & performance)
* **Language:** C#
* **Core Packages:**

  * Cinemachine (for dynamic cameras)
  * TextMeshPro (UI)
  * ProBuilder / Polybrush (for prototyping rooms)
  * Starter Assets (Third Person Controller)
* **Version Control:** GitHub + `.gitignore` for Unity

---

## 🗺️ 2. Scene Structure
| Scene Name           | Description                        | Main Components                    |
| -------------------- | ---------------------------------- | ---------------------------------- |
| `MainMenu`           | Start, Load, Quit                  | Menu UI, GameManager init          |
| `CharacterCreation`  | Customize name, age, faculty, year | Form UI + Data persistence         |
| `HomeScene`          | Pre-Erasmus life                   | Task system, UI interactions       |
| `TravelScene`        | Traveling mini-game                | Transport choices, resource update |
| `AccommodationScene` | Selecting dorm/private housing     | Dialogues, RNG-based outcomes      |
| `UniversityScene`    | Course & professor discovery       | Map interactions, dialogue system  |
| `CityScene`          | Social & event hub                 | Side quests, social relationships  |
| `EndingScene`        | Final summary                      | Statistics display, ending type    |
| `AfterScene`         | Post-Erasmus world                 | Short story + ESN miniquest        |


---

## 🧍 3. Player System

### 3.1 Player Controller

Use Unity’s **Third Person Starter Assets** or your own custom controller:

* **Movement:** WASD / joystick
* **Camera:** Cinemachine FreeLook or Third Person Follow
* **Animation:** Animator Controller with states (Idle, Walk, Run, Interact)

### 3.2 Interaction System

Player can interact with 3D objects via raycast or trigger zones.

```csharp
public interface IInteractable {
    void Interact();
    string GetPromptText();
}
```

Example:

* Interact with **Laptop** → open email UI
* Interact with **Fridge** → open food menu (affects health/money)
* Interact with **NPC** → open dialogue window

---

## 💬 4. Dialogue & Choice System (3D Integration)

A **Dialogue Canvas** appears when the player interacts with an NPC.

* Dialogue triggered via `IInteractable`
* Character portraits / names displayed
* Branching dialogues (choices affect resources and relationships)
* ScriptableObject-based dialogue trees

```csharp
[CreateAssetMenu(menuName="Erasmus/Dialogue")]
public class Dialogue : ScriptableObject {
    public string npcName;
    public DialogueNode[] nodes;
}
```

---

## 💰 5. Core Resources System

### Resource Manager

Stores and updates player stats in real time:

```csharp
public class ResourceManager : MonoBehaviour {
    public float money = 2500f;
    public float happiness = 50f;
    public float health = 100f;
    public float credits = 0f;

    public void Change(string type, float amount) {
        // Update stat + trigger UI refresh
    }
}
```

UI bars (TextMeshPro + sliders) will appear as part of a **HUD Canvas** always visible on screen.


---

## 📚 6. Task & Quest System

Each quest is a `ScriptableObject` loaded by a `QuestManager`.

```csharp
[CreateAssetMenu(menuName="Erasmus/Quest")]
public class Quest : ScriptableObject {
    public string title;
    public string description;
    public Stage stage;
    public ResourceEffect[] effects;
    public bool isCompleted;
}
```

#### Quest Triggers:

* Talking to NPCs
* Entering specific zones
* Completing daily actions
* Random events (low happiness, missed bus, etc.)

#### Quest Feedback:

* Popup notification (“You missed the last bus!”)
* Audio cue
* HUD update (resource change animation)

---

## 🧠 7. NPC System

NPCs (friends, professors, parents, etc.) use a common base class:

```csharp
public class NPC : MonoBehaviour, IInteractable {
    public string npcName;
    public Dialogue dialogueFile;
    public void Interact() {
        DialogueManager.Instance.StartDialogue(dialogueFile);
    }
}
```

NPCs have:

* Idle animations
* Floating nameplates
* Schedule-based availability (optional later feature)

---

## 🗺️ 9. Environment & Navigation

Each environment (Apartment, University, City) contains:

* **NavMesh** for pathfinding (for player & NPCs)
* **Interactable objects:** furniture, doors, notice boards, etc.
* **Lighting zones:** day/night cycle (optional, easy with Unity Lighting)
* **Scene Transition triggers:** move between environments

---

## 🕹️ 10. Minigames (Optional but Fun)

| Minigame               | Stage             | Mechanic                   |
| ---------------------- | ----------------- | -------------------------- |
| **Packing luggage**    | Before            | Drag-and-drop under 20kg   |
| **Finding professors** | Starting          | Indoor navigation mini-map |
| **Exam study**         | During            | Memory/time-based Q&A      |
| **Party**              | During            | Rhythm mini-game           |
| **Travel choices**     | Starting & Ending | Resource trade-offs        |

These can be loaded as sub-scenes or pop-up canvases.

---

## 🧩 11. Side Quest System (Random Events)

Side quests trigger automatically or via exploration.
For example:

```csharp
if (player.happiness < 20f)
    QuestManager.Trigger("HomeSickEvent");
```

Side quests modify stats (money, happiness, etc.) and may spawn small cutscenes.

---

## 🎨 12. Visual Style & Assets

| Element        | Style                                                             |
| -------------- | ----------------------------------------------------------------- |
| **World**      | Semi-realistic low-poly (Unity Asset Store packs)                 |
| **Lighting**   | Soft ambient, warm tones for comfort, colder for exams/depression |
| **Characters** | Stylized 3D humans (use Ready Player Me or Mixamo)                |
| **UI**         | Minimal, soft pastel tones with Erasmus blue highlights           |
| **Music**      | Lo-fi, light electronic for calm & immersion                      |

---

## 💾 13. Save/Load System

* **Auto-save** when completing tasks or changing scenes
* **Manual save slots** (JSON serialization)
* Stored data:

  * Player position, resources
  * Active quests
  * Dialogue progress
  * Inventory (optional)

---

## 🏁 14. Ending System

At the end of the Erasmus:

* Compute player’s **final score** from resources:

  * Credits ≥ 25, Happiness ≥ 70 → “Perfect Erasmus”
  * Credits < 10 or Money < 0 → “Dropout”
  * etc.
* Play a **cinematic sequence** (camera flythrough + music)
* Show **summary UI** of stats and ending message.

---

## 📂 15. Suggested Project Folder Structure

```
Assets/
├── Scripts/
│   ├── Core (GameManager, SaveManager)
│   ├── Player (Controller, Interaction)
│   ├── UI (HUD, Menus)
│   ├── Systems (Quest, Dialogue, Resource)
│   └── NPCs
├── Scenes/
│   ├── MainMenu
│   ├── Apartment
│   ├── CityCenter
│   ├── University
│   ├── Travel
│   └── Ending
├── Art/
│   ├── Characters
│   ├── Environments
│   └── Props
├── Audio/
│   ├── Music
│   └── SFX
├── Resources/
│   ├── Quests
│   ├── Dialogues
│   └── Prefabs
└── UI/
    ├── HUD
    ├── Menus
    └── Dialogue
```