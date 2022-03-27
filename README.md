# LGHUBDefaultPatcher
Simple tool to take the default profile for any chosen application and replicate that to all selected applications default profiles.

I threw this together in a few hours so it likely has a lot of bugs and ignore the messy code.

# How to use
First of all, I recommend backing up the file that will be getting modified by this tool. It can be found at "C:\Users\YOUR_NAME\AppData\Local\LGHUB\settings.db", make a copy of this file to somewhere secure.

You'll need to close LGHUB before being able to use this tool, close it from the System Tray. I recommend closing my tool before relaunching LGHUB too as you'll likely get an error. When the application is open, select the application you'd like replicated to all others via the radio button. Then select all applications you'd like to be overwritten with this root selection. You can now select from the right all the aspects you'd like to be copied over from root to the rest. Finally press Process in the bottom right.

Note: This tool has done everything I personally need from it and more however there are some circumstances where this tool wont work where you think it would, for example, using the starlight lighting effect on keyboard, this wont replicate across and will be reset.

# Attributes
As I am unable to grab all possible outcomes of data, I'm reconstructing these attribute toggles based on what is available in your settings (excluding the 1 attribute I added) and so, I cannot know what will be copied if you select the tag. That said, here are my observations so far:

FIRMWARE_LIGHTING_SETTINGS = This is lighting for periferals (not all effects work)
MOUSE_SETTINGS = This is DPI Table and report rate
DISABLE_KEY_SETTINGS = This is keys disabled in game mode (for keyboard, maybe mouse?)
CAMERA_SETTINGS = This is for the camera settings tab
VIDEO_SETTINGS = This is for the video section in camera settings
MACRO_PLAYBACK = This is for keybinds on just the keyboard (likely more)
MOUSE_BINDS = This is for mouse button bindings (This is the attribute that doesn't exist, I'm infering its existence where there is no attribute assigned in data, gross but it works)