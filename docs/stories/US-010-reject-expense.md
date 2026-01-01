# US-010: Reject Expense

## User Story
**As a** manager  
**I want to** reject a submitted expense with a comment  
**So that** the employee understands why their expense was rejected and what they need to fix

---

## Description
Managers need to reject expenses that are invalid, inappropriate, or missing information. The rejection must include a mandatory comment explaining the reason, so employees understand what needs to be corrected.

---

## Acceptance Criteria

### AC-1: Reject action available for submitted expenses
- **Given** I am viewing an expense with status "Submitted"
- **When** the expense was created by another user (not me)
- **Then** I see a "Reject" button clearly visible

### AC-2: Reject requires comment
- **Given** I click "Reject" on a submitted expense
- **When** the rejection dialog/form opens
- **Then** I see a mandatory comment field with adequate space for explanation
- **And** I cannot complete the rejection without entering a comment
- **And** I see validation error "Rejection comment is required" if I try to submit empty

### AC-3: Confirm rejection with comment
- **Given** I have entered a rejection comment (not empty)
- **When** I confirm the rejection
- **Then** the expense status changes from "Submitted" to "Rejected"
- **And** the rejection comment is saved (immutable)
- **And** my user ID is recorded as the rejector
- **And** the rejection timestamp is automatically recorded
- **And** I see a confirmation message "Expense rejected"
- **And** I am returned to the expenses list

### AC-4: Rejected expense can be edited by employee
- **Given** an expense has been rejected
- **When** the employee (creator) views that expense
- **Then** the status shows "Rejected" (with red error indicator)
- **And** the rejection comment is clearly visible and prominent
- **And** the employee sees an "Edit" button to make corrections
- **And** the expense can be modified and resubmitted

### AC-5: Cannot reject non-submitted expenses
- **Given** I am viewing an expense with status "Draft", "Approved", or "Rejected"
- **When** I view the expense details
- **Then** I do NOT see a "Reject" button

### AC-6: Rejection visible to employee
- **Given** a manager has rejected my expense
- **When** I (as employee) view that expense
- **Then** I see:
  - Status: "Rejected" (with red error indicator)
  - Rejection comment prominently displayed (explaining what to fix)
  - Manager name who rejected
  - Rejection timestamp (date and time)
  - "Edit" button to make corrections

### AC-7: Cannot reject own expenses
- **Given** I am a manager who also created an expense
- **When** I view my own submitted expense
- **Then** I do NOT see a "Reject" button on my own expense
- **And** I see a message "You cannot reject your own expense"

### AC-8: Rejection appears in expense history
- **Given** an expense has been rejected
- **When** anyone views the expense detail or history
- **Then** the rejection event is shown in the timeline/history with: 
  - Rejector name
  - Rejection comment
  - Rejection timestamp

---

## Technical Notes
- Rejection comment is mandatory (not null, not empty string)
- Rejection comment is immutable once saved
- Rejection timestamp (rejected_at) should be automatically recorded
- Rejector user ID (rejected_by) should be recorded
- Status transition: Submitted → Rejected only
- Business rule: rejected_by must NOT equal user_id (creator)
- After rejection, status can transition to Submitted again (via resubmission)

---

## UI/UX Considerations
- Reject button should be visually cautionary (e.g., red or orange color)
- Comment field should have adequate space (text area, not single line)
- Comment field should have helpful placeholder: "Explain what needs to be fixed"
- Rejection comment should be prominent and actionable when employee views the expense
- Rejected expenses should have a distinct visual badge (e.g., red X icon)
- Dialog/modal should show expense summary for context
- Encourage detailed, helpful feedback in the rejection comment

---

## Dependencies
- US-004 (Submit expense) must be completed
- US-007 (View all expenses as manager) must be completed
- US-015 (Role-based access control) must be completed