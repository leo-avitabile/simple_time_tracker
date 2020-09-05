# Simple Time Tracker
This program is a very simple and lightweight time tracker written in C#. Inspiration for interaction with the program came from the clipboard manager [Ditto](https://ditto-cp.sourceforge.io/). 
## How to use
### Recording Time
1. Open the exe
2. Type what you're working on (e.g. "Feature X")
3. Press Enter (this will begin recording time to "Feature X")
   - In this case, "Feature X" will be referred to as the ```Work Name```
   - Pressing Shift+Enter will uppercase the whole typed string
4. Press Ctrl+? to reopen the program and repeat
5. Pressing ESC while the main window is open will minimise the program to the tray

When the program is minimised, it remains in the system tray. Hovering over the tray icon will indicate what the program is logging time to.

### Quick Inserts
```Quick Inserts``` allow the user to quickly record time to commonly performed tasks. These values are inserted into the main textbox using Ctrl+1 to Ctrl+9. 

When pressing and holding Ctrl, currently saved ```Quick Inserts``` are displayed, along with the number used to insert them. 

The exact behaviour of the program varies depending on what the current text in the textbox is and what the current value of the ```Quick Insert``` list is. 
- If the textbox contains no text, pressing Ctrl and a number will insert the text shown in the ```Quick Insert``` box into the main textbox of the program.
- If the textbox contains text and Ctrl and a number is pressed then:
  - If the textbox text matches the ```Quick Insert``` for the pressed number, the program will begin recording time for the pressed ```Quick Insert```. 
    - This is useful for quickly beginning recording time to a known ```Quick Insert``` by calling up the program (Ctrl+?) and pressing Ctrl and a number twice.
  - If the textbox text does not match the ```Quick Insert``` for the pressed number, the ```Quick Insert``` for the pressed number will be overridden with the current textbox text. This allows users to quickly re-allocate ```Quick Insert``` values.


```Quick Inserts``` can also be modified using the built in editor, to do this:
1. Press *Tools*->*Quick Insert*
2. If adding a new ```Quick Insert```, enter the text value *Value* cell. This can be done by either double clicking in the cell or pressing F2 with the cell highlighted.
3. If editing a existing ```Quick Insert```, double click in the cell of interest or press F2 with that cell selected.
4. ```Quick Inserts``` cannot be deleted per-se. However, text can be removed from the *Value* field as described in step 3.
   
### Aliases
Typically, when recording work, it is useful to set the ```Work Name``` to a sub-component of a larger grouping. In large companies, these larger groupings are what one is required to book their time to, as they are what appear in the companies plans. Furthermore, these groupings are given codes that are often un-memorable strings such as "ABC.1234Z". 

```Aliases``` allow the user to specify a text string that will appear in the [Export](#export) window if the ```Work Name``` matches a row in the ```Alias``` window.

Each ```Work Name``` can be mapped to one ```Alias```. However, distinct ```Work Names``` can be mapped to a single ```Alias```. 

To generate the replacement specified above, ```Work Name``` would be set to "Feature X" and ```Alias``` would be set to "ABC.1234Z".
```Aliases``` are applied when exporting and hence are only shown in the [Export](#export) view.

```Aliases``` can be added by:
1. Pressing *Tools*->*Alias Manager*
2. Adding and editing ```Aliases``` is identical to the process described for adding [Quick Inserts](#quick-inserts) except the user also has to add a value for the *Work Name* column.
3. To delete an ```Alias```, left click the row selector button to the left of the *Work Name* column and press the Delete key (not Backspace)
   
### Export
Once you have recorded sufficient work for a given time period (e.g. Day or Week) the program can generate a worked time report for you. This report gives a daily breakdown of the time booked to each code. 

If you have more than one entry for a given code in a day, the ```Export``` view give will sum this for each day, not each recorded chunk of time. The grouping can be either by the recorded ```Work Name``` or the currently specified ```Alias``` for that ```Work Name```. Changing the grouping is done by changing the selected radio button in the Grouping box to either *Work Name* or *Alias*.

There are buttons for todays work and this weeks work (assuming Monday is the start of a given work week). These buttons modify the dates in the *From* and *To* date pickers. Arbitrary date ranges can be selected from these date pickers. The report is updated whenever a date is changed.

The *Copy* button copies the report for further analysis in your favourite external tool.

To open the ```Export``` window:
1. Press *Tools*->*Export*
2. Click Today, Week or change the *From* and *To* dates to generate a report
3. Click *Copy* to copy the full report to your clipboard for further analysis
4. Alternatively, individual cells can be copied for insertion into your work tracking tool.

### Options
The ```Options``` window allows the settings of the program to be changed. It can be accessed by:
1. Clicking *Tools*->*Options*

- Ticking *Pause Timer When PC is Locked* will pause the timer when you lock your computer. This is enabled by default.
- Ticking *Minimise to Tray After Enter Key Pressed* will cause the program to minimise itself to the tray after pressing Enter to start recording work. This is enabled by default.

The Paths allow the user to specify the location of the XML files the program uses to store the data. These can be changed by clicking the button with the folder icon at the end of the window. If any paths are changed the program must be restarted before the settings take effect.


### Other
- Choosing *Tools*->*Pause Work* will pause the timer on its current value if the program is currently logging time. When paused, the displayed time will turn red
- Choosing *Tools*->*Resume Work* enables the timer and turns the text black.

## Extra
### Files
The files the program uses to persist data are stored as XML (because it is native to C#). These files are very simple and can be inspected, edited and modified outside of the program. The first time the program is run, blank templates will be created automatically.
