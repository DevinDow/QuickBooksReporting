# ToDo

- horizontal scrolling of ListBoxes
- generate Reports
- read multiple years' CSV files

## Design Decisions

- Sales object represents one CSV, so a second CSV can be loaded for previous year.

### Mapping Company Names & Items
- currently fills lstMapped___ then calls fillUnmapped___() & fillLineItems()
- Theoretically a second Mapping CSV could be loaded on top of the first.  Do we need a way to clear the current mappings?
- Item object stores fields
