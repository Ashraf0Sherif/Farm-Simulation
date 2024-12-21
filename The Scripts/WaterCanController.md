# **1️⃣ What does this script do?**

This script allows a **water can** to **pour water** using a **particle system** when a player presses a key (like the **spacebar**). The moment you release the key, the water stops pouring.

---

# **2️⃣ Full Code Breakdown**

`using UnityEngine; // This gives access to Unity's core classes like MonoBehaviour, GameObject, and Input.`

`public class WaterCanController : MonoBehaviour // This makes the WaterCanController a MonoBehaviour, meaning it can be attached to GameObjects.`  
`{`  
    `public ParticleSystem waterParticles; // Reference to the particle system that simulates the water`  
    `public KeyCode pourKey = KeyCode.Space; // The key that starts and stops water pouring (default is Space)`

    `void Update() // This method is called every frame (~60 times per second)`  
    `{`  
        `if (Input.GetKeyDown(pourKey)) // If the player presses the key`  
        `{`  
            `StartWatering();`  
        `}`  
        `else if (Input.GetKeyUp(pourKey)) // If the player releases the key`  
        `{`  
            `StopWatering();`  
        `}`  
    `}`

    `public void StartWatering()`  
    `{`  
        `if (!waterParticles.isPlaying) // If water particles are not already playing`  
        `{`  
            `waterParticles.Play(); // Start the particle effect`  
        `}`  
    `}`

    `public void StopWatering()`  
    `{`  
        `if (waterParticles.isPlaying) // If water particles are currently playing`  
        `{`  
            `waterParticles.Stop(); // Stop the particle effect`  
        `}`  
    `}`  
`}`

---

# **3️⃣ Key Concepts (Core Unity Features)**

### **1\. MonoBehaviour**

* **What is it?**  
  * `MonoBehaviour` is the **base class** from which all Unity scripts inherit.  
  * It provides access to core Unity functionality like **Start()**, **Update()**, **OnTriggerEnter()**, and **OnCollisionEnter()**.  
  * Only scripts inheriting from `MonoBehaviour` can be attached to **GameObjects**.

### **2\. GameObject**

* **What is it?**  
  * A **GameObject** is a container for **Components** in Unity.  
  * It is everything you see in the **Hierarchy** (like cubes, spheres, cameras, and particle systems).

### **3\. Particle System**

* **What is it?**  
  * The **Particle System** is used to create effects like rain, fire, smoke, and in this case, **water**.  
  * It is controlled with the `waterParticles.Play()` and `waterParticles.Stop()` methods.

### **4\. Input System**

* **What is it?**  
  * This script listens for **keyboard input** using Unity's built-in **Input** system.  
  * `Input.GetKeyDown()` is used to detect when a key is pressed down.  
  * `Input.GetKeyUp()` detects when a key is released.

---

# **4️⃣ Step-by-Step Instructions (How to Build It in Unity)**

## **🔧 Step 1: Water Can (is prefab from the assets)**

---

## **🔧 Step 2: Create the Water Particles**

1. **Add a Particle System**  
   * **Right-click in the Hierarchy** → **Effects** → **Particle System**.  
   * Rename it **WaterParticles**.  
2. **Customize the Particle System**  
   * **Position the Particle System** inside the WaterCan (you can make it a child of the WaterCan).  
   * Change its **Start Size** to **0.1** (to make the water look like small drops).  
   * Set **Start Speed** to **5** (to make the water flow downward quickly).  
   * Set **Gravity Modifier** to **1** (so water particles are affected by gravity).  
   * Disable **Looping** since the script will start/stop it.  
3. **Attach the Water Particles to the Script**  
   * Select the **WaterCan** GameObject.  
   * In the **Inspector**, you will see a slot for **Water Particles**.  
   * Drag the **WaterParticles** object from the **Hierarchy** into the **Water Particles** slot in the script.

---

# **5️⃣ How the Script Works**

1. **Every frame**, Unity calls the `Update()` method.  
2. It **listens for a key press** (`Input.GetKeyDown()`).  
3. If the **key is pressed**, the script calls `StartWatering()`:  
   * It **activates the Particle System** (makes the water appear).  
4. If the **key is released**, the script calls `StopWatering()`:  
   * It **stops the Particle System** (stops the water).

---

# **6️⃣ Key Questions You Might Be Asked**

### **1\. What is MonoBehaviour, and why do we use it?**

* **Answer**: MonoBehaviour is the **base class** for Unity scripts.  
  * It provides access to **lifecycle methods** like `Start()`, `Update()`, and `OnTriggerEnter()`.  
  * Without **MonoBehaviour**, you wouldn't be able to attach scripts to **GameObjects**.

### **2\. How does the WaterCanController know when to start and stop pouring water?**

* **Answer**:  
  * It listens for a **key press** using `Input.GetKeyDown()`.  
  * It listens for a **key release** using `Input.GetKeyUp()`.

### **3\. What is a Particle System, and why do we use it?**

* **Answer**:  
  * A **Particle System** generates visual effects like smoke, water, and fire.  
  * It has properties like **speed, size, and gravity** to control the behavior of particles.

### **4\. What Unity components do you need for this script to work?**

* **Answer**:  
  * A **Particle System** to display water.  
  * A **GameObject** (like a Cube) to act as the **WaterCan**.

