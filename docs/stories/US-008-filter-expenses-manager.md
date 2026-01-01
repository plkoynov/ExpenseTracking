# US-008: Filter and Search Expenses (Manager)

## User Story
**As a** manager  
**I want to** filter and search all expenses  
**So that** I can focus on specific expenses that need review or find expenses by employee, status, or date

---

## Description
Managers need powerful filtering capabilities to manage the full list of company expenses, prioritize reviews, and find specific expenses quickly.

---

## Acceptance Criteria

### AC-1: Filter by status
- **Given** I am viewing all expenses as a manager
- **When** I select a status filter (Draft, Submitted, Approved, Rejected, or "All")
- **Then** the list updates to show only expenses matching that status

### AC-2: Filter by employee
- **Given** I am viewing all expenses as a manager
- **When** I select one or more employees from a filter
- **Then** the list updates to show only expenses created by those employees

### AC-3: Filter by date range
- **Given** I am viewing all expenses
- **When** I select a date range (from date, to date)
- **Then** the list updates to show only expenses where the expense date falls within that range

### AC-4: Filter by category
- **Given** I am viewing all expenses
- **When** I select one or more categories
- **Then** the list updates to show only expenses in the selected categories

### AC-5: Combine multiple filters
- **Given** I am viewing all expenses
- **When** I apply multiple filters (e.g., employee = "John Doe" AND status = "Submitted")
- **Then** the list shows only expenses matching ALL applied filters

### AC-6: Quick filter for pending approvals
- **Given** I am viewing all expenses as a manager
- **When** I click a "Pending Approvals" quick filter button
- **Then** the list immediately filters to show only expenses with status "Submitted"

### AC-7: Clear filters
- **Given** I have applied one or more filters
- **When** I click "Clear Filters" or "Reset"
- **Then** all filters are removed
- **And** the list shows all expenses again

### AC-8: No results message
- **Given** I have applied filters
- **When** no expenses match the filter criteria
- **Then** I see a message "No expenses match your filters"
- **And** I see an option to clear filters

---

## Technical Notes
- Employee filter should be searchable/autocomplete if employee count is high
- Consider providing preset filters:  "Needs Review", "Approved This Month", etc.
- Filters should be applied efficiently on the backend

---

## UI/UX Considerations
- Filter panel should be easily accessible but collapsible
- Active filters should be clearly visible
- Count of filtered results should be displayed
- "Pending Approvals" should be a prominent quick filter

---

## Dependencies
- US-007 (View all expenses as manager) must be completed