# US-006: Filter and Search My Expenses (Employee)

## User Story
**As an** employee  
**I want to** filter and search my expenses  
**So that** I can quickly find specific expenses based on status, date, or category

---

## Description
As employees accumulate expenses over time, they need the ability to filter and narrow down the list to find specific expenses quickly. 

---

## Acceptance Criteria

### AC-1: Filter by status
- **Given** I am viewing my expenses list
- **When** I select a status filter (Draft, Submitted, Approved, Rejected, or "All")
- **Then** the list updates to show only expenses matching that status

### AC-2: Filter by date range
- **Given** I am viewing my expenses list
- **When** I select a date range (from date, to date)
- **Then** the list updates to show only expenses where the expense date falls within that range

### AC-3: Filter by category
- **Given** I am viewing my expenses list
- **When** I select one or more categories
- **Then** the list updates to show only expenses in the selected categories

### AC-4: Combine filters
- **Given** I am viewing my expenses list
- **When** I apply multiple filters (e.g., status = "Approved" AND date range = "Last 3 months")
- **Then** the list shows only expenses matching ALL applied filters

### AC-5: Clear filters
- **Given** I have applied one or more filters
- **When** I click "Clear Filters" or "Reset"
- **Then** all filters are removed
- **And** the list shows all my expenses again

### AC-6: Filter persistence during session
- **Given** I have applied filters
- **When** I navigate to view expense details and return to the list
- **Then** the filters remain applied

### AC-7: No results message
- **Given** I have applied filters
- **When** no expenses match the filter criteria
- **Then** I see a message "No expenses match your filters"
- **And** I see an option to clear filters

---

## Technical Notes
- Filters should be applied server-side if expense volume is high
- URL query parameters can be used to maintain filter state
- Consider default filter options like "Last 30 days", "Last 3 months"

---

## UI/UX Considerations
- Filter controls should be clearly visible but not cluttering the interface
- Active filters should be visually indicated
- Number of results should be displayed
- Filters should update results instantly or with minimal delay

---

## Dependencies
- US-005 (View my expenses) must be completed