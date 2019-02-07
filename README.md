# QuickBooksReporting

## Usage Steps:
1. On startup: **Company Name Mapping file** & **Item Mapping file** are automatically imported from the *EXE directory*
2. User selects directory of **Sales LineItems CSV files** to import
    - Unmapped **Customers** & **Items** are automatically appended to the **Mapping files** in the *EXE directory*
4. User creates report:
    - choose *Date Range*, *Customer* or *Item*, *Detailed*
    - hit *Generate Report* or *Generate CSV* button
    - **.HTML** or **.CSV** file is written to "reports" subdirectory of the imported directory, HTML is shown in the app, *Open in Browser* button launches **.HTML** file for printing
