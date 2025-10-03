
# Challenge 1: Player Dialog Setup

## Goal
Create a simple in‑scene "Player" object that displays dynamic dialog-like text above it, following the object as it moves, similar to an RPG dialog bubble.

## Prerequisites
- Unity project opened
- Module changes pulled / fetched from version control
- Imported scripts/Objects: `PlayerStats`, `ConsoleTest`, `DebugText` (as referenced)


## Sections
2. Player Object Creation
3. Stats Configuration
4. Console Text Hookup
5. World-Space Debug Text Attachment
6. Dialog Bubble Formatting
7. Camera Framing
8. Verification Checklist
9. Stretch Goals

---

## 2. Player Object Creation
1. In Hierarchy: Right-click > 3D Object > Cube (or any preferred 3D primitive).
2. Rename object to `Player`.
3. Reset Transform (if needed): Transform context menu > Reset.

## 3. Stats Configuration (PlayerStats Component)
1. With `Player` selected: Inspector > Add Component > `PlayerStats`.
2. Configure values (example):
   - Health: 120
   - Strength: 8
   - Speed: 5
   - Any custom fields: personalize (e.g., PlayerName = "Nova")
3. Confirm values reflect the personality of your “Player”. This wont exist later, have fun with it.

## 4. Attach ConsoleTest Component
1. Add Component > `ConsoleTest`.
2. In the Inspector, fill any serialized fields required:
   - Reference to output text.
   - Sample text/message field (e.g., "Hello World" or dynamic stats). Change it to your own dialog.
3. If the script logs to Console, enter Play Mode briefly to validate no errors.

## 5. World-Space Debug Text Attachment
1. Locate `DebugText` prefab:
3. Parent `DebugText` under `Player` (drag onto `Player` in Hierarchy).
4. Position:
   - Set local position Y above head (e.g., (0, 1.8, 0)).
5. Scale adjustments:
6. Assign text reference in `ConsoleTest` (drag the Text into serialized field).

## 6. Dialog Bubble Formatting
1. Enlarge text area by adjusting the Text Componnt values that adjust the font size and box size. Below is all optional settings to play with.
   - Set RectTransform width/height for a dialog box feel (e.g., 300x120 units pre-scale).
2. Enable word wrapping.
3. Center alignment (vertical + horizontal) or left-align for multi-line.
4. Add background (optional):
   - Add Image component as parent panel with semi-transparent dark color (e.g., RGBA: 0,0,0,150).
   - Round corners if using a sprite (optional).


## 7. Camera Framing
1. Select Main Camera.
2. Position so Player is centered with space above for the dialog:
3. Use Game View to ensure:
   - Player body visible
   - Text fully legible
   - Bubble not clipped at screen edges
4. Adjust Field of View (if perspective) to taste (e.g., 50–60).

## 8. Verification Checklist
- [ ] Player object exists and is named `Player`
- [ ] `PlayerStats` component configured with custom values
- [ ] `ConsoleTest` attached with filled references
- [ ] DebugText shows above Player in Game View
- [ ] Text follows Player when moved (Move tool or runtime movement)
- [ ] Dialog box readable, correct scale, not distorted
- [ ] No Console errors in Play Mode
- [ ] Camera framing shows entire Player + text bubble

## Troubleshooting
- Text tiny or huge? Check font sizes in the text inspector.
- Text not following? Ensure `DebugText` is a child of `Player`.
- Clipping? Move camera back or adjust FOV.

## Completion
When all checklist items are satisfied and the dialog behaves as intended, this challenge is complete. 
Take a screenshot of the Game View as proof of setup and post it in discord.

---
End of Challenge 1
