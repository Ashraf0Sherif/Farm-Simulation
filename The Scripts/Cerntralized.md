# **1️⃣ What does this script do?**

This script is responsible for controlling the **growth stages of a plant**. It allows a seed to **grow step-by-step** into a larger plant when it's near a **water can**. Each stage of growth happens after a certain amount of time, and each stage has a unique plant model.

---

# **2️⃣ Full Code Breakdown**

`using UnityEngine;`  
`using System.Collections.Generic; // Allows the use of lists and collections`  
`using System.Collections; // Required for coroutines`

`public class SeedManager : MonoBehaviour`  
`{`  
    `public GameObject plantSmallPrefab; // Reference to the small plant prefab`  
    `public GameObject plantMediumPrefab; // Reference to the medium plant prefab`  
    `public GameObject plantTomatoMediumPrefab; // Reference to the medium tomato prefab`  
    `public GameObject plantTomatoLargePrefab; // Reference to the large tomato prefab`  
    `public float growthDistance = 2f; // Distance within which the plant will grow`  
    `public float growthTime = 5f; // Time it takes to grow to the next stage`

    `private GameObject waterCan; // Reference to the WaterCan object`  
    `private List<GrowingPlant> growingPlants = new List<GrowingPlant>(); // List to track all growing plants`

    `void Start()`  
    `{`  
        **`// Find all seeds in the scene`**  
        `GameObject[] seedObjects = GameObject.FindGameObjectsWithTag("Seed");`  
        `foreach (GameObject seed in seedObjects)`  
        `{`  
            `growingPlants.Add(new GrowingPlant(seed, GrowthStage.Seed));`  
        `}`

        `// Find the WaterCan in the scene`  
        `waterCan = GameObject.FindWithTag("WaterCan");`  
    `}`

    `void Update()`  
    `{`  
        `if (waterCan == null) return;`

        `for (int i = growingPlants.Count - 1; i >= 0; i--)`  
        `{`  
            `GrowingPlant plant = growingPlants[i];`

            `if (plant.GameObject == null)`  
            `{`  
                **`growingPlants.RemoveAt(i);`**  
                `continue;`  
            `}`

            `float distance = Vector3.Distance(plant.GameObject.transform.position, waterCan.transform.position);`

            `if (distance <= growthDistance && !plant.IsGrowing)`  
            `{`  
          `      StartCoroutine(GrowPlant(plant));`  
            `}`  
        `}`  
    `}`

    `IEnumerator GrowPlant(GrowingPlant plant)`  
    `{`  
        `plant.IsGrowing = true;`

        `yield return new WaitForSeconds(growthTime);`

        `switch (plant.Stage)`  
        `{`  
           ` case GrowthStage.Seed:`  
                `ReplacePlant(plant, plantSmallPrefab, GrowthStage.PlantSmall);`  
                `break;`  
          `  case GrowthStage.PlantSmall:`  
                `ReplacePlant(plant, plantMediumPrefab, GrowthStage.PlantMedium);`  
                `break;`  
           ` case GrowthStage.PlantMedium:`  
                `ReplacePlant(plant, plantTomatoMediumPrefab, GrowthStage.PlantTomatoMedium);`  
                `break;`  
           ` case GrowthStage.PlantTomatoMedium:`  
                `ReplacePlant(plant, plantTomatoLargePrefab, GrowthStage.PlantTomatoLarge);`  
                `break;`  
            `default:`  
                `Debug.Log("Plant has reached the final stage!");`  
                `break;`  
        `}`

        `plant.IsGrowing = false;`  
    `}`

    `private void ReplacePlant(GrowingPlant plant, GameObject nextPrefab, GrowthStage nextStage)`  
    `{`  
        `Vector3 position = plant.GameObject.transform.position;`  
        `Quaternion rotation = plant.GameObject.transform.rotation;`

        `Destroy(plant.GameObject);`

        `GameObject newPlant = Instantiate(nextPrefab, position, rotation);`

        `plant.GameObject = newPlant;`  
        `plant.Stage = nextStage;`  
    `}`  
`}`

**`public enum GrowthStage`**  
**`{`**  
    **`Seed,`**  
    **`PlantSmall,`**  
    **`PlantMedium,`**  
    **`PlantTomatoMedium,`**  
    **`PlantTomatoLarge`**  
**`}`**

`public class GrowingPlant`  
`{`  
    `public GameObject GameObject { get; set; }`  
    `public GrowthStage Stage { get; set; }`  
    `public bool IsGrowing { get; set; }`

    `public GrowingPlant(GameObject gameObject, GrowthStage stage)`  
    `{`  
        `GameObject = gameObject;`  
        `Stage = stage;`  
        `IsGrowing = false;`  
    `}`  
`}`

---

# **3️⃣ Key Concepts (Default Unity Concepts)**

### **1\. MonoBehaviour**

* **What is it?**  
  * It allows the script to be attached to GameObjects.  
  * It provides essential Unity methods like `Start()`, `Update()`, and `OnTriggerEnter()`.

### **2\. GameObject**

* **What is it?**  
  * Every object in Unity is a **GameObject**.  
  * In this script, the **WaterCan** and the **Seed** are GameObjects.  
  * The **plant stages** are also GameObjects (PlantSmall, PlantMedium, etc.).

### **3\. Coroutine**

* **What is it?**  
  * A **Coroutine** is a method that waits before continuing execution.  
  * In this script, it waits for `growthTime` seconds before growing the plant.  
  * This is done using `yield return new WaitForSeconds(growthTime)`.

### **4\. Vector3**

* **What is it?**  
  * **Vector3** represents a position in 3D space (X, Y, Z).  
  * It is used to measure the distance between the plant and the water can.

---

# **4️⃣ Step-by-Step Instructions (How to Build It in Unity)**

## **🔧 Attach the Script**

1. **Add the SeedManager Script**  
   * Create an empty GameObject in the **Hierarchy**.  
   * Rename it **SeedManager**.  
   * Attach the **Cerntralized.cs** script to the **SeedManager**.  
2. **Link the Plant Prefabs to the Script**  
   * Select **SeedManager** in the **Hierarchy**.  
   * Drag the **PlantSmall, PlantMedium, PlantTomatoMedium, PlantTomatoLarge** prefabs into the script slots.

---

# **5️⃣ How the Script Works**

1. When the scene starts, Unity finds all **Seed** objects.  
2. It detects the distance between each **Seed** and the **WaterCan**.  
3. If the water can is close, the seed grows into **PlantSmall**, then into **PlantMedium**, and so on.

---

# **6️⃣ Key Questions You Might Be Asked**

### **1\. What is MonoBehaviour?**

* It allows scripts to be attached to **GameObjects**.  
* It allows use of methods like **Start()**, **Update()**, and **OnTriggerEnter()**.

### **2\. How do you grow the seed?**

* If the **WaterCan** is close to the seed, a Coroutine is triggered.  
* After **5 seconds**, the seed changes to the next growth stage.

### **3\. How do you add a new growth stage?**

* Add a new **Prefab** for the new growth stage.  
* Add a new entry in the **GrowthStage** enum.  
* Add a new case in the **switch** inside `GrowPlant()`.

### **4\. What would happen if you forget to set the tag of the WaterCan?**

* The script will not be able to find the water can, and the plant will not grow.

