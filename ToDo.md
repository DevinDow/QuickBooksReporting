# Done
- #1: Read multiple CSVs by selecting a folder
- #2: Read Customers.csv & Items.csv automatically at launch then apply
- #4: append any Unmapped Names/Items to CSV, any mappings missing a "to" are Unmapped
- #5: DELETE in Customer mapping CSV = skip LineItem
- #6: Reporting UI
	- **Report Inputs:** select date (calendar picker, YTD, etc), Item or Customer Report, which data, Summary or Detailed
	- **Report Outputs:** printable on screen, export .CSV

# ToDo
- Date Range
	- presets: YTD, MTD, QTD, LYTD, LMTD, LQTD
- #3 Item Mapping header line with flexible columns
	- Item stores static array of field names
	- Item stores simple array of field strings

## Future
- #8: import ItemExport.csv for future Inventory Report, normalize Items
- #7: App used to populate DB in cloud
- #10: forecasting module


# Dino's comments on 12/20
> 1. I have learned that QuickBooks has limit of 32,769 lines when exporting a CSV file. Therefore, we will need to break up the reports exported from QuickBooks into smaller samples than a full year. To you this should not mater, but I would like to see a modification to the parser where I can either put in a wild card in the file name field or it automatically reads all files with the correct name structure. For example I will probably name the datafiles:  “Sales Data 2018 01 thru 06.csv” So for the file reader, we could prepopulate the file name field with “Sales Data *.csv”.

> 2. I would also like to automatically read the Names.csv and Items.csv files so the changes are automatically applied every time the sales data is loaded.

> 3. I like using a simple csv file for the items data and name data files. I suggest we add a header line at the top of the file that defines the name of each column of data. This name should be passed into the internal data structure so it will show up in the headers of the reports. This will allow the csv file to be more human friendly and allow me to change the name of a data field if we need to in the future without altering the code. Also, if I find a need to add a field in the future, it can be done easily. We only need to update the reporting module.

> 4. To aid in creating and maintaining the names.csv and items.csv files, it would be very helpful if I could select the names in the Unmapped Names and Unmapped  Items controls and then paste them into a spreadsheet. Right now I can only select a single item at a time and if I do a ctrl C to copy the data, nothing is added to the copy buffer.

> 5. There may be instances where we want to ignore or otherwise suppress some date. To facilitate this, I would like to add a special key word in the names.csv and items.csv files. For example, if in the names.csv file, a customer name is mapped to DELETE, that customer would be suppressed in the internal data model. We could do the same thing for the items.csv file.  

> 6. Obviously we can simplify the user interface as there is more data shown than needed by a normal user. Most likely, a normal user will be placed directly into the reporting module that will have some key information about the data loaded and then allow them to select subsets of data for the report they want to generate.

## Requirements for Done
> 9. Done for me is to complete the data parser and to have a generic reporting module that I am still trying to define. I will keep it as simple as possible. Right now my thoughts are:
> - The user selects a data range for the desired report
> 	- A calendar selector allows the user to select any date range that is supported by the data in the system
> 		i.e if the earliest transaction is January 1, 2017 – they could not set a report that covers any date before January 1, 2017.
> 	- There will be a few pre-defined data ranges for common reports – e.g.
> 		- Year to Date
> 		- Last Year to Date
> 		- Month to Date
> 		- Last Month to Date
> 		- Quarter to Date
> 		- Last Quarter to Date  
> - The user selects if they want an Item Report or a Customer Report
> - The user selects the data they want in the report by way of a series of drop downs or item list boxes.
> 	- Of course, some data will be required which forms the basis of the report
> - The user selects if they want a summery report or a detailed report
> 	- A Summery report would simply total all transactions for the given Customer or Item
> - The report is generated and shown on the screen.
> - There is an option to output a .csv file of the data or to print the formatted report as it is shown on the screen.

## Future
> 10. We will add a forecasting module in the future. This will be a new project and not part of this initial sales reporting  application or the current allocated budget.

> 8. I need to add one more set of data into the item data structure so it can be pulled during reporting. The data is our inventory levels which comes from another system. Attached to this email is the file ItemExport.csv. This comes out of inventory system. Of course, the product names are all jacked up in this report as well. Basically we will need to do one more pass of normalization for this data. When you look at the ItemExport.csv file you will see it has the following data in it for each item in the report.
	Item, Description, Category, Location Main Warehouse, Tot Qty, Cost, Price
	We only need 2 pieces of information from this file Item and Tot Qty
	We will normalize the Item field to match a specific item that was found in the sales data report, then you just need to add the  Tot Qty to the proper data set.
	This will be used to identify low inventory items in a future report.

> 7. I am still up in the air as to where the data will live and what the user will need to do to access it. I guess it doesn’t matter for now, but I am still interested in making this a web app. If we do that, the parser you are working on would probably be my tool to load all the data we need for reporting and then export it to a database that lives in the cloud somewhere.
