# Tame Visual Studio Editor Tool Tips

<!-- Update the VS Gallery link after you upload the VSIX-->
Download this extension from the [VS Gallery](https://marketplace.visualstudio.com/items?itemName=KarlShifflettkdawg.TameVisualStudioEditorTooltipsAsync)

---------------------------------------

## Visual Studio 2017 Support - On Hold
I discovered a problem with the way references are resolved with the package on Visual Studio 2017.  I'm working with Microsoft to resolve the issue.

## Feature
Getting tired of seeing Visual Studio code editor tooltips when you're presenting?  They flash immediately when you're moving your mouse.  Very distracting for you and your viewers.

This extension "Tames" the Visual Studio 2017 & 2019 code editor Tooltips by not showing them unless the CTRL or SHIFT is depressed and the user hovers over the object.  

Recommending using the SHIFT key to show the tooltip.  The CTRL key can have a negative side effect if the object you're hovering over is clickable.

### Building
The project was built using Visual Studio 2019.

For cloning and building this project yourself, make sure to install 
[Extensibility Tools 2019](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.ExtensibilityEssentials2019)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)
