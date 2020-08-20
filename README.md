# Simple Time Tracker
This program is a very simple and lightweight time tracker written in C#. Inspiration for interaction with the program came from the clipboard manager [Ditto](https://ditto-cp.sourceforge.io/). 
## How to use
### Recording Time
1. Open the exe
2. Type what you're working on (e.g. "Feature X")
3. Press Enter (this will hide the program and begin recording time to "Feature X")
4. Pressing Shift+Enter will uppercase the whole typed string
5. Press Ctrl+? to reopen the program and repeat

### Quick Inserts
Quick Inserts allow the user to quickly insert commonly performed tasks. These values are inserted into the main textbox using Ctrl+1 to Ctrl+9. When pressing and holding Ctrl, a display of the currently saved Quick Inserts are displayed, along with the number used to insert them. 
The exact behaviour of the program varies depending on what the current text in the textbox is and what the current value of the Quick Insert list is. 
If the textbox contains no text, pressing Ctrl and a number will insert the shown text.
If the textbox contains text and Ctrl and a number is pressed then:
If the textbox text matches the Quick Insert for the pressed number, the program will begin recording time for the pressed Quick Insert. This is useful for quickly beginning recording time to a know Quick Insert by calling up the program (Ctrl+?) and pressing Ctrl and a number twice.
If the textbox text does not match the Quick Insert for the pressed number, the Quick Insert for the pressed number will be overridden with the current textbox text. This allows users to quickly re-allocate Quick Insert values.
Quick Inserts can also be modified using the tools built in editor.
1. Press Tools->Quick Insert
2. If adding a new Quick Insert, enter the text value 'Value' cell. This can be done by either double clicking in the cell or pressing F2 with the cell highlighted.
3. If editing a existing Quick Insert, double click in the cell of interest or press F2 with that cell selected.
4. Quick Inserts cannot be deleted per-se. However, text can be removed from the 'Value' field as described in step 3.
   
### Aliases
It can be useful to to add aliases to work names. Aliases allow you to record the work you're doing in an easy to remember way, for example: "Feature X", while being able to record this time as being allocated to something more esoteric, for example: "ABC.1234X". Multiple entries aliased to the same resulting text value. However, each Key must be unique. To generate the replacement specified above 'Key' would be set to "Feature X" and 'Value' would be set to "ABC.1234X".
Aliases are applied when exporting and hence are only shown in the Export view.
1. Press Tools->Alias Manager
2. Adding and editing aliases is identical to the process described for adding Quick Inserts except the user also has to add a value for the 'Key' column.
3. To delete an alias, left click the row selector button to the left of the 'Key' column and press the Delete key (not Backspace)
   
### Export
Once you have recorded sufficient work for a given time period (e.g. Day or Week) the program can generate a worked time report for you. This report gives a daily breakdown of the time booked to each code. If you have more than one entry for a given code in a day, the Export view give will sum this for each day, not each recorded chunk of time. There are buttons for todays work and this weeks work (assuming Monday is the start of a given work week). These buttons modify the dates in the 'From' and 'To' date pickers. Arbitrary date ranges can be selected from these date pickers. The report is updated whenever a date is changed.
The 'Copy' button copies the report for further analysis in your favourite external tool.
1. Press Tools->Export
2. Click Today, Week or change the 'From' and 'To' dates to generate a report
3. Click 'Copy' to copy the full report to your clipboard for further analysis
4. Alternatively, individual cells can be copied for insertion into your work tracking tool.

### Other
There are some basic other features of the tool:
- Choosing Tools->Lock Stops Timer will pause the timer when you lock your computer. This is enabled by default.
- Choosing Tools->Pause Work will pause the timer on its current value if the program is currently logging time. When paused, the displayed time will turn red
- Choosing Tools->Resume Work enables the timer and turns the text black.

## Extra
### Files
The files the program uses to persist data are stored as XML (because it is native to C#). These files are very simple and can be inspected, edited and modified outside of the tool. They are created, and expected to remain in, the directory from where the program is run. On the first run of the program, or if the files are deleted or moved, blanks templates will be created automatically.
