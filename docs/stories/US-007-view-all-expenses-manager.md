# US-007: View All Expenses (Manager)

## User Story
**As a** manager  
**I want to** view all expenses submitted by any employee  
**So that** I can review and approve/reject them

---

## Description
Managers need visibility into all expenses across the company, especially those awaiting approval. This allows them to perform their review responsibilities efficiently.

---

## Acceptance Criteria

### AC-1: Access to all expenses
- **Given** I am logged in as a manager
- **When** I navigate to the expenses section
- **Then** I see a list of all expenses from all employees

### AC-2: Display expense summary with employee info
- **Given** I am viewing the expenses list as a manager
- **When** the list loads
- **Then** each expense shows:
  - Employee name (who created the expense)
  - Expense date
  - Amount and currency
  - Category
  - Current status (Draft, Submitted, Approved, Rejected)
  - Submission date (if submitted)
- **And** the list is ordered to prioritize "Submitted" expenses first, then by most recent (creation or submission date)

### AC-3: See expenses in all statuses
- **Given** I am viewing expenses as a manager
- **When** the list loads
- **Then** I can see expenses in all statuses:
  - Draft (created but not submitted)
  - Submitted (awaiting approval)
  - Approved
  - Rejected

### AC-4: View expense details
- **Given** I see an expense in the list
- **When** I click on the expense
- **Then** I see full details including:
  - All expense fields (date, amount, currency, category, description)
  - Employee who created it
  - Current status
  - Created timestamp
  - Submission timestamp (if submitted)
  - Approval details (if approved): approval comment, approver name, approval timestamp
  - Rejection details (if rejected): rejection comment, rejector name, rejection timestamp
  - Complete history/timeline of status changes

### AC-5: Highlight pending actions
- **Given** I am viewing the expenses list as a manager
- **When** there are expenses with status "Submitted"
- **Then** those expenses are visually highlighted or grouped at the top
- **And** I can easily identify which expenses need my review

### AC-6: Contextual actions for submitted expenses
- **Given** I am viewing an expense with status "Submitted"
- **When** the expense was NOT created by me
- **Then** I see "Approve" and "Reject" action buttons

### AC-7: Cannot approve/reject own expenses
- **Given** I am viewing an expense with status "Submitted"
- **When** the expense was created by me
- **Then** I do NOT see "Approve" or "Reject" buttons
- **And** I see a message "You cannot approve your own expense"

### AC-8: Empty state
- **Given** there are no expenses in the system
- **When** I view the expenses list as a manager
- **Then** I see a message "No expenses found"

### AC-9: Visual status indication
- **Given** I am viewing the expenses list
- **When** I see expenses with different statuses
- **Then** each status is clearly indicated with visual cues using consistent colors: 
  - Draft (gray)
  - Submitted (yellow/orange)
  - Approved (green)
  - Rejected (red)

---

## Technical Notes
- Managers see all expenses regardless of who created them
- Default sort should prioritize "Submitted" status (needs action), then most recent
- Query must include employee name (join with users table)
- Consider pagination for large datasets

---

## UI/UX Considerations
- Clear visual distinction between "needs my attention" (Submitted) and already processed expenses
- Employee name should be prominent to provide context
- Status badges consistent with employee view
- Manager should have quick access to approve/reject actions from the list or detail view
- "You cannot approve your own expense" message should be clear but not intrusive

---

## Dependencies
- User authentication with role differentiation (US-013, US-014, US-015)
- Expenses created via US-001, US-004