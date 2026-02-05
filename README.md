# Unity VR Menu

A Unity project demonstrating a VR menu system that allows users to view a restuarant scene in VR and select food items. There are scripts incorporated onto GameObjects to allow signals to be sent to a arduino with a wifi chip to dispense scents. This is a project to determine if olfactory stimuli can affect user eating habits and/or food choices.

---

## Project Overview

This project contains a VR-ready Unity setup that focuses on:

- A VR menu interface
- XR controller-based interaction
- Compatibility with OpenXR-capable headsets (e.g., Meta Quest)

It is designed to be cloned and opened in Unity, where users can explore how XR rigs, controllers, and UI elements are wired together in a practical VR scene.

---

## Unity Version

**Unity Version Used:**

Unity 2022.3.44f1 LTS

Using the same Unity version is strongly recommended to avoid package or serialization issues.

---

## Required Packages

This project depends on the following Unity packages:

- **XR Plugin Management**
- **XR Interaction Toolkit**
- **Input System**
- **OpenXR Plugin**

These are installed through Unity’s **Package Manager**.

---

## Platform Support

- **Target Platform:** Android (Meta Quest / OpenXR devices)
- **Optional:** PC VR (with proper OpenXR runtime)

To build for Quest or other Android-based headsets, Android Build Support must be installed through Unity Hub.

---

## Seup Instructions

### 1️ Clone the Repository

```bash
git clone https://github.com/McKadeW/Unity_VR_Menu.git
```

---

### 2️ Open the Project in Unity

1. Open **Unity Hub**
2. Click **Add Project**
3. Select the cloned `Unity_VR_Menu` folder
4. Open it using the specified Unity version

---

### 3️ Install Required Packages

Open **Window → Package Manager** and ensure the following are installed:

- **XR Interaction Toolkit**
- **Input System**
- **XR Plugin Management**

If prompted, enable the **new Input System** and restart Unity.

---

### 4️ Configure XR Plugin Management

1. Go to **Edit → Project Settings → XR Plug‑in Management**
2. Enable XR for your target platform:
   - **Android:** Enable **OpenXR**
   - (Optional) Enable Meta Quest support if available

---

### 5️ OpenXR Configuration

Inside **Project Settings → XR Plug‑in Management → OpenXR**:

- Enable **Controller Profiles** (Quest / Touch Controllers)
- Ensure **Interaction Profiles** are assigned

---

### 6️ XR Interaction Toolkit Setup

1. Go to **Edit → Project Settings → XR Interaction Toolkit**
2. Import **Starter Assets** if prompted
3. Ensure:
   - An **XR Interaction Manager** exists in the scene
   - An **XR Origin (Action‑Based)** prefab is used

---

## XR Controllers & GameObjects

- If the **XR Interaction Toolkit is missing**, controller components will break
- If input action assets are missing or not enabled, controllers will not respond
- Unity does **not** auto‑assign controllers unless the scene already contains a configured XR Rig

---

## Android / Quest Build Instructions

### 1 Switch Platform

- Go to **File → Build Settings**
- Select **Android**
- Click **Switch Platform**

---

### 2️ Player Settings

In **Edit → Project Settings → Player**:

- Set **Package Name** (e.g., `com.yourname.unityvrmenu`)
- Minimum API Level: Android 7.0+ (recommended for Quest)
- Enable **ARM64**

---

### 3️ Build APK

- Connect your headset via USB (Developer Mode enabled)
- Click **Build & Run**
- Unity will generate and install the APK on the device

---

## Common Issues & Tips

- If controllers don’t appear:
  - Check OpenXR is enabled
  - Verify controller profiles
  - Confirm Input Actions are assigned

- If interactions don’t work:
  - Ensure an **XR Interaction Manager** exists
  - Confirm Ray Interactors are enabled

- Always commit:
  - Scene files
  - XR Rig prefabs
  - Input Action assets
