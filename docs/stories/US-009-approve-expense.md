# US-009: Approve Expense

## User Story
**As a** manager  
**I want to** approve a submitted expense with a comment  
**So that** the employee knows their expense is approved and why

---

## Description
Managers need to review submitted expenses and approve them when they are valid and appropriate. The approval should include a mandatory comment explaining the decision, creating a clear audit trail. 

---

## Acceptance Criteria

### AC-1: Approve action available for submitted expenses
- **Given** I am viewing an expense with status "Submitted"
- **When** the expense was created by another user (not me)
- **Then** I see an "Approve" button clearly visible

### AC-2: Approve requires comment
- **Given** I click "Approve" on a submitted expense
- **When** the approval dialog/form opens
- **Then** I see a mandatory comment field with adequate space for explanation
- **And** I cannot complete the approval without entering a comment
- **And** I see validation error "Approval comment is required" if I try to submit empty

### AC-3: Confirm approval with comment
- **Given** I have entered an approval comment (not empty)
- **When** I confirm the approval
- **Then** the expense status changes from "Submitted" to "Approved"
- **And** the approval comment is saved (immutable)
- **And** my user ID is recorded as the approver
- **And** the approval timestamp is automatically recorded
- **And** I see a confirmation message "Expense approved"
- **And** I am returned to the expenses list

### AC-4: Approved expense is locked
- **Given** an expense has been approved
- **When** anyone views that expense
- **Then** the status shows "Approved"
- **And** the expense details cannot be edited by anyone
- **And** no further status changes are possible
- **And** no "Edit", "Delete", "Approve", or "Reject" buttons are visible

### AC-5: Cannot approve non-submitted expenses
- **Given** I am viewing an expense with status "Draft", "Approved", or "Rejected"
- **When** I view the expense details
- **Then** I do NOT see an "Approve" button

### AC-6: Approval visible to employee
- **Given** a manager has approved my expense
- **When** I (as employee) view that expense
- **Then** I see: 
  - Status:  "Approved" (with green success indicator)
  - Approval comment
  - Manager name who approved
  - Approval timestamp (date and time)

### AC-7: Cannot approve own expenses
- **Given** I am a manager who also created an expense
- **When** I view my own submitted expense
- **Then** I do NOT see an "Approve" button on my own expense
- **And** I see a message "You cannot approve your own expense"

### AC-8: Approval appears in expense history
- **Given** an expense has been approved
- **When** anyone views the expense detail or history
- **Then** the approval event is shown in the timeline/history with: 
  - Approver name
  - Approval comment
  - Approval timestamp

---

## Technical Notes
- Approval comment is mandatory (not null, not empty string)
- Approval comment is immutable once saved
- Approval timestamp (approved_at) should be automatically recorded
- Approver user ID (approved_by) should be recorded
- Status transition:  Submitted → Approved only
- Business rule: approved_by must NOT equal user_id (creator)
- Once approved, status cannot change to any other state

---

## UI/UX Considerations
- Approve button should be visually positive (e.g., green color)
- Comment field should have adequate space (text area, not single line)
- Comment field should have helpful placeholder:  "Explain why you're approving this expense"
- Confirmation should be clear and reassuring
- Approved expenses should have a distinct visual badge (e.g., green checkmark icon)
- Dialog/modal should show expense summary for context

---

## Dependencies
- US-004 (Submit expense) must be completed
- US-007 (View all expenses as manager) must be completed
- US-015 (Role-based access control) must be completed