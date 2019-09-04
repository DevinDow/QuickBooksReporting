# QuickBooksReporting

## Usage Steps
1. On startup: **Company Name Mapping file** & **Item Mapping file** are automatically imported from the *EXE directory*
2. User selects directory of **Sales LineItems CSV files** to import
    - Unmapped **Customers** & **Items** are automatically appended to the **Mapping files** in the *EXE directory*
4. User creates report:
    - choose *Date Range*, *Customer* or *Item*, *Detailed*
    - hit *Generate Report* or *Generate CSV* button
    - **.HTML** or **.CSV** report file is written to "reports" subdirectory of the imported directory, HTML is shown in the app, *Open in Browser* button launches **.HTML** file for printing

### Customer Name Mapping File
The **Company Name Mapping file** is **Customers.csv** stored in the *EXE directory*.  This file is loaded at startup and whenever the *Reload Mappings* menu item is hit.

The **Company Name Mapping file** contains rows of the string found in QuickBooks followed by the string that should be used in our reports.  (ex: "Ace Hardware Corporation","Ace")  

When the application imports Sales data and finds a Customer string that is not in the **Company Name Mapping file**, it adds it to the end of the **Company Name Mapping file**.  (ex: "Ace Hardware Corporation")

To map a Customer string, simply edit the **Customers.csv** file and add the string that you would like it to use instead.  (ex: "Ace Hardware Corporation","Ace")

### Item Mapping File
The **Item Mapping file** is **Items.csv** stored in the *EXE directory*.  This file is loaded at startup and whenever the *Reload Mappings* menu item is hit.

It functions similar to the **Company Name Mapping file**.  However it has the added capability of mapping additional custom columns to an Item.  Edit the first row of the **Item Mapping file** to list the names of the custom columns.  (ex: "Item","Name","Family","UPC","Package Style","Retail Display")  Then edit a row to map the Item to the new name plus the extra custom fields.  (ex: "EZ-Cup 2.0 - Target (EZ-Cup 2.0 - 6 PCS)","Ez-Cup 2.0","Ez-Cup","222222222222","6 pieces","Target")
