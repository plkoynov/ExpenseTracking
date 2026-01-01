# US-005: View My Expenses (Employee)

## User Story
**As an** employee  
**I want to** view a list of all my expenses  
**So that** I can track what I've submitted and see their current status

---

## Description
Employees need a clear overview of all expenses they have created, regardless of status. This provides transparency and helps them understand what is pending, approved, or needs attention.

---

## Acceptance Criteria

### AC-1: Access to my expenses
- **Given** I am logged in as an employee
- **When** I navigate to the expenses section
- **Then** I see a list of all expenses I have created

### AC-2: Display expense summary information
- **Given** I am viewing my expenses list
- **When** the list loads
- **Then** each expense shows:
  - Expense date
  - Amount and currency
  - Category
  - Current status (Draft, Submitted, Approved, Rejected)
  - Submission date (if submitted)
- **And** the list is ordered by most recent first (by creation date or submission date, whichever is more recent)

### AC-3: See only my own expenses
- **Given** I am logged in as an employee (not a manager)
- **When** I view the expenses list
- **Then** I see ONLY expenses that I created
- **And** I do NOT see expenses created by other employees

### AC-4: View expense details
- **Given** I see an expense in my list
- **When** I click on the expense
- **Then** I see the full details including:
  - All expense fields (date, amount, currency, category, description)
  - Current status
  - Created timestamp
  - Submission timestamp (if submitted)
  - Approval details (if approved): approval comment, approver name, approval timestamp
  - Rejection details (if rejected): rejection comment, rejector name, rejection timestamp

### AC-5: Visual status indication
- **Given** I am viewing my expenses list
- **When** I see expenses with different statuses
- **Then** each status is clearly indicated with visual cues (badges, colors, icons)
- **And** I can easily distinguish between: 
  - Draft (neutral color, e.g., gray)
  - Submitted (warning/attention color, e.g., yellow/orange)
  - Approved (success color, e.g., green)
  - Rejected (error color, e.g., red)

### AC-6: Empty state
- **Given** I have not created any expenses yet
- **When** I navigate to my expenses list
- **Then** I see a message "No expenses found"
- **And** I see a clear call-to-action to "Create New Expense"

### AC-7: Contextual actions visible
- **Given** I am viewing my expenses list
- **When** I see an expense
- **Then** I see appropriate action buttons based on status:
  - Draft: "Edit", "Delete", "Submit"
  - Submitted: No actions (read-only, awaiting manager)
  - Approved: No actions (read-only)
  - Rejected: "Edit" (to fix and resubmit)

---

## Technical Notes
- Query should filter expenses by the logged-in employee's user ID
- Default sort:  most recent first (by created_at or submitted_at DESC)
- Pagination may be needed if expense volume is high (future consideration)

---

## UI/UX Considerations
- List should be scannable and easy to read
- Status badges should use consistent colors across the system (per AC-5)
- Clicking an expense should show details (modal, side panel, or separate page)
- Clear visual hierarchy between list view and detail view
- Action buttons should be intuitive and color-coded appropriately

---

## Dependencies
- User authentication system (US-013, US-014)
- Expenses created via US-001, US-004