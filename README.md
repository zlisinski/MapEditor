# MapEditor
This is the map editor for my RPG game. It is written in C#, and only runs on Windows.

You will need to edit the config.xml file to point to the correct asset directories.
There are sample assets in the "assets" directory. Assuming you cloned this repository into "C:\MapEditor",
update the config file to be:

```
<?xml version="1.0" encoding="utf-8" ?>
<config
  baseDir="C:\MapEditor\MapEditor"
  imageDir="C:\MapEditor\MapEditor\assets\images\"
  battleBackgroundDir="C:\MapEditor\MapEditor\assets\images\battleBackgrounds\"
  tileDir="C:\MapEditor\MapEditor\assets\images\tiles\"
  dataDir="C:\MapEditor\MapEditor\assets\data\"
  tileSetDir="DC:\MapEditor\MapEditor\assets\data\tilesets\"
  mapDir="DC:\MapEditor\MapEditor\assets\data\maps\"
  monsterRegionDir="C:\MapEditor\MapEditor\assets\data\monsterregions\"
/>
```
